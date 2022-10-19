using System.Security.Claims;

namespace wallotto_server.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static long GetIdentityId(this ClaimsPrincipal claimsPrincipal)
        {
            return
                Convert.ToInt64(claimsPrincipal.Claims.Single(c => c.Type == "Id").Value);
        }
    }
}
