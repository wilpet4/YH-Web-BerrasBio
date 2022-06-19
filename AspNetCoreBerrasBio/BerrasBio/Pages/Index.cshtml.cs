using Core;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class IndexModel : PageModel
    {
        public List<Movie> movies;
        public List<Screening> screenings;
        public Logic logic = new Logic();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            movies = logic.GetAllMoviesWithRelationData();
            screenings = logic.GetAllScreeningsWithRelationData();
        }
    }
}