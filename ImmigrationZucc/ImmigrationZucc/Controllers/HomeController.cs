using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ImmigrationZucc.Models;
using ImmigrationZucc.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ImmigrationZucc.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
