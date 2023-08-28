using System.ComponentModel.DataAnnotations;

namespace UTNotes.Dtos.Note
{
    public class NoteUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        public string Headline { get; set; }

        public string Description { get; set; }
    }
}
