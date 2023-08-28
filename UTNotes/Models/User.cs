using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTNotes.Models
{
    [Table("User", Schema = "dbo")]

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
