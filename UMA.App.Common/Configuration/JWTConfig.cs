using System;

namespace UMA.App.Common.Configuration
{
    public class JWTConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public TimeSpan Life { get; set; }
    }
}