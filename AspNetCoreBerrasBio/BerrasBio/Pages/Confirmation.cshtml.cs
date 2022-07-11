using BerrasBio.Models;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class ConfirmationModel : PageModel
    {
        Logic logic = new Logic();
        Random random = new Random();
        [BindProperty(SupportsGet = true)]
        public ConfirmedOrderModel ConfirmedOrder { get; set; }
        public IActionResult OnGet()
        {
            if (ConfirmedOrder.ScreeningId == 0 || ConfirmedOrder.TicketAmount == 0)
            {
                // Fel
            }
            else
            {
                for (int i = 0; i < ConfirmedOrder.TicketAmount; i++) // Kanske inte göra allt detta i front-end.
                {
                    var screening = logic.GetScreeningByIndex(ConfirmedOrder.ScreeningId);
                    var seats = logic.GetAllAvailableSeatsFromScreening(screening);
                    var seat = seats[random.Next(0, seats.Count)];
                    logic.PrintReceipt(screening, seat);
                }
            }
            return Page();
        }
    }
}
