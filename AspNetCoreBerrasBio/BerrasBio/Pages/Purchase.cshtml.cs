using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerrasBio.Pages
{
    public class PurchaseModel : PageModel
    {
        public Screening Screening { get; set; }
        public void OnGet()
        {

        }
    }
}
