using ITHMS.Models;
using ITHMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHMS.Pages.Tickets
{
    public class UserTicketDetailsModel : PageModel
    {
        public Ticket? Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = HelpdeskStore.GetTicket(id);
            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
