using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface ITodo
    {
        void Add(string item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }
}