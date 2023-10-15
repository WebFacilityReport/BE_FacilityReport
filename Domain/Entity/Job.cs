using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Job
    {
        public Job()
        {
            HistoryEquipments = new HashSet<HistoryEquipment>();
            Resources = new HashSet<Resource>();
        }

        public Guid JobId { get; set; }
        public string Status { get; set; } = null!;
        public string NameTask { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; } = null!;
        public string Title { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public Guid CreatorId { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Account Creator { get; set; } = null!;
        public virtual Account Employee { get; set; } = null!;
        public virtual ICollection<HistoryEquipment> HistoryEquipments { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
