using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace MovieProject.Models
{
	public class Movie
	{
		public int MovieId { get; set; }
		[Required(ErrorMessage = "Please enter a name")]
		public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = "Please enter a year")]
		[Range(1900, 2024, ErrorMessage = "Year must be between 1900 and 2025")]
		public int? Year { get; set; }
		[Required(ErrorMessage = "Please enter a rating")]
		[Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
		public int? Rating { get; set; }
		public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString(); // Read only property for the slug
		[Required(ErrorMessage = "Please enter a genre")]
		public string GenreId { get; set; } = string.Empty; // Foreign Key Property
		[ValidateNever]
		public Genre Genre { get; set; } = null!; // Navigation property to link the Genre to the Movie
	}
}
