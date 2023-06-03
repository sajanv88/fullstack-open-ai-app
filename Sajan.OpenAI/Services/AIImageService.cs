

using Flurl.Http;
using Newtonsoft.Json;
using Sajan.OpenAI.Dtos;
using Flurl.Http.Configuration;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Options;
namespace Sajan.OpenAI.Services
{
    public class AIImageService 
    {
        private readonly ILogger<AIImageService> _logger;
		private readonly IOptions<ConfigurationOptions> _options;
        private readonly IFlurlClient _flurlClient;
        private readonly string _openAIEndpoint;
        private readonly string _openAIToken;

        public AIImageService(ILogger<AIImageService> logger, IOptions<ConfigurationOptions> options, IFlurlClientFactory flurlClient)
        {
            _logger = logger;
			_options = options;
            _openAIEndpoint = _options.Value.Url;
            _openAIToken = _options.Value.Token;

			_flurlClient = flurlClient.Get(_openAIEndpoint);

            _logger.LogInformation("AIImageService initalized.");
        }

        public async Task<AIImageDto> CreateImageAsync(AIImageParameterDto newAIImageParameter)
        {
            var input = JsonConvert.SerializeObject(newAIImageParameter, new JsonSerializerSettings{ ContractResolver = new CamelCasePropertyNamesContractResolver()});
			_logger.LogInformation($"Api token {_openAIToken}");
			_logger.LogInformation($"Input received: {input}");

            var payload = JsonConvert.DeserializeObject(input, new JsonSerializerSettings{ ContractResolver = new CamelCasePropertyNamesContractResolver()});
            var	data = await _flurlClient
					.Request("/images/generations").WithHeader("content-type", "application/json")
					.WithHeader("Authorization", $"Bearer {_openAIToken}")
					.PostJsonAsync(payload);
			var response = await data.GetJsonAsync<AIImageDto>();
			_logger.LogInformation($"Response received: {response}");
			return response;
        }
    }
}