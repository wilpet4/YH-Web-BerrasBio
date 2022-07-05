using BerrasBio.Models;
using Core;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public ScreeningModel ScreeningModel { get; set; }

        public List<Screening> screenings;
        public Logic logic = new Logic();
        private readonly ILogger<IndexModel> _logger;
        private readonly BerrasBioContext _context;

        public IndexModel(ILogger<IndexModel> logger, BerrasBioContext context)
        {
            _context = context;
            _logger = logger;
            screenings = logic.GetAllScreeningsWithRelationData();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Purchase", ScreeningModel);
        }
    }
}