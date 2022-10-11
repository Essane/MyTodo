using Microsoft.EntityFrameworkCore;
using MyTodo.Api.Context.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodo.Api.Context.Repository
{
    public class ToDoRepository : Repository<ToDo>, IRepository<ToDo>
    {
        public ToDoRepository(MyTodoContext dbContext) : base(dbContext)
        {
        }
    }
}
