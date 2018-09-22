using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_mvc_csharp_problem_soumya_ramteke.Models;

namespace todo_mvc_csharp_problem_soumya_ramteke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        // Reposition responsible for fetchin and adding to 
        // database / collection
        INoteRepository noteRepo = null ;
        // intialise this repo with a dependency injection
        public TodoController(INoteRepository _noteRepo){
            this.noteRepo = _noteRepo;
        }
        // GET api/todo
        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            var notes = noteRepo.RetrieveAllNotes();
            if(notes.Count > 0){
                return Ok(notes);
            }
            else{
                return Ok("No notes available..");
            }
        }

        // GET api/todo/5
        [HttpGet("{id:int}")]
        public ActionResult<Note> Get(int id)
        {
            var noteById = noteRepo.RetrieveNote(id);
            if (noteById != null)
            {
                return Ok(noteById);
            }
            else
            {
                return NotFound($"Note with {id} not found.");
            }
        }

        [HttpGet("{text}")]
        public ActionResult<Note> Get(string text,[FromQuery] string type)
        {
            List<Note> listWithText = noteRepo.RetrieveNote(text, type);
            if(listWithText == null){
                return BadRequest($"Type : {type} or Text : {text}  is invalid.");
            }
            else if(listWithText.Count == 0){
                return NotFound($"Notes with {type} = {text} not found.");
            }
            else{
                return Ok(listWithText);
            }
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            if(ModelState.IsValid){
                bool result = noteRepo.CreateNote(note);
                if (result)
                {
                    return Created($"/todo/{note.NoteId}",note);
                }
                else
                {
                    return BadRequest("Note already exists, Try again");
                }
            }
            return BadRequest("Invalid Format");
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Note note)
        {
            if(ModelState.IsValid){
                bool result = noteRepo.EditNote(id, note);
                if(result){
                    return Created("/api/todo", note);
                }
                else{
                    return NotFound($"Note with {id} not found.");
                }
            }
            return BadRequest("Invalid Format");
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = noteRepo.DeleteNote(id);
            if(result){
                return Ok($"note with id : {id} deleted");
            }
            else{
                return NotFound($"Note with {id} not found.");
            }
        }
    }
}
