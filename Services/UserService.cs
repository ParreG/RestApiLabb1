using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Data;
using RestApiLabb1.DTOs.EducationDTOs;
using RestApiLabb1.DTOs.JobExperienceDTOs;
using RestApiLabb1.DTOs.PersonInfoDTOs;
using RestApiLabb1.Models;

namespace RestApiLabb1.Services
{
    public class UserService
    {
        private readonly RestApiDBContext context;

        public UserService(RestApiDBContext _context)
        {
            context = _context; 
        }

        public async Task<List<PersonDTOGet>> GetPersonalInfo()
        {
            var personalList = await context.PersonalInfos
                .Include(p => p.Educations)
                .Include(p => p.JobExperiences)
                .Select(p => new PersonDTOGet
                {
                    Id = p.PersonId,
                    Name = p.Name,
                    Email = p.Email,
                    Phone = p.Phone,
                    Description = p.Description,

                    Educations = p.Educations.Select(e => new EducationDTO
                    {
                        EducationId = e.EducationId, // Denna måste finnas så att den syns i get men inte i post education!
                        SchoolName = e.SchoolName,
                        Degree = e.Degree,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate
                    }).ToList(),

                    JobExperiences = p.JobExperiences.Select(j => new JobExperienceResoponsDTO
                    {
                        id = j.JobId,
                        CompanyName = j.CompanyName,
                        JobTitle = j.JobTitle,
                        Year = j.Year
                    }).ToList(),

                }).ToListAsync();

            return personalList;
        }

        


        
    }
}
