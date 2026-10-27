using ITHMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;

namespace ITHMS.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        public List<Ticket> Tickets = new List<Ticket>();
        public int SelectedUserId { get; set; } = 1;

        //for now there is only one user therefore userId is set to 1
        public void OnGet(int userId = 1)
        {
            SelectedUserId = userId;

            Tickets = HelpdeskStore.GetTickets().Where(t => t.UserId == SelectedUserId).ToList();
        }
    }
}
