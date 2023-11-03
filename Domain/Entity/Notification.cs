namespace Domain.Entity;

public partial class Notification
{
    public Guid NotificationId { get; set; } 

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;
    public DateTime CreateAt { get; set; } 

    public Guid AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}
