
namespace Infrastructure.Model.Response.ResponseAccount
{
    public class AuthenResponseMessToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public long Expiration { get; set; }

    }
}
