using BerrasBio.Models;
using Core;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class IndexModel : PageModel
    {
        public List<Screening> screenings;
        [BindProperty]
        public ScreeningModel ScreeningModel { get; set; }
        public Logic logic = new Logic();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            screenings = logic.GetAllScreeningsWithRelationData();
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Purchase", new { ScreeningModel.ScreeningId }); // usch äckligt
        }
    }
}