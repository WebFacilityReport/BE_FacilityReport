using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Response.ResponseEquipment;
using Infrastructure.Model.Response.ResponseResource;

namespace Infrastructure.IService.ServiceImplement
{
    public class EquipmentServiceImp : IEquipmentService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public EquipmentServiceImp(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<ResponseEquipment> ChangeStatus(Guid id, string v)
        {
            var equipment = await _unitofWork.Equiptment.GetById(id);
            if (equipment.Status.Equals(STATUSEQUIPMENT.ACTIVE.ToString()))
            {
                equipment.Status = v;
                _unitofWork.Equiptment.Update(equipment);
                _unitofWork.Commit();
            }
            return _mapper.Map<ResponseEquipment>(equipment);
        }

        public async Task<ResponseEquipment> GetById(Guid equipmentId)
        {
            var equipment = await _unitofWork.Equiptment.GetById(equipmentId);
            return _mapper.Map<ResponseEquipment>(equipment);
        }

        public async Task<List<ResponseEquipment>> GetEquipment()
        {
            var equipment = await _unitofWork.Equiptment.GetEquipment();
            return _mapper.Map<List<ResponseEquipment>>(equipment);
        }

        public async Task<List<ResponseEquipment>> GetEquipmentActive()
        {
            var equipment = await _unitofWork.Equiptment.GetallEquipmentActive();
            return _mapper.Map<List<ResponseEquipment>>(equipment);
        }

        public async Task<List<ResponseEquipment>> GetEquipmentFix()
        {
            var equipment = await _unitofWork.Equiptment.GetallEquipmentFix();
            return _mapper.Map<List<ResponseEquipment>>(equipment);
        }

        public async Task<List<ResponseEquipment>> SearchGetEquipment(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                var tasks = await _unitofWork.Equiptment.GetEquipment();
                return _mapper.Map<List<ResponseEquipment>>(tasks);
            }
            var equipment = await _unitofWork.Equiptment.SearchGetEquipment(query);
            return _mapper.Map<List<ResponseEquipment>>(equipment);
        }
    }
}
