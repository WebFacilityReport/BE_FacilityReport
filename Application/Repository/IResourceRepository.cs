using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface IResourceRepository : IGenericRepository<Resource>
    {
        Task<List<Resource>> GetALLResource();
        Task<Resource> GetById(Guid resourceId);
        Task<List<Resource>> GetAllResourceACTIVE();
    }
}
