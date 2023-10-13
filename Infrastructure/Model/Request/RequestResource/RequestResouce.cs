
namespace Infrastructure.Model.Request.RequestResource;

public class RequestResouce
{
    public Guid TaskId { get; set; }
    public string NameResource { get; set; }
    public string Description { get; set; }
    public int TotalQuantity { get; set; }
    public string Size { get; set; }
    public string? Image { get; set; }
}
