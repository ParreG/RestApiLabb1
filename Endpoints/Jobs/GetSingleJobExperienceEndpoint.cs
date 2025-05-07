using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.JobExperienceDTOs;

namespace RestApiLabb1.Endpoints.Jobs
{
    public class GetSingleJobExperienceEndpoint
    {
        public static void RegisterGetJobExperieceById(WebApplication app)
        {
            app.MapGet("/api/PersonalInfo/{personId}/{jobId}", async (int personId, int jobId, RestApiDBContext context) =>
            {
                var job = await context.JobExperiences
                                 .Include(p => p.PersonalInfo)
                                 .FirstOrDefaultAsync(j => j.PersonalInfoId_Fk == personId && j.JobId == jobId);

                if (job == null)
                {
                    return Results.NotFound("Personen eller jobberfarenheten hittades inte!");
                }

                var restult = new JobExperienceResoponsDTO
                {
                    id = job.JobId,
                    CompanyName = job.CompanyName,
                    JobTitle = job.JobTitle,
                    Year = job.Year
                };

                var respons = new
                {
                    PersonName = job.PersonalInfo.Name,
                    JobExperience = restult
                };

                return Results.Ok(respons);

            }).WithTags("3. Jobb");
        }
    }
}
