using Microsoft.AspNetCore.Http;
using RestApiLabb1.Services;

namespace RestApiLabb1.Endpoints.Person
{
    public class GetAllPersonEndpoint
    {
        public static void RegisterFindAllEndpoint(WebApplication app)
        {
            app.MapGet("/PersonInformation", async (UserService userService) =>
            {
                var allPersonalInfo = await userService.GetPersonalInfo();

                return Results.Ok(allPersonalInfo);

            }).WithTags("1. Person");
        }
    }
}
