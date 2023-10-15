using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface ITaskRepository : IGenericRepository<Job>
    {
        Task<List<Job>> GetAll();
        Task<Job> GetById(Guid taskId);
    }
}
