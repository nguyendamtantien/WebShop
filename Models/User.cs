namespace WebBanHang1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int kh_id { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaysinh { get; set; }

        public int? sđt { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string quyen { get; set; }

        [StringLength(50)]
        public string trangthai_kh { get; set; }
    }
}
