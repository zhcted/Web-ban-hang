namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanphams")]
    public partial class Sanpham1
    {
        [Key]
        public string MASP { get; set; }

        public string TENSP { get; set; }

        public string LOAISP { get; set; }

        public string MOTA { get; set; }

        public int GIA { get; set; }

        public string HINHANH { get; set; }
    }
}
