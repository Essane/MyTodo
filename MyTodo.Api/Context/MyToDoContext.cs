using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTodo.Api.Context
{
    public class MyTodoContext : DbContext
    {
        public MyTodoContext(DbContextOptions<MyTodoContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Memo> Memo { get; set; }
    }
}
