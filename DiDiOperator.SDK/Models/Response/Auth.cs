
using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    /// <summary>
    /// Результат ответа авторизации
    /// </summary>
    public class Auth : BaseResponse
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Сам токен
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; } 
    }
}
