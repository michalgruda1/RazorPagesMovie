using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
	public class IndexModel : PageModel
	{
		private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;

		public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
		{
			_context = context;
		}

		public IList<Movie> Movie { get; set; }
		[RegularExpression(@"[^&<>\""'/]*$", ErrorMessage = "Wykryto niedozwolone znaki"), BindProperty(SupportsGet = true), DataType(DataType.Text)] public string SearchString { get; set; }
		public SelectList Genres { get; set; }
		[RegularExpression(@"[^&<>\""'/]*$", ErrorMessage = "Wykryto niedozwolone znaki"), BindProperty(SupportsGet = true)] public string MovieGenre { get; set; }

		public async Task OnGetAsync()
		{
			var movies = _context.Movie.Select(m => m);

			if (!string.IsNullOrEmpty(SearchString) && SearchString.Trim().Length > 0)
			{
				movies = movies.Where(m => m.Title.ToUpperInvariant().Contains(SearchString.ToUpperInvariant()));
			}

			Movie = await movies.ToListAsync();
		}
	}
}
