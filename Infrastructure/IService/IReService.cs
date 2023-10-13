using Infrastructure.Model.Request.RequestResource;
using Infrastructure.Model.Response.ResponseResource;

namespace Infrastructure.IService
{
    public interface IReService
    {
        Task<List<ResponseResource>> GetAllResource();
        Task<ResponseResource> GetById(Guid resourceId);
        Task<ResponseResource> AddResource(RequestResouce requestResouce);
    }
}
