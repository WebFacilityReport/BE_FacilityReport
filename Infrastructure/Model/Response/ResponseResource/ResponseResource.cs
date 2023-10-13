
namespace Infrastructure.Model.Response.ResponseResource;

public class ResponseResource
{
    public Guid ResourcesId { get; set; }
    public Guid TaskId { get; set; }

    public string NameResource { get; set; } 
    public string Description { get; set; } 
    public int UsedQuantity { get; set; }
    public int TotalQuantity { get; set; }
    public string Status { get; set; } 
    public string Size { get; set; } 
    public DateTime CreatedAt { get; set; }
    public string? Image { get; set; }

}
