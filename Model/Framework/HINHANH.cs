namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HINHANH")]
    public partial class HINHANH
    {
        [Key]
        [StringLength(50)]
        public string MASP { get; set; }

        [StringLength(100)]
        public string HINHSANPHAM { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
