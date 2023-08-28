using System.ComponentModel.DataAnnotations;

namespace UTNotes.Dtos.Account
{
    public class LoginRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }
    }
}
