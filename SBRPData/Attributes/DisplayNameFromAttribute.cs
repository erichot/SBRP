using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace SBRPData.Attributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayNameFromAttribute : Attribute
    {
        public string SourcePropertyName { get; }

        public DisplayNameFromAttribute(string sourcePropertyName)
        {
            SourcePropertyName = sourcePropertyName;
        }


        //    public static void SetDisplayNames<TModel>(TModel model)
        //    {
        //        var properties = typeof(TModel).GetProperties();

        //        foreach (var property in properties)
        //        {
        //            var displayNameFromAttribute = property.GetCustomAttribute<DisplayNameFromAttribute>();

        //            if (displayNameFromAttribute != null)
        //            {
        //                var sourceProperty = typeof(TModel).GetProperty(displayNameFromAttribute.SourcePropertyName);
        //                var displayAttribute = sourceProperty?.GetCustomAttribute<DisplayAttribute>();

        //                if (displayAttribute != null)
        //                {
        //                    var displayName = displayAttribute.Name;
        //                    var targetDisplayAttribute = new DisplayAttribute { Name = displayName };

        //                    property.SetCustomAttribute(targetDisplayAttribute);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
    
