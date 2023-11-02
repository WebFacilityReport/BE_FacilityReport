using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Request.RequestFeedBack
{
    public class RequestFeedBackRZ
    {
        public Guid AccountId { get; set; }
        public string Comment { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
