using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    public class MapUrl
    {
        [JsonPropertyName("formUrl")]
        public string FormUrl { get; set; }

        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }
    }
}
