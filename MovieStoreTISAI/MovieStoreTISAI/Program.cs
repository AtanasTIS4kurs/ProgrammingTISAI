using Mapster;
using FluentValidation;
using MovieStoreTISAI.BL;
using MovieStoreTISAI.DL;
using MovieStoreTISAI.Models.Requests;
using MovieStoreTISAI.Validator;
using FluentValidation.AspNetCore;
using MovieStoreTISAI.Models.Configuration;
using MovieStoreTISAI.ServiceExtensions;

namespace MovieStoreTISAI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Add Configuration
            builder.Services.Configure<MongoDbConfiguration>(
                builder.Configuration.GetSection(nameof(MongoDbConfiguration)));
            // Add services to the container.
            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();
            builder.Services.AddBackgroundServices();
            builder.Services.AddHostedServices();
            builder.Services.AddMapster();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            builder.Services.AddValidatorsFromAssemblyContaining<MovieValidator>();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddConfiguration(builder.Configuration);

            var app = builder.Build();
            app.MapHealthChecks("/healthz");

            if (app.Environment.IsDevelopment())
            {
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
        }
    }
}
