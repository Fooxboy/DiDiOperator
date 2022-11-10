using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    /// <summary>
    /// Текущий статус договора пользователя
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Id пользвателя
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Номер договора
        /// </summary>
        [JsonPropertyName("contractId")]
        public int ContractId { get; set; }

        /// <summary>
        /// Тип статуса, все статусы можно узнать сделав запрос к GetStatusList
        /// </summary>
        [JsonPropertyName("status")]
        public int StatusType { get; set; }

        /// <summary>
        /// Начало статуса
        /// </summary>
        [JsonPropertyName("dateFrom")]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Окончание статуса
        /// </summary>
        [JsonPropertyName("dateTo")]
        public DateTime DateTo { get; set; }

        /// <summary>
        /// Комментарий к статусу
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
