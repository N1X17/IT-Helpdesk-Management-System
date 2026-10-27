using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ITHMS.Models;
using ITHMS.Services;
using System.ComponentModel.DataAnnotations;

namespace ITHMS.Pages.Tickets
{
    public class Details : PageModel
    {
        public Ticket? Ticket { get; set; }
        public List<TicketComment> Comments { get; set; } = new();

        [BindProperty]
        public CommentInputModel NewComment { get; set; } = new();

        public class CommentInputModel
        {
            [Required(ErrorMessage = "Please enter a comment message.")]
            [StringLength(1000, ErrorMessage = "The comment must not exceed 1000 characters.")]
            public string Message { get; set; } = string.Empty;

            [Required(ErrorMessage = "User ID is required.")]
            public int UserId { get; set; }
        }

        public IActionResult OnGet(int id)
        {
            Ticket = HelpdeskStore.GetTicket(id);

            if (Ticket == null)
            {
                return NotFound();
            }

            Comments = HelpdeskStore.GetComments(id);
            return Page();
        }

        public IActionResult OnPostAddComment(int id)
        {
            Ticket = HelpdeskStore.GetTicket(id);

            if (Ticket == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                Comments = HelpdeskStore.GetComments(id);
                return Page();
            }

            try
            {
                HelpdeskStore.AddComment(id, NewComment.UserId, NewComment.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                Comments = HelpdeskStore.GetComments(id);
                return Page();
            }

            return RedirectToPage(new { id });
        }
    }
}