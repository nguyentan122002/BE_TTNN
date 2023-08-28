using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTNotes.Models
{
    [Table("Notes", Schema = "dbo")]
    public class Notes
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public Guid? ModifiedBy { get; set; }

        public string Headline { get; set; }

        public string Description { get; set; }

    }
}
