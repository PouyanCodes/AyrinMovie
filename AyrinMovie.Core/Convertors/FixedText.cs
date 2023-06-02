using System;
using System.Collections.Generic;
using System.Text;

namespace AyrinMovie.Core.Convertors
{
    public class FixedText
    {
        #region Fix Email
        public static string FixEmail(string email)
        {
            return email.Trim().ToLower();
        }

        #endregion

        #region Fix Test

        public static string FixText(string text)
        {
            return text.Trim();
        }

        #endregion

    }
}
