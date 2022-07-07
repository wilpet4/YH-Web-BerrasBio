using BerrasBio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class ConfirmationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public DateTime ScreeningDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SeatId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieName { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Price { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
