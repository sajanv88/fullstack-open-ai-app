
using System.Net;
using Sajan.OpenAI.Dtos;
using Newtonsoft.Json;
using Flurl.Http;
namespace Sajan.OpenAI.MiddleWares;
public class GlobalExceptionMiddleware : IMiddleware
{

    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
       try 
       {
            await next(context);
       }catch(FlurlHttpException e) 
       {   
       
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var exception = await e.GetResponseJsonAsync();
            var  exceptionResponse = JsonConvert.SerializeObject(exception);
            var decodeJson = JsonConvert.DeserializeObject(exceptionResponse);
            _logger.LogInformation($"Error caught: {decodeJson}");
            var error = new AIErrorDto
            {
                Error = new ErrorDto 
                {
                    Message = decodeJson.error.message,
                    Type = decodeJson.error.type,
                    Param = decodeJson.error.param,
                    Code = decodeJson.error.code
                }
            };
            var response = JsonConvert.SerializeObject(error);
            await context.Response.WriteAsync(response);
       }
    }
}