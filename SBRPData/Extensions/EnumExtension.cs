using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.ComponentModel.DataAnnotations;


namespace SBRPData.Extensions
{
    public static class EnumExtension
    {

        public static string GetDisplayName(this Enum? enumValue)
        {
            //string displayName = string.Empty;
            //displayName = enumValue.GetType()
            //    .GetMember(enumValue.ToString())
            //    .FirstOrDefault()
            //    .GetCustomAttribute<DisplayAttribute>()?
            //    .GetName();
            if (enumValue == null)
                return string.Empty;

            var memberInfo = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault();
            if (memberInfo != null)
            {
                return memberInfo
                    .GetCustomAttribute<DisplayAttribute>()
                    ?.GetName() ?? string.Empty;
            }
            return enumValue.ToString();
        }
       









        public static byte ToByte<TEnum>(this Enum? enumValue) where TEnum : struct
        {
            return (byte)Enum.Parse(typeof(TEnum), enumValue.ToString());
        }





    }
}
