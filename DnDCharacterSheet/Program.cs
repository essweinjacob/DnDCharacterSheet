using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllers()
    .AddJsonOptions((options) => options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IContainer, Container>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DefaultModelExpandDepth(2);
    c.DocExpansion(DocExpansion.None);
    c.EnableTryItOutByDefault();
    c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
});

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();