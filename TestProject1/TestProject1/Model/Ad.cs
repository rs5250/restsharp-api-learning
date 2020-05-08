using System;
using Newtonsoft.Json;

namespace TestProject1.Model
{
    public class Ad
    {
        
            [JsonProperty("company")]
            public string Company { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
    }
