namespace Infrastructure.Model.Request.RequestTask
{
    public class RequestTask
    {
        public string Title { get; set; }
        public string NameTask { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
