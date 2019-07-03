namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETSANPHAM")]
    public partial class CHITIETSANPHAM
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MASP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MANCC { get; set; }

        [StringLength(100)]
        public string TENNCC { get; set; }

        [StringLength(20)]
        public string CHATLIEU { get; set; }

        [StringLength(500)]
        public string MOTACHITIET { get; set; }

        [StringLength(50)]
        public string DACDIEM { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
