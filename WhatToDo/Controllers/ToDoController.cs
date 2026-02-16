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
            new ToDo { Id = 1, Task = "Waking Up", Category = "Daily", Priority = "5", Status= "Done"},
            new ToDo { Id = 2, Task = "Brushing Teeth", Category = "Daily", Priority = "5", Status="Done" },
            new ToDo { Id = 3, Task = "Coding", Category = "Job", Priority = "4", Status= "Pending" }
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

            // add to list
            todos.Add(newTodo);

            // return the new list
            return Ok(todos);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            // find the task you want to delete
            var itemToDelete = todos.FirstOrDefault(t => t.Id == id);

            // error text if not found
            if (itemToDelete == null)
            {
                return NotFound("id not found");
            }

            // delete the item
            todos.Remove(itemToDelete);

            // return the new list
            return Ok(todos);
        }

        [HttpPut("Update")]
        public IActionResult Update(ToDo updatedTodo)
        {
            // find the task using the id
            var existingTodo = todos.FirstOrDefault(t => t.Id == updatedTodo.Id);

            // error text if not found
            if (existingTodo == null)
            {
                return NotFound("id not found");
            }

            // update
            existingTodo.Task = updatedTodo.Task;
            existingTodo.Category = updatedTodo.Category;
            existingTodo.Priority = updatedTodo.Priority;
            existingTodo.Status = updatedTodo.Status;

            // return the new list
            return Ok(todos);
        }

        // sorting by date
        [HttpGet("SortedByDate")]
        public IActionResult GetSorted()
        {
            return Ok(todos.OrderBy(t => t.DueDate).ToList());
        }

        // overdue task controller
        [HttpGet("Overdue")]
        public IActionResult GetOverdue()
        {
            var overdueTasks = todos.Where(t => t.IsOverdue).ToList();

            if (overdueTasks.Count == 0)
                return Ok(new { Message = "no overdue tasks!!" });

            return Ok(overdueTasks);
        }
    }
}