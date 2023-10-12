using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.RepositoryImp
{
    public class FeedbackRepositoryImp : GenericRepositoryImp<Feedback>,IFeedbackRepository
    {
        public FeedbackRepositoryImp(FacilityReportContext context) : base(context)
        {
        }
    }
}
