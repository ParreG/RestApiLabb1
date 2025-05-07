using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.EducationDTOs;
using RestApiLabb1.Models;
using System;

namespace RestApiLabb1.Endpoints.Education
{
    public class AddEducationEndpoint
    {
        public static void RegisterAddEducationEndpoint(WebApplication app)
        {
            app.MapPost("/api/Educations/{personId}", async (int personId, EducationCreatDTO educationDto, RestApiDBContext context) =>
            {
                var person = await context.PersonalInfos.FindAsync(personId);

                if (person == null)
                {
                    return Results.BadRequest("Personen hittades inte! Testa med annan Id");
                }

                var education = new RestApiLabb1.Models.Education
                {
                    SchoolName = educationDto.SchoolName,
                    Degree = educationDto.Degree,
                    StartDate = educationDto.StartDate,
                    EndDate = educationDto.EndDate,
                    PersonalInfoId_Fk = personId
                };

                var response = new EducationCreateResponsDTO
                {
                    SchoolName = education.SchoolName,
                    Degree = education.Degree,
                    StartDate = education.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = education.EndDate?.ToString("yyyy-MM-dd"),
                    Message = $"Utbildningen för {person.Name} med id {education.PersonalInfoId_Fk} har lagts till!"
                };

                context.Educations.Add(education);
                await context.SaveChangesAsync();

                return Results.Created($"/api/educations/{education.EducationId}", response);
            }).WithTags("2. Utbildning");
        }
    }
}
