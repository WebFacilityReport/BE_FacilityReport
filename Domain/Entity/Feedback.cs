using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Feedback
    {
        public Guid FeedBackId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int NumberFeedBack { get; set; }
        public Guid PostId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid EquipmentId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Equipment Equipment { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
    }
}
