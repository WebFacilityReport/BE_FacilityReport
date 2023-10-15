using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        Task<List<Feedback>> GetAll();
        Task<Feedback> GetById(Guid id);
    }
}
