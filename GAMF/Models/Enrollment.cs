namespace GAMF.Models
{
    public enum Grade { A, B, C, D, F }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public virtual Course Courses { get; set; }
        public virtual Student Students { get; set; }
    }
}
