using System;
using Microsoft.AspNetCore.Mvc;
using Sajan.OpenAI.Dtos;
using Sajan.OpenAI.Services;

namespace Sajan.OpenAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AITextEditorController: ControllerBase
	{
        private readonly ILogger<AITextEditorController> _logger;
        private readonly AITextEditorService _aiTextEditorService;

        public AITextEditorController(ILogger<AITextEditorController> logger, AITextEditorService aiTextEditorService)
		{
            _logger = logger;
            _aiTextEditorService = aiTextEditorService;
            _logger.LogInformation("AITextEditorController initialized.");
		}

        [HttpPost(Name = "CorrectMyText")]
        public async Task<ActionResult<AITextEditorDto>> CorrectMyTextAsync(AITextParameterDto newAITextParameter)
        {
            return await  _aiTextEditorService.CorretMyTextAsync(newAITextParameter);
        }
	}
}

