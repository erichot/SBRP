using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SBRPDataPsi
{
    public class ColumnEnumModel
    {
    }


    public static class OperationTypePrefix
    {
        public static string InboundStork = "I";
        public static string StoreTransfer = "S";
    }




    public enum OperationClassEnum : byte
    {
        // 供應商 -> 自有倉庫（可能是總倉or自有門市）
        [Display(Name = "供應商入庫作業類")]
        InboundStock = 110,



        //[Display(Name = "出庫作業")]
        //OutboundStock = 123,


        // 自有倉庫（必為總倉） -> 中盤倉庫 or 自有門市，可依據出退單據跑結帳作業
        [Display(Name = "出貨作業類")]
        Shipment = 130,

     





        // 僅用於自有倉庫、自用門市間的數量調撥轉入、轉出
        [Display(Name = "調撥轉貨作業類")]
        StockTransfer = 150,





        [Display(Name = "門市銷貨作業類")]
        Sale = 170
    }







    public enum OperationTypeEnum : byte
    {
        // 供應商 -> 自有倉庫（可能是總倉or自有門市）
        [Display(Name = "入庫作業")]
        InboundStock = 111,

        [Display(Name = "退庫作業")]
        InboundStockReturn = 112,



        //[Display(Name = "出庫作業")]
        //OutboundStock = 123,


        // 自有倉庫（必為總倉） -> 中盤倉庫 or 自有門市，可依據出退單據跑結帳作業
        [Display(Name = "出貨作業")]
        Shipment = 131,

        [Display(Name = "退貨作業")]
        ShipmentReturn = 132,





        // 僅用於自有倉庫、自用門市間的數量調撥轉入、轉出
        [Display(Name = "調撥轉貨作業")]
        StockTransfer = 155,





        [Display(Name = "銷貨作業")]
        Sale = 171,

        [Display(Name = "銷退作業")]
        SaleReturn = 172
    }









    // [psi].[uspINSERT_SystemIsolationGroup_SIGWithRelateDefault]
    public enum ProductCostEnum : byte
    {
        [Display(Name = "進貨成本")]
        PurchaseCost = 0,
        [Display(Name = "銷售成本")]
        SaleCost = 1,


        [Display(Name = "製造成本")]
        ManufactureCost = 8,
        [Display(Name = "包裝成本")]
        PackageCost = 2,
        [Display(Name = "運輸成本")]
        TransportCost = 3,
       
        [Display(Name = "其他成本")]
        OtherCost = 9
    }


    public enum ProductSuplierEnum : byte
    {
        [Display(Name = "預設供應商")]
        DefaultSupplier = 0
    }












    public enum StockOperationActionEnum : byte
    {
        [Display(Name = "")]
        General  = 0,

        [Display(Name = "轉出")]
        TransferFrom = 1,

        [Display(Name = "轉入")]
        TransferTo = 2,

        [Display(Name = "銷貨")]
        Sale = 3
    }





}
