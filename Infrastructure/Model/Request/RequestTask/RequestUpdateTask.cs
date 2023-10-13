
namespace Infrastructure.Model.Request.RequestTask
{
    public class RequestUpdateTask
    {
        public Guid EmployeeId { get; set; }

        public string Title { get; set; }
        public string NameTask { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
