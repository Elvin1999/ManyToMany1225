using ManyToMany1225.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany1225.DataAccess
{
    //In Core We need
    //EntityFrameworkCore
    //EntityFrameworkCore.SqlServer
    //EntityFrameworkCore.Tools
    //EntityFrameworkCore.Design   6.0.0
    
    public class MyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyManyDb1225;Integrated Security=True;");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
