using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace kiemtra2.Models
{
    public partial class QLSanPhamDB : DbContext
    {
        public QLSanPhamDB()
            : base("name=QLSanPhamDB")
        {
        }

        public virtual DbSet<Catalogy> Catalogy { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogy>()
                .Property(e => e.CatalogyID)
                .IsFixedLength();

            modelBuilder.Entity<Catalogy>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Catalogy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Product>()
                .Property(e => e.CatalogyID)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);
        }
    }
}
