using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Requests
{
    public class LoginParams
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
