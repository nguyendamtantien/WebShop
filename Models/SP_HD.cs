namespace WebBanHang1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SP_HD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string masp { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string mahd { get; set; }

        public int? sl { get; set; }

        public int? gia { get; set; }

        public virtual Hoa_Don Hoa_Don { get; set; }

        public virtual SP SP { get; set; }
    }
}
