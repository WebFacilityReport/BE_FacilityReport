

using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseTask;

namespace Infrastructure.IService
{
    public interface IJobService
    {
        Task<List<ResponseTask>> GetAllTask();
        Task<ResponseTask> GetTaskById(Guid taskId);
        Task<ResponseTask> AddTask(RequestTask requestTask);
        Task<ResponseTask> ChangeStatus(Guid taskId, string status);
        Task<ResponseTask> UpdateTask(Guid taskId, RequestUpdateTask requestUpdateTask);

    }
}
