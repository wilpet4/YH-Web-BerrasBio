using Core;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class PurchaseModel : PageModel
    {
        Logic logic = new Logic();
        [BindProperty(SupportsGet = true)]
        public int ScreeningId { get; set; }
        public Screening screening;
        public void OnGet(int ScreeningId)
        {
            this.ScreeningId = ScreeningId;
        }
    }
}
