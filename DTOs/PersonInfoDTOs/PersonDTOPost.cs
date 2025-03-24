using System.ComponentModel.DataAnnotations;

namespace RestApiLabb1.DTOs.PersonInfoDTOs
{
    public class PersonDTOPost
    {
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

    }
}
