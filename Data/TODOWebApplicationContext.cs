using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOWebApplication.Models;

namespace TODOWebApplication.Data
{
    public class TODOWebApplicationContext : DbContext
    {
        public TODOWebApplicationContext (DbContextOptions<TODOWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<TODOWebApplication.Models.TodoItem> Tasks { get; set; }
    }
}
