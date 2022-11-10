using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiDiOperator.SDK.Models.Response
{
    public class Map
    {
        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("speed")]
        public string Speed { get; set; }
    }
}
