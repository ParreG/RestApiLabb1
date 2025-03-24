namespace RestApiLabb1.DTOs.EducationDTOs
{
    public class EducationCreateResponsDTO
    {
        public int id { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string StartDate { get; set; } 
        public string EndDate { get; set; }
        public string Message { get; set; } 
    }
}
