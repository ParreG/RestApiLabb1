using RestApiLabb1.Data;
using RestApiLabb1.DTOs.JobExperienceDTOs;
using RestApiLabb1.Models;

namespace RestApiLabb1.Endpoints.Jobs
{
    public class JobExperienceEndpoints
    {
        public static void RegisterJobExperienceEndpoints(WebApplication app)
        {
            app.MapPost("/api/JobExperience/{personId}", async (int personId, JobExperienceDTO jobExperienceDTO, RestApiDBContext context) =>
            {
                var person = await context.PersonalInfos.FindAsync(personId);

                if (person == null)
                {
                    return Results.BadRequest("Personen hittades inte! Testa med annan Id");
                }

                var jobexperience = new JobExperience
                {
                    JobTitle = jobExperienceDTO.JobTitle,
                    CompanyName = jobExperienceDTO.CompanyName,
                    Year = jobExperienceDTO.Year,
                    PersonalInfoId_Fk = personId
                };

                var response = new JobExperienceResoponsDTO
                {
                    CompanyName = jobexperience.CompanyName,
                    JobTitle = jobexperience.JobTitle,
                    Year = jobexperience.Year,
                    Massage = $"Arbetslivserfarenhet för {person.Name} har lagts till. Se det genom att använda Get endpointsen!"
                };

                context.JobExperiences.Add(jobexperience);
                await context.SaveChangesAsync();

                return Results.Created($"/api/educations/{jobexperience.JobId}", response);

            }).WithTags("3. Jobb");
        }
    }
}
