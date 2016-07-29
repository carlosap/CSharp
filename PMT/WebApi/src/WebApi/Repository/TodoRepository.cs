using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using WebApi.Interfaces;
using WebApi.Models;
using System.IO;
using WebApi.Extensions.Strings;

namespace WebApi.Repository
{
    public class TodoRepository : ITodo
    {
        static ConcurrentDictionary<string, TodoItem> _todos =  new ConcurrentDictionary<string, TodoItem>();
        public IEnumerable<TodoItem> GetAll()
        {
            var directoryPath = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "DataSource", "cache","todo");
            var openItems = directoryPath.GetFileNames("*");
            foreach (var item in openItems)
                _todos[item] = new TodoItem() { Key = "test", Name = "dfdf", IsComplete = true };

            return _todos.Values;
        }

        public void Add(string item)
        {
            throw new NotImplementedException();
        }
        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;

        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public TodoItem Remove(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.Key] = item;
        }


    }
}