using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiLabb1.Models
{
    public class JobExperience
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public int Year { get; set; }

        // Foreign key
        public int PersonalInfoId_Fk { get; set; }

        [JsonIgnore]
        public PersonInfo PersonalInfo { get; set; }
    }
}
