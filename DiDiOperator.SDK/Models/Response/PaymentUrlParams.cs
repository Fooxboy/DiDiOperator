using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiDiOperator.SDK.Models.Response
{
    public class PaymentUrlParams
    {
        [JsonPropertyName("map")]
        public MapUrl Map { get; set; }
    }
}
