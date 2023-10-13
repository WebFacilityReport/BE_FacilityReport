using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.Common.SecurityService;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Response.ResponseAccount;

namespace Infrastructure.IService.ServiceImplement
{
    public class AccountServiceImp : IAccountService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokensHandler _tokensHandler;

        public AccountServiceImp(IUnitofWork unitofWork, IMapper mapper, IPasswordHasher passwordHasher, ITokensHandler tokensHandler)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokensHandler = tokensHandler;
        }

        public async Task<AuthenResponseMessToken> CreateToken(RequestLogin requestLogin)
        {
            var request = await _unitofWork.Account.GetByUsername(requestLogin.UserName);
            //BCrypto Verify
            if (!_passwordHasher.VerifyPasswordB(requestLogin.Password, request.Password))
            {
                throw new Exception("ERROR HASH PASSWORD");
            }
            var response = _tokensHandler.CreateAccessToken(request);
            return _mapper.Map<AuthenResponseMessToken>(response);
        }

        public async Task<List<ResponseAllAccount>> GetAllAccounts()
        {
            var account = await _unitofWork.Account.GetAll();
            return _mapper.Map<List<ResponseAllAccount>>(account);

        }

        public async Task<ResponseAllAccount> GetById(Guid accountId)
        {
            var account = await _unitofWork.Account.GetById(accountId);
            return _mapper.Map<ResponseAllAccount>(account);
        }

        public async Task<ResponseAllAccount> RegisterAccountAdmin(RequestRegisterAccount requestRegisterAccount)
        {
            var account = _mapper.Map<Account>(requestRegisterAccount);
            account.Password = _passwordHasher.HashPassword(requestRegisterAccount.Password);
            account.Role = ROlE.ADMIN.ToString();
            account.Status = "ACTIVE";
            var add = _unitofWork.Account.Add(account);
            _unitofWork.Commit();
            return _mapper.Map<ResponseAllAccount>(add);
        }

        public async Task<ResponseAllAccount> RegisterAccountCustomer(RequestRegisterAccount requestRegisterAccount)
        {
            var account = _mapper.Map<Account>(requestRegisterAccount);
            account.Password = _passwordHasher.HashPassword(requestRegisterAccount.Password);
            account.Role = ROlE.CUSTOMER.ToString();
            account.Status = "ACTIVE";

            var add = _unitofWork.Account.Add(account);
            _unitofWork.Commit();
            return _mapper.Map<ResponseAllAccount>(add);
        }

        public async Task<ResponseAllAccount> RegisterAccountManager(RequestRegisterAccount requestRegisterAccount)
        {
            var account = _mapper.Map<Account>(requestRegisterAccount);
            account.Password = _passwordHasher.HashPassword(requestRegisterAccount.Password);
            account.Role = ROlE.MANAGER.ToString();
            account.Status = "ACTIVE";

            var add = _unitofWork.Account.Add(account);
            _unitofWork.Commit();
            return _mapper.Map<ResponseAllAccount>(add);

        }

        public async Task<ResponseAllAccount> RegisterAccountManagerOffice(RequestRegisterAccount requestRegisterAccount)
        {
            var account = _mapper.Map<Account>(requestRegisterAccount);
            account.Password = _passwordHasher.HashPassword(requestRegisterAccount.Password);
            account.Role = ROlE.MANAGER_OFFICE.ToString();
            account.Status = "ACTIVE";

            var add = _unitofWork.Account.Add(account);
            _unitofWork.Commit();
            return _mapper.Map<ResponseAllAccount>(add);

        }

        public async Task<ResponseAllAccount> RegisterAccountStaff(RequestRegisterAccount requestRegisterAccount)
        {
            var account = _mapper.Map<Account>(requestRegisterAccount);
            account.Password = _passwordHasher.HashPassword(requestRegisterAccount.Password);
            account.Role = ROlE.STAFF.ToString();
            account.Status = "ACTIVE";

            var add = _unitofWork.Account.Add(account);
            _unitofWork.Commit();
            return _mapper.Map<ResponseAllAccount>(add);
        }

        public async Task<ResponseAllAccount> UpdateAccount(Guid accountId, UpdateAccount requestUpdateAccount)
        {
            var account = await _unitofWork.Account.GetById(accountId);
            var update = _mapper.Map(requestUpdateAccount, account);
            update.Password = _passwordHasher.HashPassword(requestUpdateAccount.Password);
            _unitofWork.Account.Update(update);
            _unitofWork.Commit();
            return _mapper.Map<ResponseAllAccount>(update);
        }
    }
}
