using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDiOperator.SDK.Models.Requests
{
    internal class PaymentParams
    {
        /// <summary>
        /// Id модуля пополнения
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// Имя модуля пополнения
        /// </summary>
        public string ModuleName { get; set; } 

        /// <summary>
        /// Количество рублей, которое необходимо пополнить баланс.
        /// </summary>
        public string Amount { get; set; }
    }
}
