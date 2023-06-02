using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace AyrinMovie.Core.Security
{
    public static class PasswordHelper
    {

        #region Check Password Strength

        public static int CheckPasswordStrength(string password)
        {
            int score = 0;

            if (password.Length >= 5)
                score++;

            if (password.Length >= 8)
                score++;

            if (password.Length >= 12)
                score++;

            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                score++;

            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;

            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;

            return score;
        }

        #endregion

        #region Encode Password With MD5

        public static string EncodePasswordMd5(string pass) //Encrypt using MD5   
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string   
            return BitConverter.ToString(encodedBytes);
        }

        
        #endregion

    }
}
