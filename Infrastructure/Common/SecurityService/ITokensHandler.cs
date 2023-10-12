using Domain.Entity;
using Infrastructure.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.SecurityService
{
    public interface ITokensHandler
    {
        AccessToken CreateAccessToken(Account account);
        RefreshToken TakeRefreshToken(string token, string userName);
        void RevokeRefreshToken(string token, string userName);
        Task<string> ClaimsFromToken(string token);
    }
}
