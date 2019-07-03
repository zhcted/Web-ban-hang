namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETSANPHAMs = new HashSet<CHITIETSANPHAM>();
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        [StringLength(50)]
        public string MASP { get; set; }

        [StringLength(100)]
        public string TENSP { get; set; }

        [StringLength(50)]
        public string LOAISP { get; set; }

        [StringLength(100)]
        public string MOTA { get; set; }

        public int? GIA { get; set; }

        [StringLength(100)]
        public string HINHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSANPHAM> CHITIETSANPHAMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }

        public virtual HINHANH HINHANH1 { get; set; }
    }
}
