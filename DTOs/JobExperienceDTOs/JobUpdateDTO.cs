using System.ComponentModel.DataAnnotations;

namespace RestApiLabb1.DTOs.JobExperienceDTOs
{
    public class JobUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        public int? Year { get; set; }
    }
}
