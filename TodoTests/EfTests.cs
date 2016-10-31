using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Data;
using System.Globalization;
using System.Data.Entity;
using ToDo.DataAccess;

namespace TodoTests
{
  public class EfTests
  {
    private TodoDBEntities1 db = new TodoDBEntities1();
    [Fact]
    public void Test_InsertTodo()
    {
      EfData data = new EfData();
      
      var expected = new Todo() { Description = "Test Insert", Completed = false };

      var actual = data.InsertTodo(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_GetTodoes()
    {
      var data = new EfData();
      var actual = data.GetTodoList();

      Assert.NotNull(actual);
    }

    [Fact]
    public void Test_MarkCompleted()
    {
      var data = new EfData();
      var expected = new Todo() { TodoId = 1, Description = "Create database", Completed = true };
      var actual = data.MarkComplete(expected, System.Data.Entity.EntityState.Added);

      Assert.True(actual);
    }

    [Fact]
    public void Test_DeleteTodo()
    {
      var id = 5;
      var expected = db.Todoes.Where(x => x.TodoId == id).FirstOrDefault();
      var data = new EfData();

      var actual = data.DeleteTodo(expected, id);

      Assert.True(actual);
    }
  }
}
