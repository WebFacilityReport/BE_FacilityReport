using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        Task<List<Feedback>> GetAll();
        Task<List<Feedback>> GetAllByAccountId(Guid accountId);
        Task<Feedback> GetById(Guid id);

    }
}
