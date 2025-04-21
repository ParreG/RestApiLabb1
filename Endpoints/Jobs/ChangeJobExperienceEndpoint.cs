using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.JobExperienceDTOs;

namespace RestApiLabb1.Endpoints.Jobs
{
    public class ChangeJobExperienceEndpoint
    {
        public static void RegisterJobExperienceChangeEndpoint(WebApplication app)
        {
            app.MapPut("/api/PersonalInfo/JobExperience/{personId}/{jobId}", async (int personId, int jobId, JobUpdateDTO jobUpdateDto ,RestApiDBContext context) =>
            {
                var job = await context.JobExperiences
                                 .Include(p => p.PersonalInfo)
                                 .FirstOrDefaultAsync(j => j.PersonalInfoId_Fk == personId && j.JobId == jobId);
                if (job == null)
                {
                    return Results.NotFound("Den angivna personen eller jobberfarenheten hittades inte!");
                }

                if (!string.IsNullOrWhiteSpace(jobUpdateDto.JobTitle))
                {
                    job.JobTitle = jobUpdateDto.JobTitle;
                }

                if (!string.IsNullOrWhiteSpace(jobUpdateDto.CompanyName))
                {
                    job.CompanyName = jobUpdateDto.CompanyName;
                }

                if (jobUpdateDto.Year.HasValue)
                {
                    job.Year = jobUpdateDto.Year.Value;
                }



                var result = new JobExperienceResoponsDTO
                {
                    id = job.JobId,
                    CompanyName = job.CompanyName,
                    JobTitle = job.JobTitle,
                    Year = job.Year,
                };

                var respons = new
                {
                    PersonName = job.PersonalInfo.Name,
                    JobExperience = result
                };

                await context.SaveChangesAsync();
                return Results.Ok(respons);

            }).WithTags("Jobb");
        }
    }
}
