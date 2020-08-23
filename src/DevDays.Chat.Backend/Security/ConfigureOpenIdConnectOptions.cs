using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace DevDays.Chat.Backend.Security
{
    public class ConfigureOpenIdConnectOptions : IConfigureNamedOptions<OpenIdConnectOptions>
    {
        readonly IOptionsFactory<AuthOptions> _optionsFactory;

        public ConfigureOpenIdConnectOptions(IOptionsFactory<AuthOptions> optionsFactory)
        {
            _optionsFactory = optionsFactory;
        }

        public void Configure(OpenIdConnectOptions options)
        {
            throw new System.NotImplementedException();
        }

        public void Configure(string name, OpenIdConnectOptions options)
        {
            var authOptions = _optionsFactory.Create(name);
            options.Authority = authOptions.Authority;
            options.ClientId = authOptions.ClientId;
            options.ClientSecret = authOptions.ClientSecret;
            options.ResponseType = authOptions.ResponseType;
            options.GetClaimsFromUserInfoEndpoint = true;
            options.DisableTelemetry = true;
            options.SaveTokens = true;
            options.ResponseMode = OpenIdConnectResponseMode.Query;

            if (authOptions.Scope.Any())
            {
                options.Scope.Clear();
                foreach (var additionalScope in authOptions.Scope)
                {
                    options.Scope.Add(additionalScope);
                }
            }

            name = name.ToLowerInvariant();
            options.CallbackPath = new PathString($"/signin-{name}");
            options.RemoteSignOutPath = new PathString($"/signout-{name}");
            options.SignedOutCallbackPath = new PathString($"/signedout-callback-{name}");

            options.Events.OnRedirectToIdentityProvider += (m) =>
            {
                m.ProtocolMessage.Parameters.Add("claims",
                    @"{ ""id_token"": { ""preferred_username"": null, ""picture"": null, ""email"": null, ""email_verified"": null }}");

                return Task.CompletedTask;
            };
            options.Events.OnUserInformationReceived += (m) => { return Task.CompletedTask; };
        }
    }
}
