using Application.IGenericRepository;
using Domain.Entity;

namespace Application.Repository
{
    public interface ITaskRepository : IGenericRepository<Job>
    {
        Task<List<Job>> GetAll();
        Task<List<Job>> SearchTaskGetll(string query);
        Task<List<Job>> GetAllStaff(Guid staffId);
        Task<Job> GetById(Guid taskId);
        Task<Job> CheckExsitTaskbyHistoryWithEquipmentId(Guid equipmentId);
    }
}
