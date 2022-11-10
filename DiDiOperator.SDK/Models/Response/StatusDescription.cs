using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    /// <summary>
    /// Описание возможного статуса
    /// </summary>
    public class StatusDescription
    {
        /// <summary>
        /// Id статуса
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Описание статуса
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
