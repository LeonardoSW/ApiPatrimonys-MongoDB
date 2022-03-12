using Newtonsoft.Json;

namespace hvn_project.Models
{
    public class ItemUpdate
    {
        [JsonProperty("patrimonyNumber")]
        public string PatrimonyNumber { get; set; } 

        [JsonProperty("status")]
        public PatrimonyStatus Status { get; set; }
    }
}
