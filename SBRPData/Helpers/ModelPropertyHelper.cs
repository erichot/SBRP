using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq.Expressions;

namespace SBRPData.Helpers
{
    public static class ModelPropertyHelper
    {

        public static int? GetMaxLengthAttributeValue(Type modelType, string propertyName)
        {
            // Get the PropertyInfo object for the specified property
            PropertyInfo property = modelType.GetProperty(propertyName);

            if (property != null)
            {
                // Get the MaxLengthAttribute applied to the property
                MaxLengthAttribute maxLengthAttribute = property
                    .GetCustomAttributes(typeof(MaxLengthAttribute), false)
                    .Cast<MaxLengthAttribute>()
                    .FirstOrDefault();

                if (maxLengthAttribute != null)
                {
                    // Return the MaxLength value
                    return maxLengthAttribute.Length;
                }
            }

            // Return null if the attribute is not found
            return null;
        }






        public static int? GetMaxLength<T>(Expression<Func<T, object>> expression)
        {
            // Get the PropertyInfo object for the specified property
            MemberExpression memberExpression = GetMemberExpression(expression);

            if (memberExpression != null)
            {
                // Get the MaxLengthAttribute applied to the property
                MaxLengthAttribute maxLengthAttribute = memberExpression
                    .Member
                    .GetCustomAttribute<MaxLengthAttribute>();

                if (maxLengthAttribute != null)
                {
                    // Return the MaxLength value
                    return maxLengthAttribute.Length;
                }
            }

            // Return null if the attribute is not found
            return null;
        }

        private static MemberExpression GetMemberExpression<T>(Expression<Func<T, object>> expression)
        {
            // Handle UnaryExpression (e.g., for value types)
            if (expression.Body is UnaryExpression unaryExpression)
            {
                return unaryExpression.Operand as MemberExpression;
            }

            // Handle MemberExpression directly
            return expression.Body as MemberExpression;
        }





        public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            // Check if the body of the expression is a UnaryExpression (e.g., for value types)
            if (expression.Body is UnaryExpression unaryExpression)
            {
                // Get the operand of the UnaryExpression which should be a MemberExpression
                if (unaryExpression.Operand is MemberExpression memberExpression)
                {
                    return memberExpression.Member.Name;
                }
            }
            // Check if the body of the expression is a MemberExpression directly
            else if (expression.Body is MemberExpression memberExpr)
            {
                return memberExpr.Member.Name;
            }
            // If the expression points directly to a method, handle it
            else if (expression.Body is MethodCallExpression methodCallExpression)
            {
                return methodCallExpression.Method.Name;
            }
            // Handle other cases or throw an exception
            else
            {
                throw new InvalidOperationException("Invalid expression type. The expression should point to a property or a method.");
            }

            throw new InvalidOperationException("Invalid expression. Unable to determine property name.");
        }






        public static string GetDisplayName<T>(Expression<Func<T, object>> expression)
        {
            // Get the PropertyInfo object for the specified property
            MemberExpression memberExpression = GetMemberExpression(expression);

            if (memberExpression != null)
            {
                // Get the DisplayAttribute applied to the property
                DisplayAttribute displayAttribute = memberExpression
                    .Member
                    .GetCustomAttribute<DisplayAttribute>();

                if (displayAttribute != null)
                {
                    // Return the display name
                    return displayAttribute.Name;
                }
            }

            // Return null or a default value if the attribute is not found
            return null;
        }

      





    }
}
