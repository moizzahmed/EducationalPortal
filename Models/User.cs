using Microsoft.AspNetCore.Identity;

namespace EducationalPortal.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string username { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
