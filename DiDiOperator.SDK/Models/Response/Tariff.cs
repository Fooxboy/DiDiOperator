using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    public class Tariff
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("personal")]
        public bool Personal { get; set; }

        [JsonPropertyName("webTitle")]
        public string WebTitle { get; set; }

        [JsonPropertyName("contractId")]
        public int ContractId { get; set; }

        [JsonPropertyName("dateFrom")]
        public DateTime DateFrom { get; set; }

        [JsonPropertyName("dateTo")]
        public DateTime? DateTo { get; set; }

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("entityMid")]
        public int EntityMid { get; set; }

        [JsonPropertyName("entityId")]
        public int EntityId { get; set; }

        [JsonPropertyName("treeId")]
        public int TreeId { get; set; }

        [JsonPropertyName("tariffPlanId")]
        public int TariffPlanId { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("replacedFromContractTariffId")]
        public int ReplacedFromContractTariffId { get; set; }

        [JsonPropertyName("replacedFromTariffId")]
        public int ReplacedFromTariffId { get; set; }

        [JsonPropertyName("canCancel")]
        public bool CanCancel { get; set; }

        [JsonPropertyName("availableChangeTariffIds")]
        public object AvailableChangeTariffIds { get; set; }

        [JsonPropertyName("availableChangeDates")]
        public object AvailableChangeDates { get; set; }

        [JsonPropertyName("tariffPlanComment")]
        public string TariffPlanComment { get; set; }

        [JsonPropertyName("modules")]
        public List<Module> Modules { get; set; }

        [JsonPropertyName("config")]
        public string Config { get; set; }

        [JsonPropertyName("configPreferences")]
        public ConfigPreferences ConfigPreferences { get; set; }
    }
}
