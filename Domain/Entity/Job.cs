using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Job
    {
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
        public virtual HistoryEquipment? HistoryEquipment { get; set; }
        public virtual Resource? Resource { get; set; }
    }
}
