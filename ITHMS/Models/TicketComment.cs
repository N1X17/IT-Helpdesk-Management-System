// Represents a comment associated with a support ticket.

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ITHMS.Models
{
    public class TicketComment
    {
        public int CommentId {  get; set; }

        [Range (1, int.MaxValue)]
        public int TicketId {  get; set; }

        [Range(1, int.MaxValue)]
        public int UserId {  get; set; }

        [Required(ErrorMessage = "Comment is required.")]
        [StringLength(1000, MinimumLength = 2)]
        public string Message { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public TicketComment() { }

        public TicketComment(int ticketId, int userId, string message)
        {
            TicketId = ticketId;
            UserId = userId;
            Message = message;
        }

        // Returns a shortened version of the comment.
        public string GetPreview()
        {
            return Message.Length <= 50 ? Message: Message[..50] + "...";
        }
    }
}
