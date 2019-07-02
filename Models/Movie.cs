using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
	public class Movie
	{
		public string ID { get; set; }
		public string Title { get; set; }
		[DataType(DataType.Date), DisplayName("Release date")] public DateTime ReleaseDate { get; set; }
		public string Genre { get; set; }
		[Column(TypeName = "decimal(18, 2)"), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)] public decimal Price { get; set; }
		public string Rating { get; set; }
	}
}
