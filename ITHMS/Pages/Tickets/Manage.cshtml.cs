using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;
using ITHMS.Models.Enums;
using ITHMS.Services;

namespace ITHMS.Pages.Tickets
{
    public class Manage : PageModel
    {
        public List<Ticket> Tickets { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public TicketStatus? FilterStatus { get; set; }

        [BindProperty(SupportsGet = true)]
        public TicketPriority? FilterPriority { get; set; }

        [TempData]
        public string? FeedbackMessage { get; set; }

        public void OnGet()
        {
            var query = HelpdeskStore.GetTickets().AsQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                query = query.Where(t => t.Title.Contains(SearchTerm) || t.Description.Contains(SearchTerm));
            }

            if (FilterStatus.HasValue)
            {
                query = query.Where(t => t.Status == FilterStatus.Value);
            }

            if (FilterPriority.HasValue)
            {
                query = query.Where(t => t.Priority == FilterPriority.Value);
            }

            Tickets = query.ToList();
        }

        public IActionResult OnPostUpdate(int id, int? assignedTechnicianId, TicketStatus status, TicketPriority priority)
        {
            var ticket = HelpdeskStore.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            if (assignedTechnicianId.HasValue)
            {
                HelpdeskStore.AssignTechnician(id, assignedTechnicianId.Value);
            }
            
            HelpdeskStore.UpdateStatus(id, status);
            ticket.Priority = priority; 

            FeedbackMessage = $"Ticket #{id} has been successfully updated.";

            return RedirectToPage();
        }
    }
}