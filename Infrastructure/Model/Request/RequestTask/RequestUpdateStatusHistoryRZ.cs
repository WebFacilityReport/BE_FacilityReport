
namespace Infrastructure.Model.Request.RequestTask
{
    public class RequestUpdateStatusHistoryRZ
    {
        public Guid CreatorId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid EquipmentId { get; set; }
        public string Title { get; set; }
        public string DescriptionJob { get; set; }
        public DateTime Deadline { get; set; }
        public string ImageEquip { get; set; }

    }
}
