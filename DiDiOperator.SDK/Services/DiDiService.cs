using DiDiOperator.SDK.Exceptions;
using DiDiOperator.SDK.Models.Requests;
using DiDiOperator.SDK.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiDiOperator.SDK.Services
{
    /// <summary>
    /// Сервис для запросов к lk.di-di.ru
    /// </summary>
    public class DiDiService
    {
        //текущий токен авторизации.
        private string? _token = null;

        //текущий хттп клиент.
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Сервис для запросов к lk.di-di.ru
        /// </summary>
        /// <param name="client">хттп клиент</param>
        public DiDiService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://lk.di-di.ru/api");
        }

        /// <summary>
        /// Войти по логину и паролю и получить токен.
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Токен доступа</returns>
        public async Task<Auth> LoginAsync(string login, string password)
        {
            if (_token is not null) return new Auth() { Type = "bearer", Token = _token };

            var loginParams = new LoginParams()
            {
                Title = login,
                Password = password
            };

            var httpResponse = await _httpClient.PostAsJsonAsync<LoginParams>("login", loginParams);

            httpResponse.EnsureSuccessStatusCode();

            var response = await httpResponse.Content.ReadAsStringAsync();

            var auth = JsonSerializer.Deserialize<Auth>(response);

            if (auth is null) throw new LoginErrorException("Сервер не отправил никаких данных в ответ.");

            if (auth.Message is not null) throw new LoginErrorException(auth.Message);

            this.SetToken(auth.Token);

            return auth;
        }

        /// <summary>
        /// Установить токен, если Вы его уже ранее получали
        /// </summary>
        /// <param name="token">Токен</param>
        public void SetToken(string token)
        {
            this._token = token;

            _httpClient.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Bearer", _token);
        }

        /// <summary>
        /// Получить текущий статус договора
        /// </summary>
        /// <returns>Статус</returns>
        /// <exception cref="TokenNotSetException">Не установлен токен</exception>
        public async Task<Status> GetStatusAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var status = await _httpClient.GetFromJsonAsync<List<Status>>("status");

            return status?.FirstOrDefault();
        }

        /// <summary>
        /// Получить все возможные статусы и их описание
        /// </summary>
        /// <returns>Массив описаний статусов</returns>
        /// <exception cref="TokenNotSetException">Не установлен токен</exception>
        public async Task<List<StatusDescription>> GetStatusListAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var statusDescriptions = await _httpClient.GetFromJsonAsync<List<StatusDescription>>("statusList");

            return statusDescriptions;
        }

        /// <summary>
        /// Получить текущий баланс
        /// </summary>
        /// <returns>Текщий баланс</returns>
        /// <exception cref="TokenNotSetException">Не установлен токен</exception>
        public async Task<Balance> GetBalanceAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var balance = await _httpClient.GetFromJsonAsync<Balance>("balance");

            return balance;
        }

        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        /// <returns>Текущий пользователь</returns>
        /// <exception cref="TokenNotSetException">Не установлен токен</exception>
        public async Task<User> GetUserAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var user = await _httpClient.GetFromJsonAsync<User>("user");

            return user;
        }

        /// <summary>
        /// Получить текущие тарифы.
        /// </summary>
        /// <returns>Тарифы</returns>
        /// <exception cref="TokenNotSetException">не установлен токен</exception>
        public async Task<List<Tariff>> GetCurrentTariffsAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var tariffs = await _httpClient.GetFromJsonAsync<List<Tariff>>("currentTariff");

            return tariffs;
        }

        /// <summary>
        /// Получить доступные для подключения тарифы
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TokenNotSetException"></exception>
        public async Task<List<TariffDescription>> GetTariffsAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var tariffs = await _httpClient.GetFromJsonAsync<List<TariffDescription>>("tarifs");

            return tariffs;
        }

        /// <summary>
        /// Получить ссылку для пополения счета.
        /// </summary>
        /// <param name="paymentModule">Модуль пополнения</param>
        /// <param name="amount">Количество рублей (целое число)</param>
        /// <returns>Ссылка для пополнения</returns>
        /// <exception cref="ArgumentException">Ошибка сервера</exception>
        public async Task<PaymentUrl> GetPaymentLinkAsync(Module paymentModule, int amount)
        {
            var paymentParams = new PaymentParams()
            {
                ModuleId = paymentModule.Id,
                ModuleName = paymentModule.Name,
                Amount = amount.ToString()
            };
           
            var httpResponse = await _httpClient.PostAsJsonAsync<PaymentParams>("payment", paymentParams);

            httpResponse.EnsureSuccessStatusCode();

            var response = await httpResponse.Content.ReadAsStringAsync();

            var payment = JsonSerializer.Deserialize<PaymentUrl>(response);

            if (payment is null) throw new ArgumentException("Сервер не отправил никаких данных в ответ.");

            return payment;
        }
    }
}
