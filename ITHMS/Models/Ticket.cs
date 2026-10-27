// Represents an IT support request submitted by a user.

using ITHMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ITHMS.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Ticket title is required.")]
        [StringLength(100, MinimumLength = 5,ErrorMessage = "Title must contain 5 to 100 characters.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Ticket description is required.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Description must contain 10 to 2000 characters.")]
        public required string Description { get; set; }
        public int UserId {  get; set; }
        public int? AssignedTechnicianId {  get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public TicketPriority Priority { get; set; } = TicketPriority.Medium;


        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; } = string.Empty;

        public Ticket() { }

        // Checks whether the ticket is still active.
        public bool IsActive()
        {
            return  Status == TicketStatus.Open || Status == TicketStatus.InProgress;
        }

        // Closes a ticket only if it has been resolved.
        public void Close()
        {
            if(Status != TicketStatus.Resolved )
            {
                throw new InvalidOperationException("Only resolved tickets can be closed.");
            }
            Status = TicketStatus.Closed;
        }
    }
}
