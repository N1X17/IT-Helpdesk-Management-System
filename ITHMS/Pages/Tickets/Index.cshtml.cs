using ITHMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;

namespace ITHMS.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly HelpdeskStore store;
        public List<Ticket> Tickets = new List<Ticket>();

        public IndexModel(HelpdeskStore helpdeskStore)
        {
            store = helpdeskStore;
        }

        public void OnGet()
        {
            Tickets = store.GetTickets();
        }
    }
}
