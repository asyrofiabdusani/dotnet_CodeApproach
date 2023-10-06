using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstApproach.Models
{
    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(e => e.BrandId)
                .IsUnicode(false);

            modelBuilder.Entity<Brand>()
                .Property(e => e.BrandName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductId)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CategoryId)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.BrandId)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
