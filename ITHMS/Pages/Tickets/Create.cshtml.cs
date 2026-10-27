using ITHMS.Models.Enums;
using ITHMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;
using System.Linq;

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

        public void OnPost(int userId, string title, string description, TicketPriority priority, string category)
        {
            users = HelpdeskStore.GetUsers();
            if (!users.Any(u =>u.UserId == userId &&u.Role == UserRole.Employee))
            {
                Message = "Please select an Employee.";
            }
            else if (string.IsNullOrWhiteSpace(title))
            {
                Message = "Ticket title is required.";
            }
            else if (title.Trim().Length < 5 ||title.Trim().Length > 100)
            {
                Message = "Title must be between 5 and 100 characters.";
            }
            else if (string.IsNullOrWhiteSpace(description))
            {
                Message = "Ticket Description is required.";
            }
            else if (description.Trim().Length < 10 || description.Trim().Length > 2000)
            {
                Message = "Description must be between 10 and 2000 characters.";
            }
            else if (!Enum.IsDefined(typeof(TicketPriority), priority))
            {
                Message = "Invalid ticket priority.";
            }
            else if (string.IsNullOrWhiteSpace(category) || !new[] { "Hardware", "Software", "Network", "Account" }.Contains(category))
            {
                Message = "Please select a valid category.";
            }
            else
            {
                try
                {
                    HelpdeskStore.CreateTicket(userId, title, description, priority, category);
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
