using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UTNotes.Context;
using UTNotes.Dtos;
using UTNotes.Dtos.Account;
using UTNotes.Dtos.Note;
using UTNotes.Interfaces;
using UTNotes.Models;

namespace UTNotes.Services
{
    public class NotesService : INotesService
    {
        private UTDbContext _context;

        public NotesService(UTDbContext context) 
        { 
            _context = context;
        }
        public async Task<List<NotesDto>> GetAllNotes()
        {
            var user = await _context.Notes.Where(o => o.IsDeleted == false).Select(note => new NotesDto
            {
                Id = note.Id,
                Headline = note.Headline,
                Description = note.Description,
            }).ToListAsync();
            return user;
        }

        public async Task<NotesDto> GetNotes(Guid id)
        {
            var note = await _context.Notes.SingleOrDefaultAsync(note => note.Id == id);
            if (note != null)
            {
                if (note.IsDeleted == false)
                {
                    return new NotesDto { Id = note.Id, Headline = note.Headline, Description = note.Description };
                }
                return null;
            }
            return null;
        }

        public  async Task<Notes> CreateNote(NoteCreateDto noteCreateDto)
        {
            var note = new Notes
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                Headline = noteCreateDto.Headline,
                Description = noteCreateDto.Description,
            };
            _context.Add(note);
            _context.SaveChanges();
            return note;
        }
  
        public async Task UpdateNote(NoteUpdateDto noteUpdateDto)
        {
            var note = await _context.Notes.SingleOrDefaultAsync(o => o.Id == noteUpdateDto.Id);
            if (note != null)
            {
                if (note.IsDeleted == false)
                {
                    note.ModifiedAt = DateTime.UtcNow;
                    note.Headline = noteUpdateDto.Headline;
                    note.Description = noteUpdateDto.Description;
                    _context.SaveChanges();
                }
            }
        }

        public async Task DeleteNote(Guid id)
        {
            var note = await _context.Notes.SingleOrDefaultAsync(note => note.Id == id);
            if (note != null)
            {
                note.IsDeleted = true;
                _context.SaveChanges();
            }
        }
    }
}
