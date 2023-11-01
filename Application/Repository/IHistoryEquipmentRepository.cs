using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface IHistoryEquipmentRepository : IGenericRepository<HistoryEquipment>
    {
        Task<List<HistoryEquipment>> GetAll();
        Task<HistoryEquipment> GetById(Guid id);
        Task<HistoryEquipment> SearchTaskById(Guid Taskid);
        Task<HistoryEquipment> GetByEquipmentId(Guid equipemntId);
    }
}
