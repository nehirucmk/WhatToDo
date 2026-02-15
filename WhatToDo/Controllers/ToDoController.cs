using Microsoft.AspNetCore.Mvc;
using WhatToDo.Entities;

namespace WhatToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private List<ToDo> todos = new List<ToDo>()
        {
            new ToDo { Id = 1, Task = "To Wake Up", Category = "Daily", Priority = "5", Status= "Done"},
            new ToDo { Id = 2, Task = "Brushing Teeth", Category = "Daily", Priority = "5", Status="Done" },
            new ToDo { Id = 3, Task = "Code something", Category = "Job", Priority = "5", Status= "Pending" }
        };

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(todos);
        }

        [HttpGet("GetByCategory")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var categorized = new List<ToDo>();

            for (int i = 0; i < todos.Count; i++)
            {
                if (todos[i].Category == category)
                {
                    categorized.Add(todos[i]);
                }
            }

            return Ok(categorized);
        }
    

    [HttpPost("Add")]
        public IActionResult Add(ToDo newTodo)
        {
            newTodo.Id = todos.Max(t => t.Id) + 1;

            // listeye ekle
            todos.Add(newTodo);

            // listeyi geri dön
            return Ok(todos);
        }
    }
    }
