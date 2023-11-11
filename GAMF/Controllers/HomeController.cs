using GAMF.Data;
using Microsoft.AspNetCore.Mvc;

namespace GAMF.Controllers
{
    public class HomeController : Controller
    {
        private readonly GAMFDbContext _context;

        public HomeController(GAMFDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();

            return View();
        }
    }
}
