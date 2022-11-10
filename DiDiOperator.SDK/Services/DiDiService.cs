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

        public void SetToken(string token)
        {
            this._token = token;

            _httpClient.DefaultRequestHeaders.Authorization =
                     new AuthenticationHeaderValue("Bearer", _token);
        }

        public async Task<Status> GetStatusAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var status = await _httpClient.GetFromJsonAsync<List<Status>>("status");

            return status?.FirstOrDefault();
        }

        public async Task<Status> GetStatusListAsync()
        {
            if (_token is null) throw new TokenNotSetException();

            var status = await _httpClient.GetFromJsonAsync<List<Status>>("statusList");

            return status?.FirstOrDefault();
        }
    }
}
