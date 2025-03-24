using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiLabb1.Models
{
    public class PersonInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        // Navigation properties
        [JsonIgnore]
        public List<Education> Educations { get; set; }

        [JsonIgnore]
        public List<JobExperience> JobExperiences { get; set; }
    }
}
