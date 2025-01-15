using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
	public class MovieController : Controller
	{
		private MovieContext Context { get; set; }
		public MovieController(MovieContext ctx)
		{
			Context = ctx;
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add New Movie";
			return View("Edit", new Movie());
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
