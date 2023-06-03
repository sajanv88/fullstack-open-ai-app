namespace Sajan.OpenAI.Dtos
{
    public class ErrorDto 
    {
        public string Message {get; set;}
        public string Type {get; set;}

        public string? Param {get; set;} = null;
        public double? Code {get; set;} = null;

    }
    public class AIErrorDto 
    {
        public ErrorDto? Error {get; set;}
    }
}

