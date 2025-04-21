using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.JobExperienceDTOs;

namespace RestApiLabb1.Endpoints.Jobs
{
    public class GetAllJobExperiencesForPersonEndpoint
    {
        public static void RegisterGetJobExperienceById(WebApplication app)
        {
            app.MapGet("/api/personalInfo/Jobexperience/{personId}", async (int personId, RestApiDBContext context) =>
            {
                var jobList = await context.JobExperiences
                                .Include(p => p.PersonalInfo)
                                .Where(j => j.PersonalInfoId_Fk == personId)
                                .ToListAsync();

                if (!jobList.Any())
                {
                    return Results.NotFound("Personen eller jobberfarenheter för personen hittades inte!");
                }

                var jobexperiences = jobList.Select(j => new JobExperienceDTO
                {
                    CompanyName = j.CompanyName,
                    JobTitle = j.JobTitle,
                    Year = j.Year
                }).ToList();

                var results = new
                {
                    PersonName = jobList.First().PersonalInfo.Name,
                    JobList = jobexperiences
                };

                return Results.Ok(results);

            }).WithTags("Jobb");
        }
    }
}
