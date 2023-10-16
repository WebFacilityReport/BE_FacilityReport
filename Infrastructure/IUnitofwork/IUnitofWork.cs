using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IUnitofwork
{
    public interface IUnitofWork
    {
        IAccountRepository Account { get; }
        IEquiptmentRepository Equiptment { get; }
        IFeedbackRepository Feedback { get; }
        IHistoryEquipmentRepository HistoryEquipment { get; }
        IImageRepository Image { get; }
        IResourceRepository Resource { get; }
        ITaskRepository Task { get; }
        void Commit();
    }
}
