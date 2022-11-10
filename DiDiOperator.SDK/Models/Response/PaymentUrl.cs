using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    /// <summary>
    /// Модель ссылки пополнения
    /// </summary>
    public class PaymentUrl
    {
        /// <summary>
        /// Режим открытия ссылки
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// Дополнительные параметры
        /// </summary>
        [JsonPropertyName("params")]
        public PaymentUrlParams Params { get; set; }

        /// <summary>
        /// Возвращаемое значние
        /// </summary>
        [JsonPropertyName("return")]
        public object Return { get; set; }

        /// <summary>
        /// Url для пополнения
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
