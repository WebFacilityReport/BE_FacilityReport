using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseTask;


namespace Infrastructure.IService.ServiceImplement
{
    public class JobServiceImp : IJobService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public JobServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseTask> AddTaskEquipmentByResourceId(RequestTaskEquipment requestTaskEquipment)
        {
            var creator = await _unitofWork.Account.GetById(requestTaskEquipment.CreatorId);
            var employee = await _unitofWork.Account.GetById(requestTaskEquipment.EmployeeId);
            var resource = await _unitofWork.Resource.GetById(requestTaskEquipment.ResourceId);

            if (creator.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employee.Role.Equals(ROlE.STAFF.ToString()))
            {
                var job = _mapper.Map<Job>(requestTaskEquipment);
                job.NameTask = NAMETASK.EQUIPMENT.ToString();
                job.Status = StatusTask.ACTIVE.ToString();

                if (resource.TotalQuantity > resource.UsedQuantity)
                {
                    HistoryEquipment equipmentHistory = new HistoryEquipment
                    {
                        Date = DateTime.Now,
                        NameHistory = NAMETASK.EQUIPMENT.ToString(),
                        Status = StatusTask.INACTIVE.ToString(),
                        Equipment = new Equipment
                        {
                            Status = StatusTask.INACTIVE.ToString(),
                            ImageEquip = requestTaskEquipment.ImageEquip,
                            CreatedAt = DateTime.Now,
                            Location = requestTaskEquipment.Location,
                            ResourcesId = requestTaskEquipment.ResourceId,
                        }
                    };
                    resource.UsedQuantity += 1;
                    job.HistoryEquipments = equipmentHistory;
                    _unitofWork.HistoryEquipment.Add(equipmentHistory);
                    _unitofWork.Equiptment.Add(equipmentHistory.Equipment);
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
            var creatorId = await _unitofWork.Account.GetById(requestTaskResource.CreatorId);
            var employeeId = await _unitofWork.Account.GetById(requestTaskResource.EmployeeId);
            if (creatorId.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employeeId.Role.Equals(ROlE.STAFF.ToString()))
            {
                var job = _mapper.Map<Job>(requestTaskResource);
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
