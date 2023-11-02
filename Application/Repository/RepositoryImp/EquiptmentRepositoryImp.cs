using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.RepositoryImp
{
    public class EquiptmentRepositoryImp : GenericRepositoryImp<Equipment>, IEquiptmentRepository
    {
        public EquiptmentRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public async Task<List<Equipment>> GetallEquipmentActive()
        {
            return await _context.Set<Equipment>()
                .Include(c => c.HistoryEquipments)
                .Include(c => c.Resources)
                .OrderByDescending(c => c.CreatedAt)
                .Where(c => c.Status.Equals(STATUSEQUIPMENT.ACTIVE.ToString()))
                .ToListAsync();
        }

        public async Task<List<Equipment>> GetallEquipmentFix()
        {
            return await _context.Set<Equipment>()
                .Include(c => c.HistoryEquipments)
                .Include(c => c.Resources)
                .OrderByDescending(c => c.CreatedAt)
                .Where(c => c.Status.Equals(STATUSEQUIPMENT.FIX.ToString()))
                .ToListAsync();
        }

        public async Task<Equipment> GetById(Guid id)
        {
            var equip = await _context.Set<Equipment>()
                .Include(c => c.HistoryEquipments)
                .Include(c => c.Resources)
                .FirstOrDefaultAsync(c => c.EquipmentId == id);

            if (equip == null)
            {
                throw new Exception("Khong tim thay EquipmentId");
            }
            return equip;
        }

        public async Task<List<Equipment>> GetEquipment()
        {
            return await _context.Set<Equipment>()
                .Include(c => c.HistoryEquipments)
                .Include(c => c.Resources)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Equipment>> SearchGetEquipment(string query)
        {
            return await _context.Set<Equipment>()
                 .Include(c => c.HistoryEquipments)
                 .Include(c => c.Resources)
                 .OrderByDescending(c => c.CreatedAt)
                 .Where(c => c.Location.ToLower()
                 .Contains(query.ToLower()) || c.Status.ToUpper().Contains(query.ToUpper()))
                 .ToListAsync();
        }
    }
}
