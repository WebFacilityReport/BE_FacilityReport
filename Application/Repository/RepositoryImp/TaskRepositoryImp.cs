using Application.IGenericRepository.GeneircRepositoryImp;
using Application.Repository;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

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
                .Include(c => c.HistoryEquipments)
                .ThenInclude(c => c.Equipment)
                .FirstOrDefaultAsync(c => c.HistoryEquipments.EquipmentId == equipmentId
                       && c.HistoryEquipments.Status.Equals(StatusTask.INACTIVE.ToString())
                       && c.HistoryEquipments.NameHistory.Equals(NAMETASK.FIXEQUIPMENT.ToString())
                       );
            if (check != null)
            {
                throw new Exception("Existed Task Equipment");
            }
            return check;
        }

        public Task<List<Job>> GetAll()
        {
            return _context.Set<Job>()
                .Include(a => a.Creator)
                .Include(a => a.Employee)
                .Include(r => r.Resource)
                .Include(r => r.Resource)
                .OrderByDescending(j => j.CreatedAt)
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
    }
}
