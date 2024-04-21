namespace EducationalPortal.Models
{
    public class ProgramClass
    {
        public int ClassId { get; set; }
        public string ProgramDetails { get; set; }
        public string GradeLevel { get; set; }
        public DateTime Timings { get; set; }
        public int MaxSize { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
