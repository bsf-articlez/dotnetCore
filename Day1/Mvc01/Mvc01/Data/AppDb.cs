using Microsoft.EntityFrameworkCore;
using Mvc01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Product> Products { get; set; } // Map table
        public DbSet<Person> People { get; set; } // Map table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().OwnsOne(x => x.Home);
            modelBuilder.Entity<Person>().OwnsOne(x => x.Office);

            modelBuilder.Entity<Machine>()
                .Property(x => x.AcceptableCoins)
                .HasConversion(
                    x => string.Join(',', x),
                    x => x.Split(new[] { ',' }).Select(y => decimal.Parse(y)).ToArray()
                )
                .HasMaxLength(50);
        }
    }
}
