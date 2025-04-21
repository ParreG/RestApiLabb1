using RestApiLabb1.DTOs.EducationDTOs;
using RestApiLabb1.DTOs.JobExperienceDTOs;
using System.ComponentModel.DataAnnotations;

namespace RestApiLabb1.DTOs.PersonInfoDTOs
{
    public class PersonDTOGet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }


        public List<EducationDTO> Educations { get; set; } = new List<EducationDTO>();

        public List<JobExperienceResoponsDTO> JobExperiences { get; set; } = new List<JobExperienceResoponsDTO>();
    }
}
