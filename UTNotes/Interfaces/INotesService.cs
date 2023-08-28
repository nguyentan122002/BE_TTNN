using Microsoft.AspNetCore.Mvc;
using UTNotes.Dtos;
using UTNotes.Dtos.Note;
using UTNotes.Models;

namespace UTNotes.Interfaces
{
    public interface INotesService
    {
        Task<List<NotesDto>> GetAllNotes();

        Task<NotesDto> GetNotes(Guid id);

        Task<Notes> CreateNote(NoteCreateDto noteCreateDto);

        Task UpdateNote(NoteUpdateDto noteUpdateDto);

        Task DeleteNote(Guid id);
    }
}
