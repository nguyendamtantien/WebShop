using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang1.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName   { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [MinLength(6,ErrorMessage ="Chieu dai toi da 6")]
        [Required]
        public string Password { get; set; }
        [Required]
        public int sđt{ get; set; }
        [Required]
        public string diachi { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Mat khau khong khop")]
        public string Confirmpass { get; set; }

    }
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}