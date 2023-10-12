using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public partial class Image
    {
        public Guid ImageId { get; set; }
        public string NameImage { get; set; } = null!;
        public string DateImgae { get; set; } = null!;
        public string Status { get; set; } = null!;
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
