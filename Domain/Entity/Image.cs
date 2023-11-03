using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Image
    {
        public Guid ImageId { get; set; }
        public string NameImage { get; set; } = null!;
        public DateTime DateImgae { get; set; }
        public string Status { get; set; } = null!;
        public Guid FeedbackId { get; set; }

        public virtual Feedback Feedback { get; set; } = null!;
    }
}
