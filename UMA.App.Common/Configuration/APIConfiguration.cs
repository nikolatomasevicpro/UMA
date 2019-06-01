using System.Collections.Generic;

namespace UMA.App.Common.Configuration
{
    public class APIConfiguration
    {
        private static APIConfiguration _instance = new APIConfiguration();

        private APIConfiguration() { }


        public static APIConfiguration Intance => _instance;

        public Dictionary<string, string> ConnectionStrings { get; set; }
        public Dictionary<string, List<string>> PoliciesMapping { get; set; }
        public JWTConfig JwtConfig { get; set; }
    }
}
