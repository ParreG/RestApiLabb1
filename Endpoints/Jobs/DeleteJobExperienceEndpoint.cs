using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;

namespace RestApiLabb1.Endpoints.Jobs
{
    public class DeleteJobExperienceEndpoint
    {
        public static void RegisterDeleteJobEndpoint(WebApplication app)
        {
            app.MapDelete("api/personalinfo/{personId}/Jobexperience/{jobId}", async (int personId, int jobId, RestApiDBContext context) =>
            {
                var job = await context.JobExperiences
                .Include(p => p.PersonalInfo)
                .FirstOrDefaultAsync(j => j.PersonalInfoId_Fk == personId && j.JobId == jobId);

                if (job == null)
                {
                    return Results.NotFound("Jobb erfarenheten eller personen i fråga hittades inte!");
                }

                context.JobExperiences.Remove(job);
                await context.SaveChangesAsync();

                return Results.Ok($"Jobberfarenheten {job.JobTitle} med id {jobId}, har raderats för {job.PersonalInfo.Name} med id: {personId}");
            }).WithTags("Jobb");
        }
    }
}
