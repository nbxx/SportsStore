using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Vic.SportsStore.WebApp.Infrastructure.Abstract;

namespace Vic.SportsStore.WebApp.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        static string HashMD5(string text)
        {
            var source = Encoding.UTF8.GetBytes(text);

            using (MD5 hasher = MD5.Create())
            {
                var result = hasher.ComputeHash(source);

                return Convert.ToBase64String(result);
            }
        }

        private const string DefaultUser = "admin3";
        private const string DefaultPwd = "kAPR3yLrTTggAVBwOFGUyA==";

        public bool Authenticate(string username, string password)
        {
            bool result = false;

            if (username.Equals(DefaultUser, StringComparison.OrdinalIgnoreCase))
            {
                var inputPwdHash = HashMD5(password);

                if (inputPwdHash == DefaultPwd)
                {
                    result = true;
                }
            }

            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }
    }

}