using ITHMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ITHMS.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        [Range(1, int.MaxValue,ErrorMessage = "Select a valid user.")]
        public int UserId {  get; set; }
        public int AssignedTechnicianId {  get; set; }
        public TicketStatus Status { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Ticket() { }

        public Ticket(int userId, string title, string description)
        {
            UserId = userId;
            Title = title;
            Description = description;
        }

        public bool IsActive()
        {
            return  Status == TicketStatus.Open || Status == TicketStatus.InProgress;
        }

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
