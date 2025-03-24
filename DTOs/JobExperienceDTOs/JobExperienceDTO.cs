using RestApiLabb1.Models;
using System.ComponentModel.DataAnnotations;

namespace RestApiLabb1.DTOs.JobExperienceDTOs
{
    public class JobExperienceDTO
    {

        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        public int Year { get; set; }

    }
}
