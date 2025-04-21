using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.EducationDTOs;

namespace RestApiLabb1.Endpoints.EducationEndpoints
{
    public class GetAllEducationsForPersonEndpoint
    {
        public static void RegisterGetAllEdcationByID(WebApplication app)
        {
            app.MapGet("api/Educations/PersonalInfo/{personId}", async (int personId, RestApiDBContext context) =>
            {
                var educations = await context.Educations
                            .Include(p => p.PersonalInfo)
                            .Where(e => e.PersonalInfoId_Fk == personId)
                            .ToListAsync();

                if (!educations.Any())
                {
                    return Results.NotFound("Prsonen hittades inte!");
                }

                var educationList = educations.Select(e => new EducationDTO
                {
                    EducationId = e.EducationId,
                    SchoolName = e.SchoolName,
                    Degree = e.Degree,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                }).ToList();

                var result = new
                {
                    PersonName = educations.First().PersonalInfo.Name,
                    Educations = educationList
                };

                return Results.Ok(result);

            }).WithTags("Utbildning");
        }
    }
}
