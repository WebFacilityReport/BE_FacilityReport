
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.IUnitofwork;
using Infrastructure.Model.Request.RequestFeedBack;
using Infrastructure.Model.Response.ResponseFeedBack;

namespace Infrastructure.IService.ServiceImplement;

public class FeedbackServiceImp : IFeedbackService
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public FeedbackServiceImp(IUnitofWork unitofWork, IMapper mapper)
    {
        _unitofWork = unitofWork;
        _mapper = mapper;
    }

    public async Task<ResponseFeedBack> CreateFeedBack(RequestFeedBack requestFeedBack)
    {
        var feedback = _mapper.Map<Feedback>(requestFeedBack);
        await _unitofWork.Account.GetById(requestFeedBack.AccountId);
        var equipment = await _unitofWork.Equiptment.GetById(requestFeedBack.EquipmentId);
        feedback.NumberFeedBack = 0;
        feedback.Status = STATUSFEEDBACK.ACTIVE.ToString();
        feedback.CreatedAt = DateTime.Now;
        equipment.Status = STATUSEQUIPMENT.FIX.ToString();
        _unitofWork.Equiptment.Update(equipment);
        _unitofWork.Feedback.Add(feedback);
        _unitofWork.Commit();
        return _mapper.Map<ResponseFeedBack>(feedback);
    }

    public async Task<ResponseFeedBack> GetById(Guid id)
    {
        var feedback = await _unitofWork.Feedback.GetById(id);
        return _mapper.Map<ResponseFeedBack>(feedback);
    }

    public async Task<List<ResponseFeedBack>> GetFeedBack()
    {
        var feedback = await _unitofWork.Feedback.GetAll();
        return _mapper.Map<List<ResponseFeedBack>>(feedback);
    }

    public Task<ResponseFeedBack> Update(Guid id, string status)
    {
        throw new NotImplementedException();
    }
}
