using Newtonsoft.Json;
using System;

namespace hvn_project.Models
{
    public class ItemCreate
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public PatrimonyStatus Status { get; set; }

        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("updateDate")]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("patrimonyNumber")]
        public string PatrimonyNumber { get; set; }
    }
}
