using Application.IGenericRepository.GeneircRepositoryImp;
using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.RepositoryImp
{
    public class HistoryEquipmentRepositoryImp : GenericRepositoryImp<HistoryEquipment>, IHistoryEquipmentRepository
    {
        public HistoryEquipmentRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public  async Task<List<HistoryEquipment>> GetAll()
        {
            return await _context.Set<HistoryEquipment>()
                .Include(c=>c.Equipment)
                .Include(c=>c.Job)
                .ToListAsync();
        }

        public async Task<HistoryEquipment> GetByEquipmentId(Guid equipemntId)
        {
            var history = await _context.Set<HistoryEquipment>()
                .Include(c => c.Equipment)
                .Include(c => c.Job)
                .FirstOrDefaultAsync(c => c.EquipmentId == equipemntId);
            if (history == null)
            {
                throw new Exception("Khong tim thay Equipment ID");
            }
            return history;
        }

        public async Task<HistoryEquipment> GetById(Guid id)
        {
            var history= await _context.Set<HistoryEquipment>()
                .Include(c => c.Equipment)
                .Include(c => c.Job)
                .FirstOrDefaultAsync(c=>c.HistoryId==id);
            if (history == null)
            {
                throw new Exception("Khong tim thay History ID");
            }
            return history;
        }

        public async Task<HistoryEquipment> SearchTaskById(Guid Taskid)
        {
            var history = await _context.Set<HistoryEquipment>()
                .Include(c => c.Equipment)
                .Include(c => c.Job)
                .FirstOrDefaultAsync(c => c.JobId == Taskid);
            if (history == null)
            {
                throw new Exception("Khong tim thay Task ID");
            }
            return history;
        }
    }
}
