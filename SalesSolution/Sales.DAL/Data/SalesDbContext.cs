﻿using Microsoft.EntityFrameworkCore;
using Sales.DAL.Data.Seeds;
using Sales.DAL.Entities;

namespace Sales.DAL.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            setDefaultValues(modelBuilder);

            Seed.CreateElementType(modelBuilder);
            Seed.CreateOrder(modelBuilder);
            Seed.CreateWindow(modelBuilder);
            Seed.CreateSubElement(modelBuilder);
        }

        private void setDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>()
                .Property(b => b.UpdatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>()
                .ToTable(tb => tb.HasTrigger("tr_orders_update"));

            modelBuilder.Entity<Window>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Window>()
                .Property(b => b.UpdatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Window>()
                .ToTable(tb => tb.HasTrigger("tr_windows_update"));

            modelBuilder.Entity<SubElement>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SubElement>()
                .Property(b => b.UpdatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SubElement>()
                .ToTable(tb => tb.HasTrigger("tr_sub_elements_update"));

            modelBuilder.Entity<ElementType>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ElementType>()
                .Property(b => b.UpdatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SubElement>()
                .Property(b => b.Quantity)
                .HasDefaultValue(1);

            modelBuilder.Entity<SubElement>()
                .ToTable(tb => tb.HasTrigger("tr_element_types_update"));
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
    }
}
