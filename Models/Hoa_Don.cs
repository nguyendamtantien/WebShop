namespace WebBanHang1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hoa_Don
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hoa_Don()
        {
            SP_HD = new HashSet<SP_HD>();
        }

        [Key]
        [StringLength(50)]
        public string mahd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaytao { get; set; }

        public int? tongtien { get; set; }

        [StringLength(50)]
        public string trangthai { get; set; }

        [StringLength(50)]
        public string ten_kh { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SP_HD> SP_HD { get; set; }
    }
}
