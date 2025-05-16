using Mapster;
using FluentValidation;
using MovieStoreTISAI.BL;
using MovieStoreTISAI.DL;
using MovieStoreTISAI.Models.Requests;
using MovieStoreTISAI.Validator;
using FluentValidation.AspNetCore;
using MovieStoreTISAI.Models.Configuration;
using MovieStoreTISAI.ServiceExtensions;
using MovieStoreTISAI.Controllers;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(theme:
        AnsiConsoleTheme.Code)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services
    .AddConfiguration(builder.Configuration)
    .AddDataDependencies(builder.Configuration)
    .AddBusinessDependencies();

builder.Services.AddMapster();

builder.Services.AddValidatorsFromAssemblyContaining<TestRequest>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//builder.Services.AddHealthChecks();

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthz");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
