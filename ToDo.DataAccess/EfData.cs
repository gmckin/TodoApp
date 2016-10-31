using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DataAccess
{
  public class EfData
  {

    private TodoDBEntities1 db = new TodoDBEntities1();


    public List<Todo> GetTodoList()
    {
      return db.Todoes.ToList();
    }

    public bool InsertTodo(Todo todo)
    {
      db.Todoes.Add(todo);

      return db.SaveChanges() > 0;
    }

    public bool ChangeTodo(Todo todo)
    {
      var result = db.Todoes.SingleOrDefault(x => x.TodoId == todo.TodoId);

      if (result != null)
      {
        if (todo.TodoId != 0)
          result.TodoId = todo.TodoId;

        if (todo.Description != null)
          result.Description = todo.Description;

        if (todo.Completed != true)
          result.Completed = todo.Completed;
      }
      return db.SaveChanges() > 0;    
    }

    public bool DeleteTodo(Todo todo, int? id)
    {
      todo = db.Todoes.Where(t => t.TodoId == id).FirstOrDefault();
      db.Todoes.Remove(todo);      

      return db.SaveChanges() > 0;
    }

   
    public bool MarkComplete(Todo todo, EntityState state)
    {
      var entry = db.Entry<Todo>(todo);
      todo.Completed = true;
      entry.State = state;

      return db.SaveChanges() > 0;
    }
  }
}
