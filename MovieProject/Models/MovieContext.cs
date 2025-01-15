﻿using Microsoft.EntityFrameworkCore;
namespace MovieProject.Models
{
	public class MovieContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; } = null!; // a Property that represents the collection of all Movie objects
		public MovieContext(DbContextOptions<MovieContext> options) : base(options) { } // Movie constructor
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().HasData(
				new Movie() { MovieId = 1, Name = "The Godfather", Year = 1972, Rating = 5 },
				new Movie() { MovieId = 2, Name = "Casablanca", Year = 1942, Rating = 4 },
				new Movie() { MovieId = 3, Name = "The Matrix", Year = 1999, Rating = 4 }
				);
			base.OnModelCreating(modelBuilder);
		}
	}
}
