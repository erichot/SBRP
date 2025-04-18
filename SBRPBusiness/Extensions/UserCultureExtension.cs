using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Extensions
{
    public static class UserCultureExtension
    {

        public static string ToSBRPShortDateString(this DateOnly _value)
        {
            if (_value.Year == DateTime.Now.Year)
                return _value.ToString(BusinessSystem.ShortDateStringFormat);
            else
                return _value.ToString(BusinessSystem.DateStringFormat);
        }
        public static string ToSBRPShortDateString(this DateTime _value)
        {
            if (_value.Year == DateTime.Now.Year)
                return _value.ToString(BusinessSystem.ShortDateStringFormat);
            else
                return _value.ToString(BusinessSystem.DateStringFormat);
        }
        public static string ToSBRPShortDateString(this DateTime? _value)
        {
            if (_value == null)
                return string.Empty;

            var dtValue = (DateTime)_value;
            if (dtValue.Year == DateTime.Now.Year)
                return dtValue.ToString(BusinessSystem.ShortDateStringFormat);
            else
                return dtValue.ToString(BusinessSystem.DateStringFormat);
        }




        public static string ToTimeString(this DateTime _value)
        {
            return _value.ToString(BusinessSystem.TimeStringFormat);
        }
        public static string ToTimeString(this DateTime? _value)
        {
            if (_value == null)
                return string.Empty;

            return ((DateTime)_value).ToString(BusinessSystem.TimeStringFormat);
        }



        public static string ToSBRPDateString(this DateOnly _value)
        {
           
            return _value.ToString(BusinessSystem.DateStringFormat);
        }
        public static string ToSBRPDateString(this DateTime _value)
        {            
            if (_value == DateTime.MinValue)
                return string.Empty;

            return _value.ToString(BusinessSystem.DateStringFormat);
        }
        public static string ToSBRPDateString(this DateTime? _value)
        {
            //return ToBopShortDateString(_value);
            if (_value == null)
                return string.Empty;

            return ((DateTime)_value).ToString(BusinessSystem.DateStringFormat);
        }



        public static DateTime? ToDateForUrl(this string? _value)
        {
            if (string.IsNullOrEmpty(_value))
                return null;

            if (DateTime.TryParseExact(_value, BusinessSystem.DateStringFormatForUrl, null, System.Globalization.DateTimeStyles.None, out var _date))
                return _date.Date;

            return null;
        }





















        public static string ToNumberString(this int _value)
        {
            return _value.ToString("#,##0");
        }
        public static string ToNumberString(this int? _value)
        {
            if (_value == null)
                return string.Empty;

            return _value.ToInt().ToString("#,##0");
        }
        public static string ToNumberString(this short _value)
        {
            return _value.ToString("#,##0");
        }
        public static string ToNumberString(this short? _value)
        {
            if (_value == null)
                return string.Empty;

            return _value.ToInt().ToString("#,##0");
        }






        public static string ToMoneyString(this int _value)
        {
            return _value.ToString("#,##0");
        }
        public static string ToMoneyString(this int? _value)
        {
            if (_value == null)
                return string.Empty;

            return _value.ToInt().ToString("#,##0");
        }
        public static string ToMoneyString(this long _value)
        {
            return _value.ToString("###,##0");
        }
        public static string ToMoneyString(this long? _value)
        {
            return (_value != null) ? ((long)_value).ToString("###,##0") : "0";
        }
        public static string ToMoneyString(this decimal _value)
        {
            return _value.ToString("###,##0");
        }
        public static string ToMoneyString(this decimal? _value)
        {
            return (_value != null) ? ((decimal)_value).ToString("###,##0") : "0";
        }









    }
}
