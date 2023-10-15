using Application.IGenericRepository;
using Domain.Entity;


namespace Application.Repository
{
    public interface IEquiptmentRepository : IGenericRepository<Equipment>
    {
        Task<List<Equipment>> GetEquipment();
        Task<Equipment> GetById(Guid id);
    }
}
