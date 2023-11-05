using Domain.Entity;
using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Response.ResponseAccount;
using System.Threading.Tasks;

namespace Infrastructure.IService
{
    public interface IAccountService
    {
        Task<ResponseAllAccount> RegisterAccountManager(RequestRegisterAccount requestRegisterAccount);
        Task<ResponseAllAccount> RegisterAccountCustomer(RequestRegisterAccount requestRegisterAccount);
        Task<ResponseAllAccount> RegisterAccountStaff(RequestRegisterAccount requestRegisterAccount);
        Task<ResponseAllAccount> RegisterAccountManagerOffice(RequestRegisterAccount requestRegisterAccount);
        Task<ResponseAllAccount> RegisterAccountAdmin(RequestRegisterAccount requestRegisterAccount);
        Task<List<ResponseAllAccount>> GetAllAccounts();

        Task<List<Account>> GetAllAccountsRZ();
        Task<Account> GetByIdRZ(Guid id);
        Task<Account> AddRZ(Account account);
        Task<Account> UpdateRZ(Account account);
        Task<Account> DeleteRZ(Guid id);

        Task<ResponseAllAccount> UpdateAccount(UpdateAccount requestUpdateAccount);

        Task<AuthenResponseMessToken> CreateToken(RequestLogin requestLogin);
        Task<ResponseAllAccount> GetById(Guid accountId);
        Task<ResponseAllAccount> GetByEmail();

        Task<List<ResponseAllAccount>> SearchAccountRole(string role);
        Task<ResponseAllAccount> LoginRZ(string username, string password);
        Task<ResponseAllAccount> GetUsernameRz(string username);

    }
}
