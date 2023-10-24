using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<List<Account>> GetAll();
        Task<Account> GetById(Guid accountId);
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
        Task<bool> ExistByEmail(string email);
        Task<bool> ExistByPhone(string phone);
        Task<bool> ExistByUsername(string username);


    }
}
