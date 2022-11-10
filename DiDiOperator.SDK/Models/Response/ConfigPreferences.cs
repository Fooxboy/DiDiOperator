using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    public class ConfigPreferences
    {
        [JsonPropertyName("map")]
        public Map Map { get; set; }
    }
}
