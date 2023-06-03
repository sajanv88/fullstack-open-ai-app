using Flurl;
using Flurl.Http.Configuration;
using Sajan.OpenAI;
using Sajan.OpenAI.MiddleWares;
using Sajan.OpenAI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureOptions<ConfigurationSetup>();

builder.Services.AddSingleton<IFlurlClientFactory,PerBaseUrlFlurlClientFactory>(); 
builder.Services.AddSingleton<AIImageService>();
builder.Services.AddSingleton<AITextEditorService>();
builder.Services.AddTransient<GlobalExceptionMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();

