using ITHMS.Models.Enums;
using ITHMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;

namespace ITHMS.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        public List<User> users = new List<User>();
        public string? Message { get; set; }

        public void OnGet()
        {
            users = HelpdeskStore.GetUsers();
        }

        public void OnPost(int userId, string title, string description, TicketPriority priority)
        {
            users = HelpdeskStore.GetUsers();
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
                    HelpdeskStore.CreateTicket(userId, title, description, priority);
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
