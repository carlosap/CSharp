using System.Collections.Generic;
using WebApi.Models;
using WebApi.Interfaces;
using Microsoft.AspNet.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController(ITodo todoItems)
        {
            TodoItems = todoItems;
        }
        public ITodo TodoItems { get; set; }

        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return new ObjectResult(null);
            }
            return new ObjectResult(item);
        }
    }


}