using System.Text.Json.Serialization;

namespace DiDiOperator.SDK.Models.Response
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Никнейм или номер договора
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Группа пользователя
        /// </summary>
        [JsonPropertyName("groups")]
        public long Groups { get; set; }

        /// <summary>
        /// Пароль текущего пользователя
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        [JsonPropertyName("dateFrom")]
        public string DateFrom { get; set; }

        /// <summary>
        /// Дата отключения
        /// </summary>
        [JsonPropertyName("dateTo")]
        public object DateTo { get; set; }

        /// <summary>
        /// Режим баланса
        /// </summary>
        [JsonPropertyName("balanceMode")]
        public int BalanceMode { get; set; }

        /// <summary>
        /// Группа пользователя
        /// </summary>
        [JsonPropertyName("paramGroupId")]
        public int ParamGroupId { get; set; }

        /// <summary>
        /// Тип пользователя
        /// </summary>
        [JsonPropertyName("personType")]
        public int PersonType { get; set; }

        /// <summary>
        /// ФИО или другая информация о владельце
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Скрытый аккаунт
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// Супер ID
        /// </summary>
        [JsonPropertyName("superCid")]
        public int SuperCid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("dependSubList")]
        public string DependSubList { get; set; }

        /// <summary>
        /// Статус договора пользователя
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Время смены статуса
        /// </summary>
        [JsonPropertyName("statusTimeChange")]
        public string StatusTimeChange { get; set; }

        /// <summary>
        /// Тип паттерна заголовка
        /// </summary>
        [JsonPropertyName("titlePatternId")]
        public int TitlePatternId { get; set; }

        /// <summary>
        /// Режим баланса
        /// </summary>
        [JsonPropertyName("balanceSubMode")]
        public int BalanceSubMode { get; set; }

        /// <summary>
        /// ИД домена????
        /// </summary>
        [JsonPropertyName("domainId")]
        public int DomainId { get; set; }

        /// <summary>
        /// хз
        /// </summary>
        [JsonPropertyName("dependSub")]
        public bool DependSub { get; set; }

        /// <summary>
        /// Лимит баланса
        /// </summary>
        [JsonPropertyName("balanceLimit")]
        public int BalanceLimit { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        [JsonPropertyName("sub")]
        public bool Sub { get; set; }

        /// <summary>
        /// Является ли пользователь суперпользователем
        /// </summary>
        [JsonPropertyName("super")]
        public bool Super { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        [JsonPropertyName("independSub")]
        public bool IndependSub { get; set; }
    }
}
