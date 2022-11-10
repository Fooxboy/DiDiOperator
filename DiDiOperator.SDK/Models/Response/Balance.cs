using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiDiOperator.SDK.Models.Response
{
    /// <summary>
    /// Представление баланса
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// Год
        /// </summary>
        [JsonPropertyName("year")]
        public int Year { get; set; }

        /// <summary>
        /// Месяц
        /// </summary>
        [JsonPropertyName("month")]
        public int Month { get; set; }

        /// <summary>
        /// Входящий Saldo(????)
        /// </summary>
        [JsonPropertyName("incomingSaldo")]
        public double IncomingSaldo { get; set; }

        /// <summary>
        /// Денег на аккаунте
        /// </summary>
        [JsonPropertyName("accounts")]
        public double Accounts { get; set; }

        /// <summary>
        /// Пополнения
        /// </summary>
        [JsonPropertyName("payments")]
        public double Payments { get; set; }

        /// <summary>
        /// Изменения
        /// </summary>
        [JsonPropertyName("charges")]
        public int Charges { get; set; }

        /// <summary>
        /// Обратный
        /// </summary>
        [JsonPropertyName("reserve")]
        public int Reserve { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        /// <summary>
        /// Покучить текущий актуальный баланс в нормальном виде.
        /// </summary>
        [JsonIgnore]
        public double CurrentBalance => IncomingSaldo + Payments - Accounts - Charges;
    }
}
