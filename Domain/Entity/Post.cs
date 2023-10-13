using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Post
    {
        public Post()
        {
            Feedbacks = new HashSet<Feedback>();
            Images = new HashSet<Image>();
        }

        public Guid PostId { get; set; }
        public string Description { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = null!;
        public string? Image { get; set; }
        public Guid AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
