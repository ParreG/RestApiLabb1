using RestApiLabb1.DTOs.GithubDto;
using RestApiLabb1.Models;
using System.Text.Json;


namespace RestApiLabb1.Endpoints.GithubEndpoints
{
    public static class GithubRepoEndpoint
    {
        public static void RegisterGithubEndpoint(WebApplication app)
        {
            app.MapGet("/github/{username}", async (string username) =>
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("CV-API");

                var url = $"https://api.github.com/users/{username}/repos";
                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return Results.NotFound($"Kunde inte hämta repos för användare '{username}'.");
                }

                var json = await response.Content.ReadAsStringAsync();

                var githubRepos = JsonSerializer.Deserialize<List<GithubRepo>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (githubRepos == null || !githubRepos.Any())
                {
                    return Results.Ok(new List<GithubRepoDto>());
                }

                var repoDtos = githubRepos.Select(repo => new GithubRepoDto
                {
                    Name = repo.Name,
                    Description = repo.Description,
                    Language = repo.Language,
                    HtmlUrl = repo.HtmlUrl

                }).ToList();

                return Results.Ok(repoDtos);
            }).WithTags("Github");
        }
    }
}
