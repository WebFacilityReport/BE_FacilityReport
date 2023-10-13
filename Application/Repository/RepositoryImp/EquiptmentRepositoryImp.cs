using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;

namespace Application.Repository.RepositoryImp
{
    public class EquiptmentRepositoryImp : GenericRepositoryImp<Equipment>, IEquiptmentRepository
    {
        public EquiptmentRepositoryImp(FacilityReportContext context) : base(context)
        {
        }

        public List<Equipment> GetEquipment()
        {
            throw new NotImplementedException();
        }
    }
}
