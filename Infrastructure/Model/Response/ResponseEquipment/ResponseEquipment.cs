using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Response.ResponseEquipment
{
    public class ResponseEquipment
    {
        public Guid EquipmentId { get; set; }
        public Guid ResourcesId { get; set; }
        public string Status { get; set; }
        public string Location { get; set; } 
        public DateTime CreatedAt { get; set; }
        public string? ImageEquip { get; set; }
    }
}
