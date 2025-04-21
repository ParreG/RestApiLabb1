using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiLabb1.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        [Required]
        [MaxLength(200)]
        public string SchoolName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Degree { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        // Foreign key
        public int PersonalInfoId_Fk { get; set; }

        [JsonIgnore]
        public PersonInfo PersonalInfo { get; set; }
    }
}
