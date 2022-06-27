using BerrasBio.Models;
using Core;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class PurchaseModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public ScreeningModel ScreeningModel { get; set; }
        public Screening CurrentScreening { get; set; }
        Logic logic = new Logic();
        public IActionResult OnGet(ScreeningModel screeningModel)
        {
            return Page();
        }
    }
}
