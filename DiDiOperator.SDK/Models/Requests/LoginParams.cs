using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Requests
{
    internal class LoginParams
    {
        [JsonPropertyName("title")]
        internal string Title { get; set; }

        [JsonPropertyName("password")]
        internal string Password { get; set; }
    }
}
