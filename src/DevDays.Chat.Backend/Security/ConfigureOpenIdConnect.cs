using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace DevDays.Chat.Backend.Security
{
    public static class ConfigureOpenIdConnect
    {
        public static AuthenticationBuilder AddOpenIdConnectProvider(this AuthenticationBuilder builder, string schema,
            IConfiguration configuration)
        {
            var section = configuration.GetSection("Authentication");
            builder.Services.AddOptions<AuthOptions>(schema).Bind(section.GetSection(schema));
            builder.AddOpenIdConnect(schema, o => { });
            builder.Services.TryAddEnumerable(
                ServiceDescriptor
                    .Singleton<IConfigureOptions<OpenIdConnectOptions>, ConfigureOpenIdConnectOptions>());
            return builder;
        }
    }
}
