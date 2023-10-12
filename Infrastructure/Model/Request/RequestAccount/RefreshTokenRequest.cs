using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Request.RequestAccount
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        public string UserEmail { get; set; }
    }
}
