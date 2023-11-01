using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.Common.SecurityService;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseTask;
using System.Security.Principal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace Infrastructure.IService.ServiceImplement
{
    public class JobServiceImp : IJobService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;
        // Tạo đối tượng TimeZoneInfo cho múi giờ của Việt Nam
        static TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        // Lấy thời gian hiện tại ở Việt Nam
        DateTime vietnamNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);
        public JobServiceImp(IUnitofWork unitofWork, IMapper mapper, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _tokensHandler = tokensHandler;
        }

        public async Task<ResponseTask> AddTaskEquipmentByResourceId(RequestTaskEquipment requestTaskEquipment)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitofWork.Account.GetByEmail(email);
            var employee = await _unitofWork.Account.GetById(requestTaskEquipment.EmployeeId);
            var resource = await _unitofWork.Resource.GetById(requestTaskEquipment.ResourceId);

            if (account.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employee.Role.Equals(ROlE.STAFF.ToString()))
            {
                var job = _mapper.Map<Job>(requestTaskEquipment);
                if (resource.Status.Equals(StatusResource.ACTIVE.ToString()))
                {
                    job.CreatorId = account.AccountId;
                    job.NameTask = NAMETASK.CREATEEQUIPMENT.ToString();
                    job.Status = StatusTask.ACTIVE.ToString();
                    if (resource.TotalQuantity > resource.UsedQuantity)
                    {
                        resource.UsedQuantity += 1;
                        job.CreatedAt = vietnamNow;
                        if (job.Deadline <= job.CreatedAt.AddHours(2))
                        {
                            throw new Exception("Yêu Cầu Hoàn Thành Ít Nhất 2h");
                        }
                        _unitofWork.HistoryEquipment.Add(job.HistoryEquipments);
                        _unitofWork.Equiptment.Add(job.HistoryEquipments.Equipment);
                        _unitofWork.Task.Add(job);
                        _unitofWork.Commit();
                        return _mapper.Map<ResponseTask>(job);
                    }
                    else
                    {
                        throw new Exception("Used quantity da qua so luong. Yeu cau tao them Resource");
                    }
                }
                else
                {
                    throw new Exception("Resource không được sử dụng ( phải được ACTIVE )");
                }

            }
            throw new Exception("Không thể giao task");
        }

        public async Task<ResponseTask> AddTaskResource(RequestTaskResource requestTaskResource)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitofWork.Account.GetByEmail(email);
            var employeeId = await _unitofWork.Account.GetById(requestTaskResource.EmployeeId);
            if (account.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employeeId.Role.Equals(ROlE.STAFF.ToString()))
            {
                var job = _mapper.Map<Job>(requestTaskResource);
                job.CreatorId = account.AccountId;
                job.NameTask = NAMETASK.RESOURCE.ToString();
                job.CreatedAt = vietnamNow;
                job.Status = StatusTask.ACTIVE.ToString();
                if (job.Deadline <= job.CreatedAt.AddHours(2))
                {
                    throw new Exception("Yêu Cầu Hoàn Thành Ít Nhất 2h");
                }
                var add = _unitofWork.Task.Add(job);
                _unitofWork.Resource.Add(job.Resource);
                _unitofWork.Commit();
                return _mapper.Map<ResponseTask>(add);
            }
            throw new Exception("Không thể giao task");

        }

        public async Task<ResponseTask> ChangeStatus(Guid taskId, string status)
        {
            var change = await _unitofWork.Task.GetById(taskId);
            if (change.Status.Equals(StatusTask.REJECT.ToString()) || change.Status.Equals(StatusTask.DONE.ToString()))
            {
                throw new Exception("Không được thay đổi Status nữa");
            }
            else if (change.Status.Equals(StatusTask.ACTIVE.ToString()))
            {
                change.Status = status;
                _unitofWork.Task.Update(change);
                _unitofWork.Commit();
            }
            return _mapper.Map<ResponseTask>(change);

        }

        public async Task<List<ResponseTask>> GetAllTask()
        {
            var task = await _unitofWork.Task.GetAll();
            return _mapper.Map<List<ResponseTask>>(task);
        }

        public async Task<ResponseTask> GetTaskById(Guid taskId)
        {
            var task = await _unitofWork.Task.GetById(taskId);
            return _mapper.Map<ResponseTask>(task);
        }

        public async Task<ResponseTask> UpdateHistoryEquipment(RequestUpdateStatusHistory requestUpdateStatusHistory)
        {
            var email = _tokensHandler.ClaimsFromToken();
            var account = await _unitofWork.Account.GetByEmail(email);
            var employee = await _unitofWork.Account.GetById(requestUpdateStatusHistory.EmployeeId);
            var equipment = await _unitofWork.Equiptment.GetById(requestUpdateStatusHistory.EquipmentId);
            if (account.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employee.Role.Equals(ROlE.STAFF.ToString()))
            {
                if (equipment.Status.Equals(STATUSEQUIPMENT.FIX.ToString()))
                {
                    var job = _mapper.Map<Job>(requestUpdateStatusHistory);
                    job.CreatorId = account.AccountId;
                    job.Status = StatusTask.ACTIVE.ToString();
                    job.NameTask = NAMETASK.FIXEQUIPMENT.ToString();
                    job.HistoryEquipments.EquipmentId = requestUpdateStatusHistory.EquipmentId;
                    job.CreatedAt = DateTime.UtcNow;
                    if (job.Deadline <= job.CreatedAt.AddHours(2))
                    {
                        throw new Exception("Yêu Cầu Hoàn Thành Ít Nhất 2h");
                    }
                    var checkHistory = await _unitofWork.Task.CheckExsitTaskbyHistoryWithEquipmentId(equipment.EquipmentId);
                    _unitofWork.HistoryEquipment.Add(job.HistoryEquipments);
                    _unitofWork.Task.Add(job);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(job);
                }
                throw new Exception("Thiết bị không bị hỏng ");
            }
            throw new Exception("Không thể giao task");
        }

        public async Task<ResponseTask> UpdateTask(Guid taskId, RequestUpdateTask requestUpdateTask)
        {
            var task = await _unitofWork.Task.GetById(taskId);
            if (task.Status.Equals(StatusTask.ACTIVE.ToString()))
            {
                var change = _mapper.Map(requestUpdateTask, task);
                var update = _unitofWork.Task.Update(change);
                _unitofWork.Commit();
                return _mapper.Map<ResponseTask>(update);
            }

            throw new Exception("Không cần phải Update nữa (phải được in ACTIVE)");

        }

        public async Task<ResponseTask> AddTaskResourceRz(RequestTaskResourceRz requestTaskResource)
        {
            var creatorId = await _unitofWork.Account.GetById(requestTaskResource.CreatorId);
            var employeeId = await _unitofWork.Account.GetById(requestTaskResource.EmployeeId);
            if (creatorId.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employeeId.Role.Equals(ROlE.STAFF.ToString()))
            {
                var job = _mapper.Map<Job>(requestTaskResource);
                //job.CreatorId = creatorId.AccountId;
                job.NameTask = NAMETASK.RESOURCE.ToString();
                job.CreatedAt = vietnamNow;
                job.Status = StatusTask.ACTIVE.ToString();
                if (job.Deadline <= job.CreatedAt.AddHours(2))
                {
                    throw new Exception("Yêu Cầu Hoàn Thành Ít Nhất 2h");
                }
                var add = _unitofWork.Task.Add(job);
                _unitofWork.Resource.Add(job.Resource);
                _unitofWork.Commit();
                return _mapper.Map<ResponseTask>(add);
            }
            throw new Exception("Không thể giao task");
        }

        public async Task<ResponseTask> AddTaskEquipmentByResourceIdRZ(RequestTaskEquipmentRZ requestTaskEquipment)
        {
            var account = await _unitofWork.Account.GetById(requestTaskEquipment.CreatorId);
            var employee = await _unitofWork.Account.GetById(requestTaskEquipment.EmployeeId);
            var resource = await _unitofWork.Resource.GetById(requestTaskEquipment.ResourceId);

            if (account.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employee.Role.Equals(ROlE.STAFF.ToString()))
            {
                var job = _mapper.Map<Job>(requestTaskEquipment);
                if (resource.Status.Equals(StatusResource.ACTIVE.ToString()))
                {
                    job.CreatorId = account.AccountId;
                    job.NameTask = NAMETASK.CREATEEQUIPMENT.ToString();
                    job.Status = StatusTask.ACTIVE.ToString();

                    if (resource.TotalQuantity > resource.UsedQuantity)
                    {
                        resource.UsedQuantity += 1;
                        job.CreatedAt = vietnamNow;
                        if (job.Deadline <= job.CreatedAt.AddHours(2))
                        {
                            throw new Exception("Yêu Cầu Hoàn Thành Ít Nhất 2h");
                        }
                        _unitofWork.HistoryEquipment.Add(job.HistoryEquipments);
                        _unitofWork.Equiptment.Add(job.HistoryEquipments.Equipment);
                        _unitofWork.Task.Add(job);
                        _unitofWork.Commit();
                        return _mapper.Map<ResponseTask>(job);
                    }
                    else
                    {
                        throw new Exception("Used quantity da qua so luong. Yeu cau tao them Resource");
                    }
                }
                else
                {
                    throw new Exception("Resource không được sử dụng ( phải được ACTIVE )");
                }

            }
            throw new Exception("Không thể giao task");
        }

        public async Task<ResponseTask> UpdateHistoryEquipmentRZ(RequestUpdateStatusHistoryRZ requestUpdateStatusHistory)
        {
            var account = await _unitofWork.Account.GetById(requestUpdateStatusHistory.CreatorId);
            var employee = await _unitofWork.Account.GetById(requestUpdateStatusHistory.EmployeeId);
            var equipment = await _unitofWork.Equiptment.GetById(requestUpdateStatusHistory.EquipmentId);
            if (account.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employee.Role.Equals(ROlE.STAFF.ToString()))
            {
                if (equipment.Status.Equals(STATUSEQUIPMENT.FIX.ToString()))
                {
                    var job = _mapper.Map<Job>(requestUpdateStatusHistory);
                    job.Status = StatusTask.ACTIVE.ToString();
                    job.NameTask = NAMETASK.FIXEQUIPMENT.ToString();
                    job.HistoryEquipments.EquipmentId = requestUpdateStatusHistory.EquipmentId;
                    job.CreatedAt = vietnamNow;
                    if (job.Deadline <= job.CreatedAt.AddHours(2))
                    {
                        throw new Exception("Yêu Cầu Hoàn Thành Ít Nhất 2h");
                    }
                    await _unitofWork.Task.CheckExsitTaskbyHistoryWithEquipmentId(equipment.EquipmentId);
                    _unitofWork.HistoryEquipment.Add(job.HistoryEquipments);
                    _unitofWork.Task.Add(job);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(job);
                }
                throw new Exception("Thiết bị không bị hỏng ");
            }
            throw new Exception("Không thể giao task");
        }

        public async Task<List<ResponseTask>> GetListTaskStaff(Guid staffId)
        {
            var staff = await _unitofWork.Task.GetAllStaff(staffId);
            return _mapper.Map<List<ResponseTask>>(staff);
        }

        public async Task<ResponseTask> ChangeStatusStaff(Guid taskId, string status)
        {
            var task = await _unitofWork.Task.GetById(taskId);
            if (task.Status.Equals(StatusTask.ACTIVE.ToString()))
            {
                task.Status = status;
                if (task.Status.Equals(StatusTask.DONE.ToString()) && task.NameTask.Equals(NAMETASK.RESOURCE.ToString()))
                {
                    task.Resource.Status = StatusResource.ACTIVE.ToString();
                    var update = _unitofWork.Task.Update(task);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(update);
                }
                if (task.Status.Equals(StatusTask.REJECT.ToString()) && task.NameTask.Equals(NAMETASK.RESOURCE.ToString()))
                {
                    task.Resource.Status = StatusResource.INACTIVE.ToString();
                    var update = _unitofWork.Task.Update(task);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(update);
                }
                if (task.Status.Equals(StatusTask.DONE.ToString()) && task.NameTask.Equals(NAMETASK.CREATEEQUIPMENT.ToString()))
                {
                    var checkhistory = await _unitofWork.HistoryEquipment.SearchTaskById(task.JobId);
                    var checkequipemnt = await _unitofWork.HistoryEquipment.GetByEquipmentId(checkhistory.EquipmentId);
                    checkequipemnt.Status = STATUSEQUIPMENT.ACTIVE.ToString();
                    checkequipemnt.Equipment.Status = STATUSEQUIPMENT.ACTIVE.ToString();
                    var update = _unitofWork.Task.Update(task);
                    _unitofWork.Equiptment.Update(checkequipemnt.Equipment);
                    _unitofWork.HistoryEquipment.Update(task.HistoryEquipments);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(update);
                }
                if (task.Status.Equals(StatusTask.REJECT.ToString()) && task.NameTask.Equals(NAMETASK.CREATEEQUIPMENT.ToString()))
                {

                    var checkhistory = await _unitofWork.HistoryEquipment.SearchTaskById(task.JobId);
                    var checkequipemnt = await _unitofWork.HistoryEquipment.GetByEquipmentId(checkhistory.EquipmentId);
                    checkequipemnt.Status = STATUSEQUIPMENT.INACTIVE.ToString();
                    checkequipemnt.Equipment.Status = STATUSEQUIPMENT.INACTIVE.ToString();
                    var update = _unitofWork.Task.Update(task);
                    _unitofWork.Equiptment.Update(checkequipemnt.Equipment);
                    _unitofWork.HistoryEquipment.Update(task.HistoryEquipments);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(update);
                }
                if (task.Status.Equals(StatusTask.DONE.ToString()) && task.NameTask.Equals(NAMETASK.FIXEQUIPMENT.ToString()))
                {
                    var checkhistory = await _unitofWork.HistoryEquipment.SearchTaskById(task.JobId);
                    var checkequipemnt = await _unitofWork.HistoryEquipment.GetByEquipmentId(checkhistory.EquipmentId);
                    checkequipemnt.Status = STATUSEQUIPMENT.ACTIVE.ToString();
                    checkequipemnt.Equipment.Status = STATUSEQUIPMENT.ACTIVE.ToString();
                    var update = _unitofWork.Task.Update(task);
                    _unitofWork.Equiptment.Update(checkequipemnt.Equipment);
                    _unitofWork.HistoryEquipment.Update(task.HistoryEquipments);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(update);
                }
                if (task.Status.Equals(StatusTask.REJECT.ToString()) && task.NameTask.Equals(NAMETASK.FIXEQUIPMENT.ToString()))
                {
                    var checkhistory = await _unitofWork.HistoryEquipment.SearchTaskById(task.JobId);
                    var checkequipemnt = await _unitofWork.HistoryEquipment.GetByEquipmentId(checkhistory.EquipmentId);
                    checkequipemnt.Status = STATUSEQUIPMENT.INACTIVE.ToString();
                    checkequipemnt.Equipment.Status = STATUSEQUIPMENT.FIX.ToString();
                    var update = _unitofWork.Task.Update(task);
                    _unitofWork.Equiptment.Update(checkequipemnt.Equipment);
                    _unitofWork.HistoryEquipment.Update(task.HistoryEquipments);
                    _unitofWork.Commit();
                    return _mapper.Map<ResponseTask>(update);
                }

            }
            throw new Exception("Cancel Task (Staff) || DONE Task (Staff)");
        }

        public async Task<List<ResponseTask>> SearchAllTask(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                var tasks = await _unitofWork.Task.GetAll();
                return _mapper.Map<List<ResponseTask>>(tasks);
            }
            var task = await _unitofWork.Task.SearchTaskGetll(query);
            return _mapper.Map<List<ResponseTask>>(task);
        }
    }
}
