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
                    List<Seat> seats = logic.GetAllAvailableSeatsFromScreening(screening);
                    int seatNr = random.Next(0, seats.Count);
                    Seat seat = seats[seatNr];
                    logic.PrintReceipt(screening, seat, seatNr);
                }
            }
            return Page();
        }
    }
}
