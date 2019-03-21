using Assignment3_S19.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3_S19.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(600);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<UserStock> UserStocks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasIndex(b => b.Symbol)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .HasIndex(b => b.Name);

            modelBuilder.Entity<Company>()
                .HasIndex(b => b.IexId)
                .IsUnique();

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(b => b.UserStocks)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);
        }

    }
}
