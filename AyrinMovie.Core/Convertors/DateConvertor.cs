using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AyrinMovie.Core.Convertors
{
    public static class DateConvertor
    {

        #region Convert Date To Shamsi Date

        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }

        #endregion

    }
}
