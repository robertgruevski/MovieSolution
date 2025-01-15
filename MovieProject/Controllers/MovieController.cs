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
		[HttpPost]
		public IActionResult Edit(Movie movie)
		{
			if(ModelState.IsValid)
			{
				// Either Add a new movie or Edit a movie
				if(movie.MovieId == 0)
				{
					Context.Movies.Add(movie);
				}
				Context.SaveChanges();
				return RedirectToAction("Index", "Home");
				//else
				//{
				//	Context.Movies.Update(movie);
				//}
			}
			else
			{
				// Show Validation Errors
				ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
				return View(movie);
			}
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
