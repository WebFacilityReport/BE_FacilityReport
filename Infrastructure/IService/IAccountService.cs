using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Response.ResponseAccount;

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

        Task<ResponseAllAccount> UpdateAccount(UpdateAccount requestUpdateAccount);

        Task<AuthenResponseMessToken> CreateToken(RequestLogin requestLogin);
        Task<ResponseAllAccount> GetById(Guid accountId);

        Task<ResponseAllAccount> GetByEmail();

    }
}
