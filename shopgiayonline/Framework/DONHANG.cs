namespace shopgiayonline.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        public int MaDH { get; set; }

        public int? MaKH { get; set; }

        public DateTime? NGAYDH { get; set; }

        public int? AdID { get; set; }

        [StringLength(50)]
        public string TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual QUANTRI QUANTRI { get; set; }
    }
}
