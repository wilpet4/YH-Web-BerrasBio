using Core;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class PurchaseModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ScreeningId { get; set; }
        Logic logic = new Logic();
        public void OnGet()
        {

        }
    }
}
