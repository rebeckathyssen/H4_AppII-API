using System;
using System.Collections.Generic;
using System.Text;
using H4_API.Domain.Model;
using H4_API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace H4_API.Infrastructure
{
    public class ExampleDbContext : DbContext, IDatabaseContext
    {
        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
