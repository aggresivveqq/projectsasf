using Microsoft.AspNetCore.Mvc;
using TaskManagerCrud.Models;
using TaskManagerCrud.Services;

namespace TaskManagerCrud.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext context;
        public TaskController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var tasks = context.Tasks.ToList();
        
            return View(tasks);
        }
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(TaskModelDto taskModelDto)
        {
            if (ModelState.IsValid)
            {
                var task = new TaskModel
                {
                    Name = taskModelDto.Name,
                    Description = taskModelDto.Description,
                    DueTime = taskModelDto.DueTime,
                    IsCompleted = taskModelDto.IsCompleted,
                    CreatedDate = DateTime.Now,
                };

                context.Tasks.Add(task);
                context.SaveChanges(); 
            }
            return RedirectToAction("Index");


        }
        public IActionResult Edit(Guid id) {
        var task = context.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null) {
                return RedirectToAction("Index");
            }

            var taskDto = new TaskModelDto
            {
                Name = task.Name,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                DueTime = task.DueTime,
            };
   
            return View(taskDto);
        }
        [HttpPost]
        public IActionResult Edit(Guid id,TaskModelDto taskModelDto)
        {
            var task = context.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid) {
             return View(taskModelDto);
            }
            task.Name = taskModelDto.Name;
            task.Description = taskModelDto.Description;
            task.IsCompleted = taskModelDto.IsCompleted;
            task.DueTime = taskModelDto.DueTime;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id) {
            var task = context.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return RedirectToAction("Index");
            }
            context.Tasks.Remove(task); 
            context.SaveChanges(true);
            return RedirectToAction("Index");

        }
    }
}
