using Application.IGenericRepository.GeneircRepositoryImp;
using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.RepositoryImp
{
    public class TaskRepositoryImp : GenericRepositoryImp<Domain.Entity.Job>, ITaskRepository
    {
        public TaskRepositoryImp(FacilityReportContext context) : base(context)
        {
        }



        public Task<List<Domain.Entity.Job>> GetAll()
        {
            return _context.Set<Domain.Entity.Job>().Include(a => a.Creator).Include(a => a.Employee).Include(r => r.Resources).ToListAsync();
        }

        public async Task<Domain.Entity.Job> GetById(Guid taskId)
        {
            var task = await _context.Set<Domain.Entity.Job>()
                .Include(a => a.Creator)
                .Include(a => a.Employee)
                .Include(r => r.Resources)
                .FirstOrDefaultAsync(c => c.JobId == taskId);
            if (task == null)
            {
                throw new Exception("Khong tim thay Task Id");
            }
            return task;
        }
    }
}
