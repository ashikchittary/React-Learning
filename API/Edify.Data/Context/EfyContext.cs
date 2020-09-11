using Edify.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edify.Data.Context
{
    public class EfyContext : DbContext
    {
        public EfyContext(DbContextOptions<EfyContext> options) : base(options)

        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Customer>()
            //  .HasKey(p => new { p.Id});
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
