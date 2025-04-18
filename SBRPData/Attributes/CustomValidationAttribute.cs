using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Attributes
{
    public class CustomValidationAttribute :ValidationAttribute
    {

    }


    public class LessThanOrEqualToAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public LessThanOrEqualToAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (IComparable)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}");
            }

            var comparisonValue = (IComparable)property.GetValue(validationContext.ObjectInstance);

            if (currentValue.CompareTo(comparisonValue) > 0)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be less than or equal to {_comparisonProperty}.");
            }

            return ValidationResult.Success;
        }
    }






    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class GreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public GreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;

            if (value.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("value has not implemented IComparable interface");
            }

            var currentValue = (IComparable)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException("Comparison property with this name not found");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("Comparison property has not implemented IComparable interface");
            }

            if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
            {
                throw new ArgumentException("The properties types must be the same");
            }

            if (currentValue.CompareTo((IComparable)comparisonValue) < 0)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }



    public enum ComparisonType
    {
        LessThan,
        LessThanOrEqualTo,
        EqualTo,
        GreaterThan,
        GreaterThanOrEqualTo
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ComparisonAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        private readonly ComparisonType _comparisonType;

        public ComparisonAttribute(string comparisonProperty, ComparisonType comparisonType)
        {
            _comparisonProperty = comparisonProperty;
            _comparisonType = comparisonType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;

            if (value.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("value has not implemented IComparable interface");
            }

            var currentValue = (IComparable)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException("Comparison property with this name not found");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue.GetType() == typeof(IComparable))
            {
                throw new ArgumentException("Comparison property has not implemented IComparable interface");
            }

            if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
            {
                throw new ArgumentException("The properties types must be the same");
            }

            bool compareToResult;

            switch (_comparisonType)
            {
                case ComparisonType.LessThan:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) >= 0;
                    break;
                case ComparisonType.LessThanOrEqualTo:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) > 0;
                    break;
                case ComparisonType.EqualTo:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) != 0;
                    break;
                case ComparisonType.GreaterThan:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) <= 0;
                    break;
                case ComparisonType.GreaterThanOrEqualTo:
                    compareToResult = currentValue.CompareTo((IComparable)comparisonValue) < 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return compareToResult ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }
    }



    public class DateLessThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateLessThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue > comparisonValue)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
