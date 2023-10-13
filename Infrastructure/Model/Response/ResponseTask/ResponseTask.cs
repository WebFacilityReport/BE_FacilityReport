
namespace Infrastructure.Model.Response.ResponseTask;

public class ResponseTask
{
    public Guid TaskId { get; set; }
    public Guid CreatorId { get; set; }
    public Guid EmployeeId { get; set; }
    public string NameTask { get; set; }

    public string emailEmployee { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Deadline { get; set; }

}
