using Application.IGenericRepository;
using Domain.Entity;


namespace Application.Repository
{
    public interface IEquiptmentRepository : IGenericRepository<Equipment>
    {
        Task<List<Equipment>> GetEquipment();
        Task<List<Equipment>> SearchGetEquipment(string query);
        Task<Equipment> GetById(Guid id);
        Task<List<Equipment>> GetallEquipmentFix();
        Task<List<Equipment>> GetallEquipmentActive();

    }
}
