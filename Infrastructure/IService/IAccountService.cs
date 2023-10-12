using Domain.Entity;
using Infrastructure.Model.Request.RequestAccount;

namespace Infrastructure.IService
{
    public interface IAccountService
    {
        Task<Account> RegisterAccountAdmin(RequestRegisterAccount requestRegisterAccount);
    }
}
