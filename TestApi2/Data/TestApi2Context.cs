using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestApi2.Models
{
    public class TestApi2Context : DbContext
    {
        public TestApi2Context (DbContextOptions<TestApi2Context> options)
            : base(options)
        {
        }

        public DbSet<TestApi2.Models.OneUser> OneUser { get; set; }
    }
}
