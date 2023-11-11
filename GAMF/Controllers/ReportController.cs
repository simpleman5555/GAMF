using GAMF.Data;
using GAMF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace GAMF.Controllers
{
    public class ReportController : Controller
    {
        private readonly GAMFDbContext _context;

        public ReportController(GAMFDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult EnrollmentDateReport()
        {
            var result = from student in _context.Students
                         group student by student.EnrollmentDate into dateGroup
                         select new EnrollmentDateVM
                         {
                             EnrollmentDate = dateGroup.Key,
                             StudentCount = dateGroup.Count()
                         };

            return View(result.ToList());
        }

        public IActionResult StudentsCreditsReport()
        {
            var result = from student in _context.Students
                         join enrollment in _context.Enrollments on student.Id equals enrollment.StudentId
                         join course in _context.Courses on enrollment.CourseId equals course.CourseId
                         group course.Credits by new
                         {
                             StudentId = student.Id,
                             LastName = student.LastName,
                             FirstMidName = student.FirstMidName
                         } into grouped
                         select new StudentsCredits
                         {
                             LastName = grouped.Key.LastName,
                             FirstMidName = grouped.Key.FirstMidName,
                             Credits = grouped.Sum()
                         };

            return View(result.ToList());
        }
    }
}
