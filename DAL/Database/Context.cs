using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Database
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            Database.EnsureCreated();
        }

        public Device Device { get; set; }
        public Document Document { get; set; }
    }
}
