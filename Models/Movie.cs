using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
	public class Movie
	{
		public string ID { get; set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string Title { get; set; }

		[DataType(DataType.Date)]
		[DisplayName("Release date")]
		public DateTime ReleaseDate { get; set; }

		[Required]
		[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
		[StringLength(30)]
		public string Genre { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		[Range(1, 100)]
		[DataType(DataType.Currency)]
		[DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C}")]
		public decimal Price { get; set; }

		[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
		[StringLength(5)]
		[Required]
		public string Rating { get; set; }
	}
}
