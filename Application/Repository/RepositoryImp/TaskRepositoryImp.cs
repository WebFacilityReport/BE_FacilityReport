using Application.IGenericRepository.GeneircRepositoryImp;
using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.RepositoryImp
{
    public class TaskRepositoryImp : GenericRepositoryImp<Job>, ITaskRepository
    {
        public TaskRepositoryImp(FacilityReportContext context) : base(context)
        {
        }



        public Task<List<Job>> GetAll()
        {
            return _context.Set<Job>().Include(a => a.Creator).Include(a => a.Employee).Include(r => r.Resource).ToListAsync();
        }

        public async Task<Job> GetById(Guid taskId)
        {
            var task = await _context.Set<Job>()
                .Include(a => a.Creator)
                .Include(a => a.Employee)
                .Include(r => r.Resource)
                .FirstOrDefaultAsync(c => c.JobId == taskId);
            if (task == null)
            {
                throw new Exception("Khong tim thay Task Id");
            }
            return task;
        }
    }
}
