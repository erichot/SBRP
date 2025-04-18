using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi
{
    public class DbSystemModel
    {
        public const bool DB_IsUsed_SigIdn = true;



       
    }


    public static class DbSystemData
    {
        public static readonly DateTime CS_OrderDate_Based = new DateTime(2020, 1, 1);
        public const string SQL_Table_Orders_OrderNo_Computed = "(CAST([OrderDateNo] AS INT) * 65536 + CAST([DaySerialNo] AS INT)) PERSISTED NOT NULL";
        public const string SQL_Table_Orders_OrderDate_Computed = "CONVERT([DATE], (DATEADD(day, [OrderDateNo], DATEFROMPARTS(2020,1,1))))";

        //public const string SQL_Table_Orders_OrderNo_Computed = "(CAST([OrderDateNo] AS INT) * 65536 + CAST([DaySerialNo] AS INT)) PERSISTED NOT NULL";
        //public const string SQL_Table_Orders_OrderNo_Computed = "(CAST([OrderDateNo] AS INT) * 65536 + CAST([DaySerialNo] AS INT)) PERSISTED NOT NULL";

        //public const string udfGET_InboundStockOrder_DaySerialNo_NewDefault = "udfGET_InboundStockOrder_DaySerialNo_NewDefault";


    }



    // 可將Short <-> DateOnly互相轉換，但需要基礎日期，而且由於Short範圍有限，所以只能轉換一定範圍內的日期，正值OrderDateNo可使用至2098年
    public static class DbSystemFunction
    {
        public static short GetOrderDateNo()
        {
            return GetOrderDateNo(DateTime.Now.Date);
        }
        public static short GetOrderDateNo(DateOnly _orderDate)
        {
            return GetOrderDateNo(_orderDate.ToDateTime(TimeOnly.MinValue));
        }
        public static short GetOrderDateNo(DateTime _orderDate)
        {
            return (short)(_orderDate - DbSystemData.CS_OrderDate_Based).Days;
        }

        public static DateTime GetOrderDate(short _orderDateNo)
        {
            return DbSystemData.CS_OrderDate_Based.AddDays(_orderDateNo);
        }






        public static int ConvertToOrderNo(short _orderDateNo, short _daySerialNo)
        {
            return  ((ushort)_orderDateNo << 16) | (ushort)_daySerialNo;
        }
    }
         








    public enum TableColumnSeed : int
    {
        // byte
        [Display(Name = "seqProductGeneralCategoryDefinition")]
        ProductGeneralCategoryDefinition = 11,

        // ===============================================================
        // short
        [Display(Name = "seqStoreRegion")]
        StoreRegion = 12,

        [Display(Name = "seqSupplierGroup")]
        SupplierGroup = 101,

        // Note: 2024/12/29 都在DB層級INSERT資料，不會透過AP INSERT，所以不需要Next Value
        [Display(Name = "seqMenuitem")]
        Menuitem = 301,

        [Display(Name = "seqBaseWebPageSIG")]
        BaseWebPageSIG = 501,

        [Display(Name = "seqStock")]
        Stock = 1001,

        [Display(Name = "seqStore")]
        Store = 2001,
                

        [Display(Name = "seqPermissionGroup")]
        PermissionGroup = 4001,


        [Display(Name = "seqSupplier")]
        Supplier = 6001,


        [Display(Name = "seqProductGeneralCategoryItem")]
        ProductGeneralCategoryItem = 8001,


        // ===============================================================
        // int
        [Display(Name = "seqProduct")]
        Product = 10_001,


        [Display(Name = "seqMember")]
        Member = 300_001
        //[Display(Name = "seqInboundStockOrder")]
        //InboundStockOrder = 10_000_001,
    }
















    public enum DbTableNameEnum:byte
    {
        ProductCost = 1
    }







}
