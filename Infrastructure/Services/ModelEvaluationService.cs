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
        //Adding httpclientfactory and jsonoptions to make http requests
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public ModelEvaluationService(IHttpClientFactory httpClientFactory)
        {
            //Constructor injection of interface IHttpClientFactory
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            //Need this to display the result of the deserialized Dto
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            
            _httpClient.BaseAddress = new Uri("https://localhost:44365");
        }
        //GetRequest
        async Task<ModelEvaluationDto> IModelEvaluationService.GetModelScore()
        {
            //Perform a HttpGet request on the endpoint https://localhost:44365/ModelAccuracy
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
