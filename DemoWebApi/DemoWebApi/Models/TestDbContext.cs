using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    public class TestDbContext :DbContext
    {
        public TestDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
