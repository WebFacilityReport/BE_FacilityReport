using AutoMapper;
using Domain.Entity;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Request.RequestAccount;

namespace Infrastructure.IService.ServiceImplement
{
    public class AccountServiceImp : IAccountService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public AccountServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<Account> RegisterAccountAdmin(RequestRegisterAccount requestRegisterAccount)
        {
            var account = _mapper.Map<Account>(requestRegisterAccount);
            
            var add =  _unitofWork.Account.Add(account);
            add.Role = "ADMIN";
            _unitofWork.Commit();
            return add;
        }
    }
}
