using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    /// <summary>
    /// Описание тарифа
    /// </summary>
    public class TariffDescription
    {
        /// <summary>
        /// Id тарифа
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Заголовок тарифа
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
