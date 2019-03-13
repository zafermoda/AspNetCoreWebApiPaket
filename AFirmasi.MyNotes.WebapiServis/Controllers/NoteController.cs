using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AFirmasi.MyNotes.Business.Abstract;
using AFirmasi.MyNotes.Entities;
using AFirmasi.MyNotes.WebapiServis.Filters;
using AFirmasi.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFirmasi.MyNotes.WebapiServis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private INoteService noteService;
               

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;            
        }

        // GET: api/Note
        [HttpGet]
        [CurrentAuth]
        [NoteException]
        public IActionResult Get()
        {
            //var currentUserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ServiceResponse<Note> result = new ServiceResponse<Note>
            {
                Entities = noteService.GetAllByUser().ToList(),
                IsSuccessFul = true                
            };
            result.EntitiesCount = result.Entities.Count();

            //string userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //string userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            
            //throw new Exception("Kendi elimizle hata fırlattık!");
            return Ok(result);            
        }

        // GET: api/Note/5
        [HttpGet("{id}", Name = "GetBy")]
        [NoteException]
        [CurrentAuth]
        public IActionResult Get(int id)
        {
            ServiceResponse<Note> result = new ServiceResponse<Note>
            {
                Entity = noteService.GetNoteWithCategoryByUser(id),//Not detayını categori ismi ile birlikte gösterir.            
                IsSuccessFul = true
            };

            return Ok(result);
        }

        // GET: api/Note/ByCategoryId/2
        [HttpGet("ByCategoryId/{categoryId?}")]
        [NoteException]
        [CurrentAuth]
        public IActionResult ByCategoryId(int categoryId = 1)
        {
            ServiceResponse<Note> result = new ServiceResponse<Note>
            {
                Entities = noteService.GetByCategoryIdByUser(categoryId),
                IsSuccessFul = true
            };
            result.EntitiesCount = result.Entities.Count();
            return Ok(result);
        }

        // POST: api/Note
        [HttpPost]
        [NoteException]
        [CurrentAuth]
        [NoteValidate]
        public IActionResult Post([FromBody] NoteModel model)
        {
            Note note = new Note
            {
                CategoryId = model.CategoryId.Value,
                NoteTitle = model.NoteTitle,
                NoteDescription = model.NoteDescription                
            };

            noteService.Add(note);
            ServiceResponse<Note> result = new ServiceResponse<Note>
            {
                Entity = note,
                IsSuccessFul = true
            };

            return Ok(result);
        }

        // PUT: api/Note/5
        [HttpPut("{id}")]
        [NoteException]
        [CurrentAuth]
        [NoteValidate]
        public IActionResult Put(int id, [FromBody] NoteModel model)
        {
            ServiceResponse<Note> result = new ServiceResponse<Note>();
            var note = noteService.GetByIdByUser(id);
            if (note == null)
            {
                result.HasError = true;
                result.Errors.Add("Not bulunamadı!");                
                return BadRequest(result);
            }

            note.CategoryId = model.CategoryId.Value;
            note.NoteTitle = model.NoteTitle;
            note.NoteDescription = model.NoteDescription;

            noteService.Update(note);
            result.IsSuccessFul = true;
            result.Entity = note;
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [NoteException]
        [CurrentAuth]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Note> result = new ServiceResponse<Note>();
            var note = noteService.GetByIdByUser(id);
            if (note == null)
            {
                result.HasError = true;
                result.Errors.Add("Not bulunamadı!");
                return BadRequest(result);
            }
            noteService.Delete(note);
            result.IsSuccessFul = true;
            return Ok(result);
        }
    }
}
