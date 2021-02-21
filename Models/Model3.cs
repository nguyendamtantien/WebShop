using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebBanHang1.Models
{
    public partial class Model3 : DbContext
    {
        public Model3()
            : base("name=Model3")
        {
        }

        public virtual DbSet<Hoa_Don> Hoa_Don { get; set; }
        public virtual DbSet<Loai_SP> Loai_SP { get; set; }
        public virtual DbSet<SP> SPs { get; set; }
        public virtual DbSet<SP_HD> SP_HD { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hoa_Don>()
                .HasMany(e => e.SP_HD)
                .WithRequired(e => e.Hoa_Don)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SP>()
                .HasMany(e => e.SP_HD)
                .WithRequired(e => e.SP)
                .WillCascadeOnDelete(false);
        }
    }
}
