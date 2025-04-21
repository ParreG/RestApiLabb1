using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.EducationDTOs;

namespace RestApiLabb1.Endpoints.EducationEndpoints
{
    public class GetSingleEducationEndpoint
    {
        public static void RegisterSingleEducationByIdEndpoint(WebApplication app)
        {
            app.MapGet("/api/personalInfo/educations/{personId}/{educationId}", async (int personId, int educationId, RestApiDBContext context) =>
            {
                var education = await context.Educations
                                    .Include(p => p.PersonalInfo)
                                    .FirstOrDefaultAsync(p => p.PersonalInfoId_Fk == personId && p.EducationId == educationId);

                if (education == null)
                {
                    return Results.NotFound("Den aktuella Personen eller aktuella personens utbildning hittades inte!");
                }

                var result = new EducationDTO
                {
                    
                    EducationId = education.EducationId,
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    StartDate = education.StartDate,
                    EndDate = education.EndDate
                };

                var respons = new
                {
                    PersonName = education.PersonalInfo.Name,
                    Education = result
                };

                return Results.Ok(respons);

            }).WithTags("Utbildning");
        }
    }
}
