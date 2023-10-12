using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model.Request.RequestAccount
{
    public class RequestLogin
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
