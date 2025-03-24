using RestApiLabb1.Data;

namespace RestApiLabb1.Services
{
    public class EducationService
    {
        private readonly RestApiDBContext _context;

        public EducationService(RestApiDBContext context)
        {
            _context = context;
        }
    }
}
