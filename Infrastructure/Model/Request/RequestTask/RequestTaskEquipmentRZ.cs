﻿
namespace Infrastructure.Model.Request.RequestTask;

public class RequestTaskEquipmentRZ
{

    public Guid CreatorId { get; set; }
    public Guid EmployeeId { get; set; }
    public string Title { get; set; }
    public string DescriptionJob { get; set; }
    public DateTime Deadline { get; set; }
    public Guid ResourceId { get; set; }
    public string Location { get; set; }
    public string ImageEquip { get; set; }
}

