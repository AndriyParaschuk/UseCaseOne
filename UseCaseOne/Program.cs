using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "Use Case #1", Version = "v1" }));

services.AddHttpClient();

services.AddApplication();
services.AddGateways();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
