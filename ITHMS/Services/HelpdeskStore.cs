
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
            Users.Add(new User(1, "Demo Employee","employee@example.com", UserRole.Employee));
            Users.Add(new User(2, "Demo Technician","technician@example.com", UserRole.Technician));
            Users.Add(new User(3, "Demo Administrator","admin@example.com", UserRole.Administrator));
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
            Ticket ticket = new Ticket(userId, title, description);
            ticket.TicketId = nextTicketId;
            ticket.Priority = priority;
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
            TicketComment comment = new TicketComment(ticketId, userId, message);
            comment.CommentId = nextCommentId;
            Comments.Add(comment);
            nextCommentId++;
        }
    }
}
