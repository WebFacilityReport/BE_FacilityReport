

using Infrastructure.Model.Request.RequestFeedBack;
using Infrastructure.Model.Response.ResponseFeedBack;

namespace Infrastructure.IService
{
    public interface IFeedbackService
    {
        Task<ResponseFeedBack> CreateFeedBack(RequestFeedBack requestFeedBack);
        Task<ResponseFeedBack> CreateFeedBackRz(RequestFeedBackRZ requestFeedBackrz);
        Task<List<ResponseFeedBack>> GetFeedBack();
        Task<List<ResponseFeedBack>> GetFeedBackbyAccountRZ(Guid accountid);
        Task<ResponseFeedBack> GetById(Guid id);
        Task<ResponseFeedBack> Update(Guid id, string status);

    }
}
