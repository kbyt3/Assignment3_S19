using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_S19.Helpers
{
    public static class DateHelper
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dt = dt.AddMilliseconds(unixTimeStamp).ToLocalTime();

            return dt;
        }
    }
}
