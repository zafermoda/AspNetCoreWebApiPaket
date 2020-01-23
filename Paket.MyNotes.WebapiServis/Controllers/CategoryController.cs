using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Paket.MyNotes.Business.Abstract;
using Paket.MyNotes.Entities;
using Paket.MyNotes.WebapiServis.Filters;
using Paket.MyNotes.WebapiServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace Paket.MyNotes.WebapiServis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
                          
        // GET: api/Category
        [HttpGet]
        public List<Category> Get()
        {
            return categoryService.GetAll().ToList();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Category> result = new ServiceResponse<Category>
            {
                Entities = categoryService.GetAll().ToList(),
                IsSuccessFul = true
            };
            result.EntitiesCount = result.Entities.Count();
            
            return Ok(result);
        }

        // POST: api/Category
        [HttpPost]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Post([FromBody] CategoryModel model)
        {
            Category category = new Category
            {
                CategoryName = model.CategoryName,
                Username = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
            categoryService.Add(category);
            ServiceResponse<Category> result = new ServiceResponse<Category>
            {
                Entity = category,
                IsSuccessFul = true
            };
            return Ok(result);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        [CategoryException]
        [CategoryValidate]
        public IActionResult Put(int id, [FromBody] CategoryModel model)
        {
            ServiceResponse<Category> result = new ServiceResponse<Category>();            
            var category = categoryService.GetById(id);
            if (category == null)
            {
                result.HasError = true;
                result.Errors.Add("Kategori bulunamadı!");
                return BadRequest(result);
            }

            category.CategoryName = model.CategoryName;

            categoryService.Update(category);
            result.IsSuccessFul = true;
            result.Entity = category;
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Category> result = new ServiceResponse<Category>();
            var category = categoryService.GetById(id);
            if (category == null)
            {
                result.HasError = true;
                result.Errors.Add("Kategori bulunamadı!");
                return BadRequest(result);
            }
            categoryService.Delete(category);
            result.IsSuccessFul = true;
            return Ok(result);
        }
    }
}
