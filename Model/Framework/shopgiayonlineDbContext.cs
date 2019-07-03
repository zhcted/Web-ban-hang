namespace Model.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class shopgiayonlineDbContext : DbContext
    {
        public shopgiayonlineDbContext()
            : base("name=shopgiayonlineDbContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<CHITIETSANPHAM> CHITIETSANPHAMs { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<HINHANH> HINHANHs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<QUANTRI> QUANTRIs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<Sanpham1> Sanphams1 { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETSANPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETSANPHAM>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETSANPHAM>()
                .Property(e => e.CHATLIEU)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MADONHANG)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.ADID)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<HINHANH>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.CHITIETSANPHAMs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUANTRI>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<QUANTRI>()
                .Property(e => e.ADID)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.LOAISP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETSANPHAMs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasOptional(e => e.HINHANH1)
                .WithRequired(e => e.SANPHAM);
        }
    }
}
