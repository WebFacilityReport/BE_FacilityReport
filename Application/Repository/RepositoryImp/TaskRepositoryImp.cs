using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;


namespace Application.Repository.RepositoryImp
{
    public class TaskRepositoryImp : GenericRepositoryImp<Domain.Entity.Task>,ITaskRepository
    {
        public TaskRepositoryImp(FacilityReportContext context) : base(context)
        {
        }
    }
}
