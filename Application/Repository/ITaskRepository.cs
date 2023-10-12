using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface ITaskRepository : IGenericRepository<Domain.Entity.Task>
    {
    }
}
