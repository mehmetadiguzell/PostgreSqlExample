using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreSqlExample.Models
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
