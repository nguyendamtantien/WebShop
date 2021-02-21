using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebBanHang1.Models;
using WebGrease.Css.Ast;

namespace WebBanHang1.Models
{
    public class UserManager
    {
        Model3 db = new Model3();
        public Boolean CheckUserName(string ten)
        {
            List<User> registers = db.Users.ToList();
            var usersName = registers.Where(n => n.UserName == ten );
            //foreach (var item in usersName)
            //{
            //    if (ten == item.ToString())
            //    {
            //        return false;
            //    }
            //}
            //return true;
            if (usersName.Count() == 0)
            {
                return true;
            }
            return false;

        }
        public Boolean CheckMail(string email)
        {
            List<User> registers = db.Users.ToList();
            var usersMail = registers.Where(n => n.Email == email);
           /* foreach (var item in usersMail)
            {
                if (email == item.ToString())
                {
                    return false;
                }
            }
            return true;*/
           if(usersMail.Count()==0)
            {
                return true;
            }
            return false;
            
        }
        public string EncryptPassword(string mk)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding uTF = new UTF8Encoding();
                byte[] data = md5.ComputeHash(uTF.GetBytes(mk));
                return Convert.ToBase64String(data);
            }
        }
    }
}