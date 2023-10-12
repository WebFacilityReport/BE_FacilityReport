using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;

namespace Application.Repository.RepositoryImp
{
    public class AccountRepositoryImp : GenericRepositoryImp<Account>,IAccountRepository
    {
        public AccountRepositoryImp(FacilityReportContext context) : base(context)
        {
        }
    }
}
