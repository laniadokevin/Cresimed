
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TestYourself.Core.Entities.Database;

namespace TestYourself.Web
{
    public class SecurityManager
    {
        public async void SignIn(HttpContext httpContext, User user)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(user), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> getUserClaims(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            user.UserRoles.ToList().ForEach(ac =>
            {
                claims.Add(new Claim(ClaimTypes.Role, ac.Role.Name));
            });
            return claims;
        }
    }
}