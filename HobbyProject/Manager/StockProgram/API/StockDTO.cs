using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HobbyProject.Manager.StockProgram.API
{
    public class BestMatch
    {
        [JsonProperty("1. symbol")]
        public string _1symbol { get; set; }

        [JsonProperty("2. name")]
        public string _2name { get; set; }

        [JsonProperty("3. type")]
        public string _3type { get; set; }

        [JsonProperty("4. region")]
        public string _4region { get; set; }

        [JsonProperty("5. marketOpen")]
        public string _5marketOpen { get; set; }

        [JsonProperty("6. marketClose")]
        public string _6marketClose { get; set; }

        [JsonProperty("7. timezone")]
        public string _7timezone { get; set; }

        [JsonProperty("8. currency")]
        public string _8currency { get; set; }

        [JsonProperty("9. matchScore")]
        public string _9matchScore { get; set; }
    }

    public class Root
    {
        public List<BestMatch> bestMatches { get; set; }
    }
}
