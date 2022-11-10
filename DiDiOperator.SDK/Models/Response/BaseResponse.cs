using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    public class BaseResponse
    {
        /// <summary>
        /// Сообщение об ошибке, если оно есть.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
