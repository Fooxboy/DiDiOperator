using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    public class Module
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
