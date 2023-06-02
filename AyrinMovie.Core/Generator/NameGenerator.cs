using System;
using System.Collections.Generic;
using System.Text;

namespace AyrinMovie.Core.Generator
{
    public class NameGenerator
    {

        #region Generate Uniq Code

        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        #endregion

    }
}
