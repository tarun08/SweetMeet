using System.ComponentModel.DataAnnotations;

namespace SweetMeet.API.DTO
{
    public class RegisterUserDto
    {
        [Required]
        public string DisplayName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string Password { get; set; } = string.Empty;
    }
}
