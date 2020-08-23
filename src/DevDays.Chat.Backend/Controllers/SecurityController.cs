using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Options;

namespace DevDays.Chat.Backend.Controllers
{
    [Route("security")]
    public class SecurityController : Controller
    {
        readonly IOptionsSnapshot<AuthenticationOptions> _optionsSnapshot;

        public SecurityController(IOptionsSnapshot<AuthenticationOptions> optionsSnapshot)
        {
            _optionsSnapshot = optionsSnapshot;
        }

        [Route("external")]
        public async Task<IActionResult> External()
        {
            var authInfo = await HttpContext.AuthenticateAsync("External");
            if (authInfo == null)
            {
                return NotFound();
            }

            var idToken = await HttpContext.GetTokenAsync("External", "id_token");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(idToken);

            var identity = new ClaimsIdentity("Local", JwtRegisteredClaimNames.UniqueName, "role");
            var nameClaim = token.Claims.SingleOrDefault(c => c.Type == "preferred_username");

            authInfo.Properties.Items.TryGetValue(".AuthScheme", out var authScheme);
            identity.AddClaim(new Claim("auth_scheme", authScheme));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, nameClaim.Value));

            string[] claimTypes = {"picture", "email", "sub"};
            foreach (var claimType in claimTypes)
            {
                var claim = token.Claims.FirstOrDefault(c => c.Type == claimType);
                if (claim != null)
                {
                    identity.AddClaim(new Claim(claimType, claim.Value));
                }
            }

            await HttpContext.SignInAsync(_optionsSnapshot.Value.DefaultAuthenticateScheme,
                new ClaimsPrincipal(identity));
            await HttpContext.SignOutAsync("External");


            return LocalRedirect("~/");
        }
    }
}
