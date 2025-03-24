using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.EducationDTOs;
using RestApiLabb1.Models;
using System;

namespace RestApiLabb1.Endpoints
{
    public class EducationEndpoints
    {
        public static void RegisterEducationEndpoints(WebApplication app)
        {
            app.MapPost("/api/Educations/{personId}", async (int personId, EducationDTO educationDto, RestApiDBContext context) =>
            {
                var person = await context.PersonalInfos.FindAsync(personId);

                if (person == null)
                {
                    return Results.BadRequest("Personen hittades inte! Testa med annan Id");
                }

                var education = new Education
                {
                    SchoolName = educationDto.SchoolName,
                    Degree = educationDto.Degree,
                    StartDate = educationDto.StartDate,
                    EndDate = educationDto.EndDate,
                    PersonalInfoId = personId
                };

                var response = new EducationCreateResponsDTO
                {
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    StartDate = education.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = education.EndDate?.ToString("yyyy-MM-dd"),
                    Message = $"Utbildningen för {person.Name} med id {education.PersonalInfoId} har lagts till!"
                };

                context.Educations.Add(education);
                await context.SaveChangesAsync();

                return Results.Created($"/api/educations/{education.Id}", response);
            });

            // hämtar person samt utbildning, ändrar sedan info i den specifika utbildningen!
            app.MapPut("/api/personalinfo/{personId}/jobexperience/{educationId}", async (int personId, int educationId, EducationUpdateDTO educationUpdateDTO, RestApiDBContext context) =>
            {
                var education = await context.Educations
                    .FirstOrDefaultAsync(e => e.Id == educationId && e.PersonalInfoId == personId);

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
            });
        }
    }
}
