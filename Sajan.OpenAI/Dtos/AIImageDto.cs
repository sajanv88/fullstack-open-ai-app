
namespace Sajan.OpenAI.Dtos
{

    public class AIImageParameterDto 
    {
        public string Prompt {get; set;}
        public int N {get; set;}
        public string Size {get; set;}

    }

    public class DataDto 
    {
        public string? url {get; set;}
        public string? B64Json {get; set;}
    }
    public class AIImageDto 
    {
        public double Created {get; set;}
        public List<DataDto> Data {get; set;}
    }
}
