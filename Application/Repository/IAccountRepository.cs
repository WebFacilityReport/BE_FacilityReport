using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<List<Account>> GetAll();
        Task<Account> GetById(Guid accountId);
        Task<Account> GetByUsername(string username);
    }
}
