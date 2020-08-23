using System;
using System.Collections.Generic;

namespace DevDays.Chat.Backend.Security
{
    public class AuthOptions
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ResponseType { get; set; } = "code";

        public string[] Scope { get; set; } = Array.Empty<string>();
    }
}
