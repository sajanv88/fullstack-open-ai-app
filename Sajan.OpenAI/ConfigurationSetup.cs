using Microsoft.Extensions.Options;

namespace Sajan.OpenAI 
{
    public class ConfigurationSetup : IConfigureOptions<ConfigurationOptions>
    {
        private const string SectionName = "OpenAIRemoteService";
        private readonly IConfiguration _configuration;

        public ConfigurationSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(ConfigurationOptions options)
        {
           _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
