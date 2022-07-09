using BerrasBio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class ConfirmationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public ConfirmedOrderModel ConfirmedOrder { get; set; }
        public IActionResult OnGet(ConfirmedOrderModel confirmedOrder)
        {
            return Page();
        }
    }
}
