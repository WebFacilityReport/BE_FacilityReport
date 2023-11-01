
using Domain.Entity;
using Infrastructure.Model.Response.ResponseEquipment;

namespace Infrastructure.IService
{
    public interface IEquipmentService
    {
        Task<List<ResponseEquipment>> GetEquipment();
        Task<List<ResponseEquipment>> GetEquipmentFix();
        Task<ResponseEquipment> GetById(Guid equipmentId);
        Task<ResponseEquipment> ChangeStatus(Guid id, string v);
    }
}
