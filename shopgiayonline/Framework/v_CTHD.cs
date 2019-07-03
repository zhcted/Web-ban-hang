namespace shopgiayonline.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_CTHD
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        public int? Soluong { get; set; }

        public int? Gia { get; set; }

        public int? TongTien { get; set; }

        public int? MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        public int? SDTKH { get; set; }

        [StringLength(50)]
        public string EmailKH { get; set; }

        [StringLength(100)]
        public string DiaChiKH { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        public DateTime? NGAYDH { get; set; }
    }
}
