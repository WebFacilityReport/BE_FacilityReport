using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.RepositoryImp
{
    public class AccountRepositoryImp : GenericRepositoryImp<Account>, IAccountRepository
    {
        public AccountRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Set<Account>().Include(c => c.JobCreators).Include(c => c.JobEmployees).Include(c => c.Posts).Include(f => f.Feedbacks).ToListAsync();
        }

        public async Task<Account> GetById(Guid accountId)
        {
            var account = await _context.Set<Account>()
                .Include(c => c.JobCreators)
                .Include(c => c.JobEmployees)
                .Include(c => c.Posts)
                .Include(f => f.Feedbacks)
                .FirstOrDefaultAsync(c => c.AccountId == accountId);
            if (account == null)
            {
                throw new Exception("Khong tim thay account id");
            }
            return account;
        }

        public async Task<Account> GetByUsername(string username)
        {
            var account = await _context.Set<Account>()
               .Include(c => c.JobCreators)
               .Include(c => c.JobEmployees)
               .Include(c => c.Posts)
               .Include(f => f.Feedbacks)
               .FirstOrDefaultAsync(c => c.Username == username);
            if (account == null)
            {
                throw new Exception("Khong tim thay username");
            }
            return account;
        }
    }
}
