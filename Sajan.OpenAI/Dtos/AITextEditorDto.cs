using System;
using Flurl.Http;

namespace Sajan.OpenAI.Dtos
{
	public class AITextParameterDto
	{
		public string Model { get; set; }

		public string Input { get; set; }

		public string Instruction { get; set; }
    }

	public class ChoiceDto
	{
		public string Text { get; set; }

		public double Index { get; set; }
	}

	public class UsageDto
	{
		public double PromotTokens { get; set; }

        public double CompletionTokens { get; set; }

        public double TotalTokens { get; set; }
    }

	public class AITextEditorDto
	{
		public string Object { get; set; }

		public double created { get; set; }

		public List<ChoiceDto> Choices { get; set; }

		public UsageDto Usage { get; set; }

    }  
}
