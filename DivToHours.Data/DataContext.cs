using DivToHours.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivToHours.Data
{
    public class DataContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Student> Student {get;set;}
        public DbSet<StudentTest> StudentTest { get; set; }


        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        


    }
}
