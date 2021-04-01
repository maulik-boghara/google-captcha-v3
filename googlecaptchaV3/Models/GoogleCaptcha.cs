using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoogleCaptchaV3.Models
{
    public class GoogleCaptcha
    {

        [JsonProperty("success")]
        public string Success { get; set; }
        
        [JsonProperty("score")]
        public string Score { get; set; }
        
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("challenge_ts")]
        public string TimeStamp { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("error-codes")]
        public string ErrorCodes { get; set; }
    }
}