
using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.Endpoints;
using RestApiLabb1.Services;

namespace RestApiLabb1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RestApiDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<UserService>();

            builder.Services.AddScoped<EducationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            PersonEndpoints.RegisterEndpoints(app);
            EducationEndpoints.RegisterEducationEndpoints(app);
            JobExperienceEndpoints.RegisterJobExperienceEndpoints(app);

            // Ta bort en utbildning
            // Ta bort en yrkeserfarenhet
            // Hämta bara en person och all dess info baserat på en person ID
            // Hämta en specifik jobberfarenhet och byta information i den. 
            // 

            app.Run();

        }
    }
}
