﻿namespace Domain.Entity;

public partial class Notification
{
    public string NotificationId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public Guid AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}