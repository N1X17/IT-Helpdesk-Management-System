using ITHMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;

namespace ITHMS.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        public List<Ticket> Tickets = new List<Ticket>();

        public void OnGet()
        {
            Tickets = HelpdeskStore.GetTickets();
        }
    }
}
