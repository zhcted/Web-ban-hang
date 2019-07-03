namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [Key]
        [StringLength(50)]
        public string MADONHANG { get; set; }

        [StringLength(50)]
        public string MASP { get; set; }

        [StringLength(50)]
        public string ADID { get; set; }

        [StringLength(50)]
        public string MAKH { get; set; }

        public DateTime? NGAYDH { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual QUANTRI QUANTRI { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
