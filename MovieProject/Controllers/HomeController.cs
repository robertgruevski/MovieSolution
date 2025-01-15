using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }
        public HomeController(MovieContext ctx) // Constructor accepts DB Context object that's enabled by DI
        {
            this.context = ctx;
        }
        public IActionResult Index()
        {
            var movies = context.Movies.OrderBy(m => m.Name).ToList();
            return View(movies);
        }
    }
}
