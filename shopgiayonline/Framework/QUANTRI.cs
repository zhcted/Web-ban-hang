namespace shopgiayonline.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANTRI")]
    public partial class QUANTRI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUANTRI()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        public int AdID { get; set; }

        [StringLength(50)]
        public string TenAdmin { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAdmin { get; set; }

        [StringLength(50)]
        public string UserAdmin { get; set; }

        [StringLength(50)]
        public string MatKhauAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
