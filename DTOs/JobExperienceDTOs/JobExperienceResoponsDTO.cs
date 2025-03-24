using System.ComponentModel.DataAnnotations;

namespace RestApiLabb1.DTOs.JobExperienceDTOs
{
    public class JobExperienceResoponsDTO
    {
        public int id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public int Year { get; set; }
        public string Massage { get; set; }
    }
}
