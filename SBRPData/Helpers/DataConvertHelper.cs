using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Helpers
{
    public static class DataConvertHelper
    {



        // Pass in the string value and convert to the SBRP_AppIdEnum enum value
        public static SBRP_AppIdEnum ToAppIdEnum(string _value)
        {
            return (SBRP_AppIdEnum)Enum.Parse(typeof(SBRP_AppIdEnum), _value);
        }


        // Remark:大約過百年，該數值會爆表，請注意。
        // Pass a DateOnly value and calculate the days difference from 1/1/2020 then return a short value.
        public static short ToDayNumberFromBasedDate(DateOnly _value)
        {
            return (short)(_value.DayNumber - (new DateOnly(2010, 1, 1)).DayNumber);
        }





    }
}
