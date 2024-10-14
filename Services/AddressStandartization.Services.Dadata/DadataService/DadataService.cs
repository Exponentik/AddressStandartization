using Newtonsoft.Json;
using System.Text;
using AddressStandartization.Services.DadataService.DTO;
using AddressStandartization.Services.Settings;
using AutoMapper;

namespace AddressStandartization.Services.DadataService
{
    public class DadataService : IDadataService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly DadataSettings dadataSettings;
        private readonly IMapper mapper;
        public DadataService(IHttpClientFactory httpClientFactory, DadataSettings dadataSettings, IMapper mapper)
        {
            this.httpClientFactory = httpClientFactory;
            this.dadataSettings = dadataSettings;
            this.mapper = mapper;
        }

        public async Task<AddressResponseDto> StandardizeAddressAsync(string rawAddress)
        {
            try
            {
                var httpClient = httpClientFactory.CreateClient();
                // Создаем содержимое запроса
                var requestContent = new StringContent($"[\"{rawAddress}\"]", Encoding.UTF8, "application/json");

                // Создаем HttpRequestMessage и добавляем заголовки
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://cleaner.dadata.ru/api/v1/clean/address"),
                    Content = requestContent
                };

                // Добавляем заголовки Authorization и X-Secret к HttpRequestMessage
                request.Headers.Add("Authorization", $"Token {dadataSettings.ApiKey}");
                request.Headers.Add("X-Secret", dadataSettings.SecretKey);

                // Отправляем запрос
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<AddressResponseDto>>(responseData);
                    return result.FirstOrDefault();
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
