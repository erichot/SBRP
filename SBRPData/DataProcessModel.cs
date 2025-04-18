using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData
{
    public class DataProcessModel
    {
    }










    public class DataProcessResult
    {
        public bool HasError { get; set; }

        public string ResultId { get; set; }
        public int ResultNo { get; set; }

        // ReturnValue
        public int ResultValue { get; set; }
        public int ResultValue2 { get; set; }

        public string Message { get; set; }


        public void SetErrorMessage(string _message)
        {
            HasError = true;
            Message = _message;
        }
    }




    public class DataProcessResult<T> : DataProcessResult
    {

        public T ResultInfo { get; set; }

    }


}
