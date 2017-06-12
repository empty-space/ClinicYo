using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicYo.Authorization
{
    public class UserCreatentials
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public TimeSpan ExpiresIn { get; set; } = new TimeSpan(1, 0, 0, 0);//1day

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "Bearer";

        [JsonProperty("email")]
        public string Login { get; set; }

        public List<string>  MenuNames { get; set; }
    }
}
