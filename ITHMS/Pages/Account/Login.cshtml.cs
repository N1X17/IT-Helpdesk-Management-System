using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ITHMS.Pages.Account
{
    public class LoginModel : PageModel
    {
        public LoginInput Input { get; set; }
        public string? Message { get; set; }

        public class LoginInput
        {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid Email.")]
            public string Email { get; set; } = "";

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = "";
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid) {  return; }
            Message = "Login is not available yet.";
        }
    }
}
