using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.RepositoryImp
{
    public class EquiptmentRepositoryImp : GenericRepositoryImp<Equipment>, IEquiptmentRepository
    {
        public EquiptmentRepositoryImp(FacilityReportContext context) : base(context)
        {
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
            return await _context.Set<Equipment>().Include(c => c.HistoryEquipments).Include(c => c.Resources).ToListAsync();
        }
    }
}
