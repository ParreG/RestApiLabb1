using RestApiLabb1.Data;
using RestApiLabb1.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using RestApiLabb1.Models;
using RestApiLabb1.DTOs.PersonInfoDTOs;



namespace RestApiLabb1.Endpoints.Person
{
    public class AddPersonEndpoint
    {
        public static void RegisterNewPersonEndpoint(WebApplication app)
        {
            app.MapPost("/NyPerson", async (PersonDTOPost newPerson, RestApiDBContext context) =>
            {
                var validationContext = new ValidationContext(newPerson);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newPerson, validationContext, validationResult, true);

                if (!isValid)
                {
                    var errors = validationResult.Select(e => e.ErrorMessage);
                    return Results.BadRequest(new { error = "Fel input. Testa igen.", details = errors });
                }

                var person = new PersonInfo
                {
                    Name = newPerson.Name,
                    Email = newPerson.Email,
                    Phone = newPerson.Phone,
                    Description = newPerson.Description
                };

                context.PersonalInfos.Add(person);
                await context.SaveChangesAsync();

                return Results.Ok($"{person.Name} har lagts till. För att lägga till utbildningar och arbetslivserfarenheter gå till det specifika Post endpointen!");
            }).WithTags("1. Person");
        }
    }
}
