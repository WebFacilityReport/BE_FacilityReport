using AutoMapper;
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

        public async Task<ResponseTask> AddTask(RequestTask requestTask)
        {
            var creatorId = await _unitofWork.Account.GetById(requestTask.CreatorId);
            var employeeId = await _unitofWork.Account.GetById(requestTask.EmployeeId);
            if (creatorId.Role.Equals(ROlE.MANAGER_OFFICE.ToString()) && employeeId.Role.Equals(ROlE.STAFF.ToString()))
            {
                var task = _mapper.Map<Domain.Entity.Job>(requestTask);
                var add = _unitofWork.Task.Add(task);
                add.CreatedAt = DateTime.Now;
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
