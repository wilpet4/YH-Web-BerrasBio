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
        public ConfirmedOrderModel ConfirmedOrderModel { get; set; }
        [BindProperty(SupportsGet = true)]
        public ScreeningModel ScreeningModel { get; set; }
        public Screening? CurrentScreening { get; set; }
        Logic logic = new Logic();
        public IActionResult OnGet(ScreeningModel screeningModel)
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            CurrentScreening = logic.GetScreeningByIndex(ScreeningModel.ScreeningId);
            if (CurrentScreening != null)
            {
                return RedirectToPage("Confirmation", ConfirmedOrderModel);
            }
            return RedirectToPage("Index");
        }
    }
}
