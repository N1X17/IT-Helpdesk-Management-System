// Represents a comment associated with a support ticket.

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ITHMS.Models
{
    public class TicketComment
    {
        public int CommentId {  get; set; }
        public int TicketId {  get; set; }
        public int UserId {  get; set; }
        public required string Message { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public TicketComment() { }

        // Returns a shortened version of the comment.
        public string GetPreview()
        {
            if (Message.Length <= 50) {  return Message; }
            return Message.Substring(0,50) + "...";
        }
    }
}
