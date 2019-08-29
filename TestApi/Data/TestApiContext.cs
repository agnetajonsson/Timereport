using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApi.Model;

namespace TestApi.Models
{
    public class TestApiContext : DbContext
    {
        public TestApiContext (DbContextOptions<TestApiContext> options)
            : base(options)
        {
        }

        public DbSet<TestApi.Model.OneUser> OneUser { get; set; }
    }
}
