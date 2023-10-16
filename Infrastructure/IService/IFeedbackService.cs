

using Infrastructure.Model.Request.RequestFeedBack;
using Infrastructure.Model.Response.ResponseFeedBack;

namespace Infrastructure.IService
{
    public interface IFeedbackService
    {
        Task<ResponseFeedBack> CreateFeedBack(RequestFeedBack requestFeedBack);
        Task<List<ResponseFeedBack>> GetFeedBack();
        Task<ResponseFeedBack> GetById(Guid id);
        Task<ResponseFeedBack> Update(Guid id, string status);

    }
}
