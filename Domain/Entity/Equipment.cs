using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Equipment
    {
        public Equipment()
        {
            Feedbacks = new HashSet<Feedback>();
            HistoryEquipments = new HashSet<HistoryEquipment>();
        }

        public Guid EquipmentId { get; set; }
        public string Status { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? ImageEquip { get; set; }
        public Guid ResourcesId { get; set; }

        public virtual Resource Resources { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<HistoryEquipment> HistoryEquipments { get; set; }
    }
}
