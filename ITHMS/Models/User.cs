
// Represents a system user and their assigned role.

using ITHMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ITHMS.Models
{
    public class User
    {
        public int UserId {get; set;}

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = "";
        public UserRole Role { get; set; }

        public User()
        { 
        }

        public User (int userId, string fullName, string email, UserRole role)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            Role = role;
        }

        // Checks whether the user has an IT support role.
        public bool IsSupportStaff()
        {
            return Role == UserRole.Technician || Role == UserRole.Administrator;
        }
    }
}

