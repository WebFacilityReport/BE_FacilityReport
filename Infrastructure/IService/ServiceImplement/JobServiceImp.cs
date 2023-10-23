using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.Common.SecurityService;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseTask;


namespace Infrastructure.IService.ServiceImplement
{
    public class JobServiceImp : IJobService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly ITokensHandler _tokensHandler;

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
                job.CreatorId = account.AccountId;
                job.NameTask = NAMETASK.EQUIPMENT.ToString();
                job.Status = StatusTask.ACTIVE.ToString();

                if (resource.TotalQuantity > resource.UsedQuantity)
                {
                    resource.UsedQuantity += 1;
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
                var add = _unitofWork.Task.Add(job);
                add.CreatedAt = DateTime.Now;
                _unitofWork.Resource.Add(job.Resource);
                add.Status = StatusTask.ACTIVE.ToString();
                _unitofWork.Commit();
                return _mapper.Map<ResponseTask>(add);
            }
            throw new Exception("Không thể giao task");

        }

        public async Task<ResponseTask> ChangeStatus(Guid taskId, string status)
        {
            var change = await _unitofWork.Task.GetById(taskId);
            change.Status = status;
            var update = _unitofWork.Task.Update(change);
            _unitofWork.Commit();
            return _mapper.Map<ResponseTask>(update);
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
                    job.NameTask = NAMETASK.EQUIPMENT.ToString();
                    job.HistoryEquipments.EquipmentId = requestUpdateStatusHistory.EquipmentId;
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
            var change = _mapper.Map(requestUpdateTask, task);
            var update = _unitofWork.Task.Update(change);
            _unitofWork.Commit();
            return _mapper.Map<ResponseTask>(update);
        }


    }
}
