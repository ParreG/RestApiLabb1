using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.EducationDTOs;

namespace RestApiLabb1.Endpoints.EducationEndpoints
{
    public class ChangeEducationEndpoint
    {
        public static void RegisterChangeEducationEndpoint(WebApplication app)
        {
            // hämtar person samt utbildning, ändrar sedan info i den specifika utbildningen!
            app.MapPut("/api/personalinfo/{personId}/jobexperience/{educationId}", async (int personId, int educationId, EducationUpdateDTO educationUpdateDTO, RestApiDBContext context) =>
            {
                var education = await context.Educations
                    .FirstOrDefaultAsync(e => e.EducationId == educationId && e.PersonalInfoId_Fk == personId);

                if (education == null)
                {
                    return Results.NotFound("Utbildningen hittades inte för den angivna personen. Har du angett rätt id för person/utbildning?");
                }

                if (!string.IsNullOrWhiteSpace(educationUpdateDTO.SchoolName))
                    education.SchoolName = educationUpdateDTO.SchoolName;

                if (!string.IsNullOrWhiteSpace(educationUpdateDTO.Degree))
                    education.Degree = educationUpdateDTO.Degree;

                if (educationUpdateDTO.StartDate.HasValue)
                    education.StartDate = educationUpdateDTO.StartDate.Value;

                if (educationUpdateDTO.EndDate.HasValue)
                    education.EndDate = educationUpdateDTO.EndDate.Value;

                var response = new EducationCreateResponsDTO
                {
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    StartDate = education.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = education.EndDate?.ToString("yyyy-MM-dd")
                };

                await context.SaveChangesAsync();
                return Results.Ok($"Utbildningen har updaterats!");

            }).WithTags("2. Utbildning");
        }
    }
}
