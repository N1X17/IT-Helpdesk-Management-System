// Represents an IT support request submitted by a user.

using ITHMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ITHMS.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(2000, MinimumLength = 10)]
        public string Description { get; set; } = "";


        [Range(1, int.MaxValue,ErrorMessage = "Select a valid user.")]
        public int UserId {  get; set; }
        public int AssignedTechnicianId {  get; set; }
        public TicketStatus Status { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public TicketPriority Priority { get; set; }

        public Ticket() { }

        public Ticket(int userId, string title, string description)
        {
            UserId = userId;
            Title = title;
            Description = description;
        }

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
