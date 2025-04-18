using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using System.Reflection;

namespace SBRPData.Extensions
{
    public static class ModelMetadataExtensions
    {
        public static string GetDisplayName<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
        {

            Type type = typeof(TModel);

            MemberExpression memberExpression = (MemberExpression)expression.Body;
            string propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);

            // First look into attributes on a type and it's parents
            // (typeof(InventCouponDetailImportCsvMapEntity)).GetProperty(propertyName)
            var attr1 = (System.ComponentModel.DisplayNameAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), true).SingleOrDefault();
            if (attr1 != null)
                return attr1.DisplayName;


            var attr = (System.ComponentModel.DataAnnotations.DisplayAttribute)type.GetProperty(propertyName).GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true).SingleOrDefault();


            // Look for [MetadataType] attribute in type hierarchy
            // http://stackoverflow.com/questions/1910532/attribute-isdefined-doesnt-see-attributes-applied-with-metadatatype-class
            if (attr == null)
            {
                MetadataTypeAttribute metadataType = (MetadataTypeAttribute)type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null)
                {
                    var property = metadataType.MetadataClassType.GetProperty(propertyName);
                    if (property != null)
                    {
                        attr = (DisplayAttribute)property.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), true).SingleOrDefault();
                    }
                }
            }
            return (attr != null) ? attr.Name : String.Empty;


        }



        public static string GetPropertyName<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
        {

            Type type = typeof(TModel);

            MemberExpression memberExpression = (MemberExpression)expression.Body;
            string propertyName = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);

            return propertyName??string.Empty;
        }

    }
}
