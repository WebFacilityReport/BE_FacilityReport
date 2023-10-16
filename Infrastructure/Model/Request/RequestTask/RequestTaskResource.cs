namespace Infrastructure.Model.Request.RequestTask;

public class RequestTaskResource
{
    public Guid CreatorId { get; set; }
    public Guid EmployeeId { get; set; }
    public string Title { get; set; }
    public string DescriptionJob { get; set; }
    public DateTime Deadline { get; set; }
    public string NameResource { get; set; }
    public string Description { get; set; }
    public int TotalQuantity { get; set; }
    public string Size { get; set; }
    public string? Image { get; set; }
}
