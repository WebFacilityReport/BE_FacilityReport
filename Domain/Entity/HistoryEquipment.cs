using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class HistoryEquipment
    {
        public Guid HistoryId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;
        public string NameHistory { get; set; } = null!;
        public Guid EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; } = null!;
    }
}
