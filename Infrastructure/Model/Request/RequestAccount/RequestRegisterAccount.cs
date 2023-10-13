using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Request.RequestAccount
{
    public class RequestRegisterAccount
    {
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public string Address { get; set; } 
        public DateTime Birthday { get; set; }
    }
}
