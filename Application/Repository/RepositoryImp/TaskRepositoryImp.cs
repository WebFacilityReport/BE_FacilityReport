using Application.IGenericRepository.GeneircRepositoryImp;
using Application.Repository;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Repository.RepositoryImp
{
    public class TaskRepositoryImp : GenericRepositoryImp<Job>, ITaskRepository
    {
        public TaskRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public async Task<Job> CheckExsitTaskbyHistoryWithEquipmentId(Guid equipmentId)
        {
            var check = await _context.Set<Job>()
                .Include(c => c.HistoryEquipment)
                .ThenInclude(c => c.Equipment)
                .FirstOrDefaultAsync(c => c.HistoryEquipment.EquipmentId == equipmentId
                       && c.HistoryEquipment.Job.Status.Equals(StatusTask.ACTIVE.ToString())
                       && c.HistoryEquipment.NameHistory.Equals(NAMETASK.FIXEQUIPMENT.ToString())
                       );
            if (check != null)
            {
                throw new Exception("Existed Task Equipment");
            }
            return check;
        }

        public async Task<List<Job>> GetAll()
        {
            return await _context.Set<Job>()
                .Include(a => a.Creator)
                .Include(a => a.Employee)
                .Include(r => r.Resource)
                .Include(r => r.Resource)
                .OrderByDescending(j => j.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Job>> GetAllStaff(Guid staffId, string SearchQuery)
        {
            return await _context.Set<Job>().Include(a => a.Creator)
                .Include(a => a.Employee)
                .Include(r => r.Resource)
                .Include(r => r.Resource)
            .OrderByDescending(j => j.CreatedAt)
            .Where(c => c.EmployeeId == staffId && (c.NameTask.ToUpper().Contains(SearchQuery.ToUpper()) || c.Status.Contains(SearchQuery.ToUpper())))
            .ToListAsync();
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

        public async Task<List<Job>> SearchTaskGetll(string query)
        {
            return await _context.Set<Job>()
                .Include(a => a.Creator)
                .Include(a => a.Employee)
                .Include(r => r.Resource)
                .OrderByDescending(j => j.CreatedAt)
                .Where(c => c.NameTask.ToLower().Contains(query.ToLower()) || c.Title.Contains(query.ToLower()))
                .ToListAsync();

        }
    }
}
