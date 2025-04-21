
using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.Endpoints.Education;
using RestApiLabb1.Endpoints.EducationEndpoints;
using RestApiLabb1.Endpoints.Jobs;
using RestApiLabb1.Endpoints.Person;
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

            GetAllPersonEndpoint.RegisterFindAllEndpoint(app);
            AddPersonEndpoint.RegisterNewPersonEndpoint(app);


            AddEducationEndpoint.RegisterAddEducationEndpoint(app);
            GetAllEducationsForPersonEndpoint.RegisterGetAllEdcationByID(app);
            DeleteEducationEndpoint.RegisterDeleteEducationEndpoint(app);
            ChangeEducationEndpoint.RegisterChangeEducationEndpoint(app);
            GetSingleEducationEndpoint.RegisterSingleEducationByIdEndpoint(app);

            JobExperienceEndpoints.RegisterJobExperienceEndpoints(app);
            DeleteJobExperienceEndpoint.RegisterDeleteJobEndpoint(app);
            GetAllJobExperiencesForPersonEndpoint.RegisterGetJobExperienceById(app);
            GetSingleJobExperienceEndpoint.RegisterGetJobExperieceById(app);
            ChangeJobExperienceEndpoint.RegisterJobExperienceChangeEndpoint(app);



            app.Run();

        }
    }
}
