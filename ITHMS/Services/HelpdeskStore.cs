
using ITHMS.Models;
using ITHMS.Models.Enums;

namespace ITHMS.Services
{
    // Stores and manages helpdesk data.
    public class HelpdeskStore
    {
        // Lists to store users, tickets and comments.
        public List<User> Users = new List<User>();
        public List<Ticket> Tickets = new List<Ticket>();
        public List<TicketComment> Comments =new List<TicketComment>();
        private int nextTicketId = 1;
        private int nextCommentId = 1;

        // Adds sample users to the system.
        public HelpdeskStore()
        {
            Users.Add(new User() { UserId = 1, FullName = "Demo Employee", Email = "employee@example.com", Role = UserRole.Employee });
            Users.Add(new User() { UserId = 2, FullName = "Demo Technician", Email = "technician@example.com", Role = UserRole.Technician });
            Users.Add(new User() { UserId = 3, FullName = "Demo Administrator", Email = "admin@example.com", Role = UserRole.Administrator }); 
        }

        // Returns all users.
        public List<User> GetUsers()
        {
            return Users;
        }

        // Returns all tickets.
        public List<Ticket> GetTickets()
        {
            return Tickets;
        }

        // Finds a ticket using its ID. retuen value might be null
        public Ticket? GetTicket(int id) 
        {
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.TicketId == id)
                {
                    return ticket;
                }
            }

            return null;
        }

        // Creates a new ticket.
        public Ticket CreateTicket(int userId, string title, string description, TicketPriority priority)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Title and description cannot be empty.");
            }

            Ticket ticket = new ()
            {
                TicketId = nextTicketId,
                UserId = userId,
                Title = title,
                Description = description,
                Priority = priority,
                Status = TicketStatus.Open,
                CreatedAt = DateTime.Now
            };

            Tickets.Add(ticket);
            nextTicketId++;
            return ticket;
        }

        // Changes a ticket's status.
        public void UpdateStatus(int ticketId, TicketStatus status)
        {
            Ticket? ticket = GetTicket(ticketId); //nullable 
            if (ticket == null)
            {
                throw new Exception("Ticket not found.");
            }
            ticket.Status = status;
        }

        // Assigns a technician to a ticket.
        public void AssignTechnician(int ticketId, int technicianId)
        {
            Ticket? ticket = GetTicket(ticketId);
            if (ticket == null)
            {
                throw new Exception("Ticket not found.");
            }
            ticket.AssignedTechnicianId = technicianId;
        }

        // Returns comments belonging to a ticket.
        public List<TicketComment> GetComments(int ticketId)
        {
            List<TicketComment> result =new List<TicketComment>();
            foreach (TicketComment comment in Comments)
            {
                if (comment.TicketId == ticketId)
                {
                    result.Add(comment);
                }
            }
            return result;
        }

        // Adds a comment to a ticket.
        public void AddComment(int ticketId, int userId, string message)
        {
            if (GetTicket(ticketId) == null)
            {
                throw new Exception("Ticket not found.");
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new Exception("Comment cannot be empty.");
            }

            TicketComment comment = new TicketComment()
            { CommentId = nextCommentId, TicketId = ticketId, UserId = userId, Message = message.Trim() };
            Comments.Add(comment);
            nextCommentId++;
        }
    }
}
