using Application.IGenericRepository;

namespace Application.Repository
{
    public interface ITaskRepository : IGenericRepository<Domain.Entity.Job>
    {
        Task<List<Domain.Entity.Job>> GetAll();
        Task<Domain.Entity.Job> GetById(Guid taskId);
    }
}
