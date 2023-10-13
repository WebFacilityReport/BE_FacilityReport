using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Resource
    {
        public Resource()
        {
            Equipment = new HashSet<Equipment>();
        }

        public Guid ResourcesId { get; set; }
        public string NameResource { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int UsedQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public string Status { get; set; } = null!;
        public string Size { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? Image { get; set; }
        public Guid JobId { get; set; }

        public virtual Job Job { get; set; } = null!;
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
