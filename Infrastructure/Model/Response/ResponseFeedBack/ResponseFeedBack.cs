

namespace Infrastructure.Model.Response.ResponseFeedBack
{
    public class ResponseFeedBack
    {
        public Guid FeedBackId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } 
        public string Comment { get; set; } 
        public int NumberFeedBack { get; set; }
        public Guid? AccountId { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
