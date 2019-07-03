namespace Model.Framework
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

        [StringLength(50)]
        public string USERNAME { get; set; }

        [Key]
        [StringLength(50)]
        public string ADID { get; set; }

        [StringLength(100)]
        public string TENADMIN { get; set; }

        [StringLength(50)]
        public string MATKHAU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
