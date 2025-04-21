using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;

namespace RestApiLabb1.Endpoints.EducationEndpoints
{
    public class DeleteEducationEndpoint
    {
        public static void RegisterDeleteEducationEndpoint(WebApplication app)
        {
            app.MapDelete("api/personalinfo/{personId}/educations/{educationId}", async (int personId, int educationId, RestApiDBContext context) =>
            {
                var education = await context.Educations
                .Include(e => e.PersonalInfo) 
                .FirstOrDefaultAsync(e => e.EducationId == educationId && e.PersonalInfoId_Fk == personId);

                if (education == null)
                {
                    return Results.NotFound("Utbildning eller personen hittades inte!!");
                }

                context.Educations.Remove(education);
                await context.SaveChangesAsync();

                return Results.Ok($"Utbildningen {education.SchoolName}, {education.Degree} med id {educationId}, har raderats för {education.PersonalInfo.Name} med id {personId}.");

            }).WithTags("Utbildning");
        }
    }
}
