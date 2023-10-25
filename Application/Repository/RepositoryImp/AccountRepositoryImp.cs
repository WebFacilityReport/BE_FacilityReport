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

        public async Task<bool> ExistByEmail(string email)
        {
            var check = await _context.Set<Account>().Include(c => c.JobCreators).Include(c => c.JobEmployees).Include(f => f.Feedbacks).FirstOrDefaultAsync(c => c.Email == email);
            if (check != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExistByPhone(string phone)
        {
            var check = await _context.Set<Account>().Include(c => c.JobCreators).Include(c => c.JobEmployees).Include(f => f.Feedbacks).FirstOrDefaultAsync(c => c.Phone == phone);
            if (check != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExistByUsername(string username)
        {
            var check = await _context.Set<Account>().Include(c => c.JobCreators).Include(c => c.JobEmployees).Include(f => f.Feedbacks).FirstOrDefaultAsync(c => c.Username == username);
            if (check != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Set<Account>().Include(c => c.JobCreators).Include(c => c.JobEmployees).Include(f => f.Feedbacks).ToListAsync();
        }

        public async Task<Account> GetByEmail(string email)
        {
            var account = await _context.Set<Account>()
                           .Include(c => c.JobCreators)
                           .Include(c => c.JobEmployees)
                           .Include(f => f.Feedbacks)
                           .FirstOrDefaultAsync(c => c.Email == email);
            if (account == null)
            {
                throw new Exception("Khong tim thay email");
            }
            return account;
        }

        public async Task<Account> GetById(Guid accountId)
        {
            var account = await _context.Set<Account>()
                .Include(c => c.JobCreators)
                .Include(c => c.JobEmployees)
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
               .Include(f => f.Feedbacks)
               .FirstOrDefaultAsync(c => c.Username == username);
            if (account == null)
            {
                throw new Exception("Khong tim thay username");
            }
            return account;
        }
        public async Task<List<Account>> SearchAccountROLE(string role)
        {
            var account = await _context.Set<Account>()
                          .Include(c => c.JobCreators)
                          .Include(c => c.JobEmployees)
                          .Include(f => f.Feedbacks)
                          .Where(c => c.Role.Equals(role)).ToListAsync();
            return account;
        }
    }
}
