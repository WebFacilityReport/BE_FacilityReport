
using AutoMapper;
using Domain.Entity;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Response.ResponseEquipment;

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
    }
}
