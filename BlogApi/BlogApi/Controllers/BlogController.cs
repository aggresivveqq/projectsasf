using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApi.Data;
using BlogApi.Models;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BlogController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //Create
        [HttpPost]
        public JsonResult CreateEdit(BlogModel model) 
        {
            if(model == null)
            {
                return new JsonResult(BadRequest("Model is null"));
            }
            var blogApi = context.Blog.Find(model.id);
            if (blogApi == null) {
            context.Blog.Add(model);
            
            }
            else
            {
                blogApi.Name = model.Name;
                blogApi.Description = model.Description;
                blogApi.Category = model.Category;
            }
            context.SaveChanges();
            return new JsonResult(Ok(model));
        }
        //Get
        [HttpGet("{id}")]
        public IActionResult Get(Guid id) {
            var blog = context.Blog.Find(id);
            if (blog== null) {
                return NotFound();


            }
            return Ok(blog);

        }
        [HttpDelete("{id}")]
        public JsonResult Delete(Guid id) {

            var result = context.Blog.Find(id);
            if (result == null) {
                return new JsonResult(NotFound());

               
            }
            context.Blog.Remove(result);
            context.SaveChanges();
            return new JsonResult(result); 

        }
        [HttpGet("all")]
        public JsonResult GetAll()
        {
            var result = context.Blog.ToList();
            return new JsonResult(result);


        }
    }
}
