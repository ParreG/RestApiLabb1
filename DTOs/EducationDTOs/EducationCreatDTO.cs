using System.ComponentModel.DataAnnotations;

namespace RestApiLabb1.DTOs.EducationDTOs
{
    // använder i AddEducationEndpoint
    public class EducationCreatDTO
    {
        [Required]
        [MaxLength(200)]
        public string SchoolName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Degree { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
