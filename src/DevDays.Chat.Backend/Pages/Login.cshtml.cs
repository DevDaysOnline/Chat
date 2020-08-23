using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace DevDays.Chat.Backend.Pages
{
    public class LoginModel : PageModel
    {
        public async Task<IActionResult> OnGet(string returnUrl = "~/")
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            if (!Url.IsLocalUrl(returnUrl))
            {
                returnUrl = "~/";
            }

            var authenticationProperties = new AuthenticationProperties()
            {
                RedirectUri = Url.Action("External", "Security"),
                Items = {{"returnUrl", returnUrl}}
            };

            return new ChallengeResult("Twitch", authenticationProperties);
        }
    }
}
