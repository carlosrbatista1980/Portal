using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portal.Data.Data;


namespace Portal.Data
{
    public class PortalDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Shop> Shop { get; set; }

        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable(nameof(Account));
            modelBuilder.Entity<Shop>().ToTable(nameof(Shop));
            
            //<Entities Configuration>
            modelBuilder.Entity<Account>().Property(f => f.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Shop>().Property(f => f.Id).ValueGeneratedOnAdd();
            //<Entities Configuration>

            //<Adding default group>
            modelBuilder.Entity<IdentityRole>().HasData(new { Id = "1", Name = "admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityUser>().HasData(new
            {
                Id = "1",
                UserName = "admin",
                NormalizedName = "ADMIN",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            });

            //</Adding default group>
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
