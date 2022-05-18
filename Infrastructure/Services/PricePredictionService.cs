using Contract.Dto;
using Contract.InterfaceServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PricePredictionService : IPricePredictionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public PricePredictionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _httpClient.BaseAddress = new Uri("https://localhost:44365");
        }
        async Task<PricePredictionDto> IPricePredictionService.PredictPrice(PricePredictionDto pricePredictionDto)
        {
            var json = JsonConvert.SerializeObject(pricePredictionDto);
            var httpcontent = new StringContent(json, Encoding.UTF8, "application/json");
            using (var response = await _httpClient.PostAsync("/Prediction", httpcontent))
            {
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStreamAsync();
                return await System.Text.Json.JsonSerializer.DeserializeAsync<PricePredictionDto>(result, _options);
            }
        }
        async Task<List<PredictedPriceDto>> IPricePredictionService.GetPredictedPrices()
        {
            using (var response = await _httpClient.GetAsync("/GetPricePrediction", HttpCompletionOption.ResponseHeadersRead))
            {
                response.StatusCode.ToString();
                var stream = await response.Content.ReadAsStreamAsync();
                var modelScore = await System.Text.Json.JsonSerializer.DeserializeAsync<List<PredictedPriceDto>>(stream, _options);
                return modelScore;
            }
        }
    }
}
