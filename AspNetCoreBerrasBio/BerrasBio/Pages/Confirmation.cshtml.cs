using BerrasBio.Models;
using Core;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class ConfirmationModel : PageModel
    {
        Logic logic = new Logic();
        [BindProperty(SupportsGet = true)]
        public ConfirmedOrderModel ConfirmedOrder { get; set; }
        public IActionResult OnGet()
        {
            if (ConfirmedOrder.ScreeningId == 0 || ConfirmedOrder.TicketAmount == 0)
            {
                return RedirectToPage("Index");
            }
            else
            {
                logic.OrderTickets(ConfirmedOrder.TicketAmount, ConfirmedOrder.ScreeningId);
            }
            return Page();
        }
    }
}
