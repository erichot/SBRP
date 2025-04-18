using SBRPData.Extensions;

namespace SBRPAPITms.BindingModels
{
    public class ChowFaceModel
    {
    }



    public class ChowFaceUserExportEntity
    {
        public short ItemNo { get; set; }

        public string UserID { get; set; }

        public string UserName { get; set; }

        public string EmployeeType { get;set; }


        public string Company { get; set; }

        public string DepartmentName { get; set; }

        public string Sex { get; set; }

        public string? CardID { get; set; }

        public string? Email { get; set; }


        public string? Phone { get; set; }

        public string? ValidDate { get; set; }



        public CF_UserImportDetail ToUserImportDetail(int _importOperationNo)
        {
            return new CF_UserImportDetail()
            {

            };
        }

    }








    public class ChowFaceTransactionExportEntity
    {
        public ChowFaceTransactionExportEntity()
        {
        }



        public ChowFaceTransactionExportEntity(string _lineText)
        {
            this.DeviceID = _lineText.Left(2);
            this.CardID = _lineText.Mid(2, 10);
            this.TranDateTimeNo = _lineText.Right(10);
        }


        public short ItemNo { get; set; }

        public string DeviceID { get; set; }


        public string CardID { get; set; }


        public string TranDateTimeNo { get; set; }



        public ChowFaceTransactionExportEntity ConvertFromExportText(string _lineText)
        {

            return new ChowFaceTransactionExportEntity()
            {
                DeviceID = _lineText.Left(2),
                CardID = _lineText.Mid(3,10),
                TranDateTimeNo = _lineText.Right(10)
            };
        }



        public CF_TransactionImportDetail ToTransactionImportDetail(int _importOperationNo)
        {
            return new CF_TransactionImportDetail()
            {
                ImportOperationNo = _importOperationNo,
                ItemNo = ItemNo,
                DeviceID = DeviceID,
                CardID = CardID,
                TranDateTimeNo = TranDateTimeNo,
                TranDateTime = ConvertToDateTime(TranDateTimeNo)
            };
        }




        private DateTime? ConvertToDateTime(string _tranDateTimeNo)
        {
            if (string.IsNullOrEmpty(_tranDateTimeNo)) return null;

            int YearValue, MonthValue, DayValue, HourValue, MinuteValue;
            // 2411050817
            if (_tranDateTimeNo.Length ==  10)
            {
                if (int.TryParse("20" + _tranDateTimeNo.Left(2), out YearValue) == false ) return null;

                if (int.TryParse(_tranDateTimeNo.Mid(2, 2) , out MonthValue) == false) return null;

                if (int.TryParse(_tranDateTimeNo.Mid(4, 2), out DayValue) == false) return null;

                if (int.TryParse(_tranDateTimeNo.Mid(6, 2), out HourValue) == false) return null;

                if (int.TryParse(_tranDateTimeNo.Right(2), out MinuteValue) == false) return null;

                return new DateTime(YearValue, MonthValue, DayValue, HourValue, MinuteValue, 0);
            }

            return null;
        }

    }

}