using ITHMS.Models.Enums;
using ITHMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;

namespace ITHMS.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly HelpdeskStore store;
        public List<User> users = new List<User>();
        public string? Message { get; set; }

        public CreateModel(HelpdeskStore helpdeskStore)
        {
            store = helpdeskStore;
        }

        public void OnGet()
        {
            users = store.GetUsers();
        }

        public void OnPost(int userId, string title, string description, TicketPriority priority)
        {
            users = store.GetUsers();
            if (userId == 0)
            {
                Message = "Please select an Employee.";
            }
            else if (string.IsNullOrWhiteSpace(title))
            {
                Message = "Ticket title is required.";
            }
            else if (string.IsNullOrWhiteSpace(description))
            {
                Message = "Ticket Description is required.";
            }
            else
            {
                try
                {
                    store.CreateTicket(userId, title, description, priority);
                    Message = "Ticket created successfully.";
                }
                catch (Exception)
                {
                    Message = "Error creating ticket.";
                }
            }
        }
    }
}
