namespace Infrastructure.Model.Request.RequestFeedBack
{
    public class RequestFeedBack
    {
        public string Comment { get; set; } 
        public Guid AccountId { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
