
// Represents a system user and their assigned role.

using ITHMS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ITHMS.Models
{
    public class User
    {
        public int UserId {get; set;}
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; }

        public User()
        { 
        }

        // Checks whether the user has an IT support role.
        public bool IsSupportStaff()
        {
            return Role == UserRole.Technician || Role == UserRole.Administrator;
        }
    }
}

