namespace WebBanHang1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SP")]
    public partial class SP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SP()
        {
            SP_HD = new HashSet<SP_HD>();
        }

        [Key]
        [StringLength(50)]
        public string masp { get; set; }

        [StringLength(50)]
        public string ten { get; set; }

        public int? gia { get; set; }

        public int? giakm { get; set; }

        public int? sl { get; set; }

        public string mota { get; set; }

        [StringLength(50)]
        public string anh { get; set; }

        [StringLength(50)]
        public string maloai { get; set; }

        public virtual Loai_SP Loai_SP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SP_HD> SP_HD { get; set; }
    }
}
