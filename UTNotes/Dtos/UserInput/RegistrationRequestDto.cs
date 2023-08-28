using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace UTNotes.Dtos.Account
{
    public class RegistrationRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ComfirmPassword { get; set; }
    }
}
