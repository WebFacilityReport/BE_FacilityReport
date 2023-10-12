using Application.IGenericRepository.GeneircRepositoryImp;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.RepositoryImp
{
    public class HistoryEquipmentRepositoryImp : GenericRepositoryImp<HistoryEquipment>,IHistoryEquipmentRepository
    {
        public HistoryEquipmentRepositoryImp(FacilityReportContext context) : base(context)
        {
        }
    }
}
