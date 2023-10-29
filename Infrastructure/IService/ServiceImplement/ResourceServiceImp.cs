
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Request.RequestResource;
using Infrastructure.Model.Response.ResponseResource;

namespace Infrastructure.IService.ServiceImplement
{
    public class ResourceServiceImp : IReService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public ResourceServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseResource> AddResource(RequestResouce requestResouce)
        {
            var task = await _unitofWork.Task.GetById(requestResouce.TaskId);
            if (task.Status.Equals(StatusTask.ACCEPT.ToString()))
            {
                var resource = _mapper.Map<Resource>(requestResouce);
                resource.UsedQuantity = 0;
                resource.Status = StatusResource.ACTIVE.ToString();
                resource.CreatedAt = DateTime.UtcNow;
                task.Status = StatusTask.DONE.ToString();
                task.Deadline = DateTime.UtcNow;
                _unitofWork.Resource.Add(resource);
                _unitofWork.Task.Update(task);
                _unitofWork.Commit();
                return _mapper.Map<ResponseResource>(resource);
            }
            throw new Exception("Task can't add this");
        }

        public async Task<ResponseResource> DeleteStatus(Guid resourceId)
        {
            var resource = await _unitofWork.Resource.GetById(resourceId);
            resource.Status = StatusResource.INACTIVE.ToString();
            _unitofWork.Resource.Update(resource);
            _unitofWork.Commit();
            return _mapper.Map<ResponseResource>(resource);
        }

        public async Task<List<ResponseResource>> GetAllResource()
        {
            var resource = await _unitofWork.Resource.GetALLResource();
            return _mapper.Map<List<ResponseResource>>(resource);
        }

        public async Task<List<ResponseResource>> getAllResourceACTIVEs()
        {
            var resource = await _unitofWork.Resource.GetAllResourceACTIVE();
            return _mapper.Map<List<ResponseResource>>(resource);
        }

        public async Task<ResponseResource> GetById(Guid resourceId)
        {
            var resource = await _unitofWork.Resource.GetById(resourceId);
            return _mapper.Map<ResponseResource>(resource);
        }

        public async Task<ResponseResource> UpdateStatus(Guid resourceId, string status)
        {
            var resource = await _unitofWork.Resource.GetById(resourceId);
            resource.Status = status;
            _unitofWork.Resource.Update(resource);
            _unitofWork.Commit();
            return _mapper.Map<ResponseResource>(resource);

        }
    }
}
