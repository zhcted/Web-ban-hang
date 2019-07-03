namespace shopgiayonline.Framework
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
            CTHDs = new HashSet<CTHD>();
            LOAIs = new HashSet<LOAI>();
        }

        [Key]
        public int MaSP { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(20)]
        public string ChatLieu { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        [StringLength(100)]
        public string Mota { get; set; }

        public string Motachitiet { get; set; }

        [StringLength(50)]
        public string DacDiem { get; set; }

        public int? GIA { get; set; }

        [StringLength(100)]
        public string HINHANH { get; set; }

        [StringLength(100)]
        public string HINHTONGHOP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAI> LOAIs { get; set; }
    }
}
