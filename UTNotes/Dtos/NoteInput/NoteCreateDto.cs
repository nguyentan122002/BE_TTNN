using System.ComponentModel.DataAnnotations;

namespace UTNotes.Dtos.Note
{
    public class NoteCreateDto
    {
        [Required]
        public string Headline { get; set; }

        public string Description { get; set; }
    }
}
