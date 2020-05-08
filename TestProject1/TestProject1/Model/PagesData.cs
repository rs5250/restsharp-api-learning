using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestProject1.Model
{
    public class PagesData
    {
        
            [JsonProperty("page")]
            public long Page { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("ad")]
        public List<Ad> Ad { get; set; }
    }
    
    }
