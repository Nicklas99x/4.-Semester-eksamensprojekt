using Contract;
using Contract.InterfaceServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ModelEvaluationService : IModelEvaluationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public ModelEvaluationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            _options = new JsonSerializerOptions();
            _httpClient.BaseAddress = new Uri("https://localhost:44365");
        }
        async Task<ModelEvaluationDto> IModelEvaluationService.GetModelScore()
        {
            using (var response = await _httpClient.GetAsync("/ModelAccuracy", HttpCompletionOption.ResponseHeadersRead))
            {
                response.StatusCode.ToString();
                var stream = await response.Content.ReadAsStreamAsync();                
                var modelScore = await JsonSerializer.DeserializeAsync<ModelEvaluationDto>(stream, _options);
                return modelScore;                
            }
        }
    }
}
