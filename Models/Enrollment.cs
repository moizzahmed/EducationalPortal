using System.Security.Claims;

namespace EducationalPortal.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string UserId { get; set; }
        public int ClassId { get; set; }

        public User User { get; set; }
        public ProgramClass Class { get; set; }
    }
}
