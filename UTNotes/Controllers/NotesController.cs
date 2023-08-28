using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTNotes.Dtos;
using UTNotes.Dtos.Account;
using UTNotes.Dtos.Note;
using UTNotes.Interfaces;
using UTNotes.Models;

namespace UTNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService) 
        {
            _notesService = notesService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                var data = await _notesService.GetAllNotes();
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNote(NoteCreateDto noteCreateDto) 
        { 
            try
            {
                var data = await _notesService.CreateNote(noteCreateDto);
                return Ok("Created successfully notes");
            }
            catch
            {
                return BadRequest("Create failed notes");
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetNotes(Guid id)
        {

                var data = await _notesService.GetNotes(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound();         
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateNote(NoteUpdateDto noteUpdateDto)
        {
            var data = await _notesService.GetNotes(noteUpdateDto.Id);

            if (data == null ) 
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _notesService.UpdateNote(noteUpdateDto);
                    return Ok("Updated successfully notes");
                }
                catch
                {
                    return BadRequest("Updated failed notes");
                }
            }        
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var data = await _notesService.GetNotes(id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _notesService.DeleteNote(id);
                    return Ok("Deleted successfully notes");
                }
                catch
                {
                    return BadRequest("Deleted failed notes");
                }
            }
        }
    }
}
