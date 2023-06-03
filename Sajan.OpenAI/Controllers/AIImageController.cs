using System;
using Microsoft.AspNetCore.Mvc;
using Sajan.OpenAI.Dtos;
using Sajan.OpenAI.Services;

namespace Sajan.OpenAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AIImageController: ControllerBase
	{
        private readonly ILogger<AIImageController> _logger;
        private readonly AIImageService _aiImageService;

        public AIImageController(ILogger<AIImageController> logger, AIImageService aiImageService)
		{
            _logger = logger;
            _aiImageService = aiImageService;
            _logger.LogInformation("AIImageController initialized.");
		}

        [HttpPost(Name = "CreateImage")]
        public async Task<ActionResult<AIImageDto>> CorrectMyTextAsync(AIImageParameterDto newAIImageParameter)
        {
            return await  _aiImageService.CreateImageAsync(newAIImageParameter);
        }
	}
}

