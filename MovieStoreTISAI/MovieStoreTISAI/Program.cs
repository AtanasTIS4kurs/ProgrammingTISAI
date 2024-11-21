using Mapster;
using MovieStoreTISAI.BL;
using MovieStoreTISAI.DL;

namespace MovieStoreTISAI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterRepositories();
            builder.Services.RegisterServices();
            builder.Services.AddMapster();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                // Configure the HTTP request pipeline.

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
        }
    }
}
