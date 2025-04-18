
using SBRPData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SBRPBusinessTms.Models
{
    public  class BusinessProcessModel
    {



        



    }




    public static class BusinessSystem
    {

        public const short UserSID_SystemAdmin = 1;
        public const short UserSID_SYSTEM = 10;

      


        public const string DateStringFormat = "yyyy-MM-dd";
        public const string DateStringFormatForUrl = "yyyy-MM-dd";
        public const string DateNumberFormat = "yyyyMMdd";
        public const string ShortDateStringFormat = "MM-dd";
        public const string ShortDateNumberFormat = "MMdd";
        public const string TimeStringFormat = "HH:mm:ss";
        public const string DateTimeStringFormat = "yyyy-MM-dd HH:mm";
        public const string ShortDateTimeStringFormat = "MM-dd HH:mm";


        public static DateTime ConvertFromDateNo(string _dateNo)
        {
            DateTime result = default;
            if (int.TryParse(_dateNo, out var dateNo))
            {
                result = ConvertFromDateNo(dateNo);
            }
            
            return result;
        }

        public static DateTime ConvertFromDateNo(int _dateNo)
        {
            DateTime result = default;
            if (!DateTime.TryParseExact(_dateNo.ToString(), DateNumberFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                result = default;
            }
                

            return result;
        }




















    }


    



    public class ValidationResultEntity
    {
        //public ValidationResultEntity(string? errorMessage) : base(errorMessage)
        //{
        //}

        //public ValidationResultEntity(string? errorMessage, IEnumerable<string>? memberNames) : base(errorMessage, memberNames)
        //{
        //}

        public ValidationResultEntity(ValidationResult _validationResult = null)
        {
            if (_validationResult != null)
            {
                this.SetInValid(_validationResult.ErrorMessage);
            }
        }

        public string ItemKey { get; set; }
        public bool InValid { get; set; }
        public string Message { get; set; }


        public void SetInValid(string _message)
        {
            this.InValid = true;
            this.Message = _message;
        }
    }


    public class ValidationResultGroup
    {
        public bool InValid { get; set; }
        public string Message { get; set; }
        public List<ValidationResultEntity> ValidationItems { get; set; }



        public void AddInValid(string _key, string _message)
        {
            this.InValid = true;
            this.Message += _message;

            if (this.ValidationItems == null)
                this.ValidationItems = new List<ValidationResultEntity>();

            this.ValidationItems.Add(
                new ValidationResultEntity()
                    {
                        ItemKey = _key,
                        InValid = true,
                        Message = _message
                    }
                );
        }
    }


    
    


   










    public class BusinessProcessResult
    {

        public BusinessProcessResult() { }

        public BusinessProcessResult(DataProcessResult _source)
        {
            this.HasError = _source.HasError;
            this.ResultId = _source.ResultId;
            this.ResultNo = _source.ResultNo;
            this.Message = _source.Message;            
        }

        public bool HasError { get; set; }

        public string ResultId { get;set; }
        public int ResultNo { get; set; }

        public int ResultValue { get; set; }
        public int ResultValue2 { get; set; }

        public string Message { get; set; }


        private Exception? m_ExceptionInfo;
        public Exception? ExceptionInfo 
        { 
            get
            {
                return m_ExceptionInfo;
            }
            set
            {
                m_ExceptionInfo = value;
                if (value != null)
                {
                    this.HasError = true;
                    this.Message = value.ComposeExceptionMessage();
                }
                
            }
        }


        

        public void SetErrorMessage(string _message)
        {
            this.HasError = true;
            this.Message = _message;
        }
        
    }





    public class BusinessProcessResult<T> : BusinessProcessResult
    {
        public BusinessProcessResult() { }

        public BusinessProcessResult(DataProcessResult<T> _source)
        {
            this.HasError = _source.HasError;
            this.ResultId = _source.ResultId;
            this.ResultNo = _source.ResultNo;
            this.Message = _source.Message;

            this.ResultInfo = _source.ResultInfo;
        }

        public BusinessProcessResult(BusinessProcessResult _source)
        {
            this.HasError = _source.HasError;
            this.ResultId = _source.ResultId;
            this.ResultNo = _source.ResultNo;
            this.Message = _source.Message;

        }

        public T ResultInfo { get; set; }
    }












   





}
