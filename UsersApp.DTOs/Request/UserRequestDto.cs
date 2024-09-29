using System.ComponentModel.DataAnnotations;

namespace UsersApp.DTOs.Request
{
    public class UserRequestDto
    {
        [Range(10000000, 999999999, ErrorMessage = "Please provide a valid ID.")]
        public int UserId { set; get; }
        [Required(ErrorMessage = "Email address must be provided.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { set; get; } = String.Empty;
        [Required(ErrorMessage = "A valid name should be provided")]
        public string FirstName { set; get; } = String.Empty;
        public string? LastName { set; get; }
        [Required(ErrorMessage = "You need to provide a password to secure your account.")]
        public string Password { set; get; } = String.Empty;
    }
}
