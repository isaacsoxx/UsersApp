using System.ComponentModel.DataAnnotations;

namespace UsersApp.DTOs.Request
{
    public class AuthenticationRequestDto
    {
        [Required(ErrorMessage = "Email address must be provided.")]
        public string EmailAddress { get; set; } = String.Empty;
        [Required(ErrorMessage = "Password must be provided.")]
        public string Password { get; set; } = String.Empty;
    }
}
