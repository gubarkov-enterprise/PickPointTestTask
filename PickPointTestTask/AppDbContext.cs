using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PickPointTestTask.Models;
using PickPointTestTask.Models.Entities;

namespace PickPointTestTask
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PostamatEntity> Postamats { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>()
                .Property(e => e.Products)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<OrderEntity>()
                .HasOne(order => order.Postamat)
                .WithMany(entity => entity.Orders);

            modelBuilder.Entity<PostamatEntity>()
                .HasData(
                    new PostamatEntity {Id = 1, Number = "AA1", Address = "Some address", OnDuty = false},
                    new PostamatEntity {Id = 2, Number = "BB4", Address = "Another address", OnDuty = true}
                );
        }
    }
}