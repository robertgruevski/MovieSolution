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
		public IActionResult Delete(int id)
		{
			var movie = Context.Movies.Find(id);
			return View(movie);
		}
		[HttpPost]
		public IActionResult Delete(Movie movie)
		{
			Context.Movies.Remove(movie);
			Context.SaveChanges();
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add New Movie";
			return View("Edit", new Movie());
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Action = "Edit Movie";
			var movie = Context.Movies.Find(id); // LINQ Query to find the movie with the given id - Primary Key search
			return View(movie);
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
				else
				{
					Context.Movies.Update(movie);
				}
				Context.SaveChanges();
				return RedirectToAction("Index", "Home");
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
