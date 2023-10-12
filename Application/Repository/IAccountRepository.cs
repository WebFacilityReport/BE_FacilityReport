
using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
    }
}
