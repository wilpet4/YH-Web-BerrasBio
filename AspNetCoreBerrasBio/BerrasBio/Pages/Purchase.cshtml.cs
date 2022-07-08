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
        public Screening? CurrentScreening { get; set; }
        Logic logic = new Logic();
        public IActionResult OnGet(ScreeningModel screeningModel)
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            Random random = new Random();
            CurrentScreening = logic.GetScreeningByIndex(ScreeningModel.ScreeningId);
            if (CurrentScreening != null)
            {
                var seats = logic.GetAllAvailableSeatsFromScreening(CurrentScreening);
                Seat? seat = seats.ElementAt(random.Next(0, seats.Count));
                if (seat != null)
                {
                    seat.IsOccupied = true;
                    logic.PrintReceipt(CurrentScreening, seat);
                    return RedirectToPage("Confirmation", new { ScreeningModel.ScreeningDate, ScreeningModel.MovieName, ScreeningModel.Price, seat.SeatId});
                }
            }
            return RedirectToPage("Index");
        }
    }
}
