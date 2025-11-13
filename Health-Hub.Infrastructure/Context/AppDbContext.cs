using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health_Hub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Health_Hub.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Questionario> Questionario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().ToTable("GS_USUARIO");

            modelBuilder.Entity<Questionario>().ToTable("GS_QUESTIONARIO");

        }

    }
}
