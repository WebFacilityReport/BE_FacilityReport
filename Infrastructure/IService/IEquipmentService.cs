
using Domain.Entity;

namespace Infrastructure.IService
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetEquipment();
        Task<List<Equipment>> GetEquipmentAsync();
    }
}
