namespace shopgiayonline.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLShoesEntities : DbContext
    {
        public QLShoesEntities()
            : base("name=QLShoesEntities")
        {
        }

        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAI> LOAIs { get; set; }
        public virtual DbSet<QUANTRI> QUANTRIs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<Loai_sp> Loai_sp { get; set; }
        public virtual DbSet<v_CTHD> v_CTHD { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DONHANG>()
                .Property(e => e.TongTien)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MatKhauKH)
                .IsUnicode(false);

            modelBuilder.Entity<QUANTRI>()
                .Property(e => e.UserAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.ChatLieu)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HINHTONGHOP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.LOAIs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);
        }
    }
}
