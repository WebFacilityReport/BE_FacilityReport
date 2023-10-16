using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseTask;

namespace Infrastructure.IService
{
    public interface IJobService
    {
        Task<List<ResponseTask>> GetAllTask();
        Task<ResponseTask> GetTaskById(Guid taskId);
        Task<ResponseTask> AddTaskResource(RequestTaskResource requestTaskResource);
        Task<ResponseTask> AddTaskEquipmentByResourceId(RequestTaskEquipment requestTaskEquipment);
        Task<ResponseTask> ChangeStatus(Guid taskId, string status);
        Task<ResponseTask> UpdateTask(Guid taskId, RequestUpdateTask requestUpdateTask);
        Task<ResponseTask> UpdateHistoryEquipment(RequestUpdateStatusHistory requestUpdateStatusHistory);

    }
}
