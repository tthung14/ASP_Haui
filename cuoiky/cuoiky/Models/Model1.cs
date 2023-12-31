using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cuoiky.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<Phong> Phong { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblUser>()
                .Property(e => e.username)
                .IsUnicode(false);
        }
    }
}
