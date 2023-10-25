using Application.IGenericRepository.GeneircRepositoryImp;
using Application.Repository;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.RepositoryImp
{
    public class ResourceRepositoryImp : GenericRepositoryImp<Resource>, IResourceRepository
    {
        public ResourceRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public async Task<List<Resource>> GetALLResource()
        {
            return await _context.Set<Resource>()
                .Include(c => c.Job)
                .Include(c => c.Equipment)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Resource> GetById(Guid resourceId)
        {
            var resource = await _context.Set<Resource>().Include(c => c.Job).Include(c => c.Equipment).FirstOrDefaultAsync(c => c.ResourcesId == resourceId);
            if (resource == null)
            {
                throw new Exception("Khong tim thay resource Id");
            }
            return resource;
        }
    }
}
