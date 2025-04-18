using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VRP_ProductCounterInventoryForSaleQty_EachStore_YURUBRA
{
    [StringLength(32)]
    public string ProductID { get; set; } = null!;

    [StringLength(32)]
    public string? ProductCode { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    public int? InStockSubTotal { get; set; }

    public int? StockSubTotal { get; set; }

    public int? SaleSubTotal { get; set; }

    [StringLength(50)]
    public string? ImageFileName1 { get; set; }

    [StringLength(100)]
    public string? ImageSubFolderFileName1 { get; set; }

    public bool IsFavorite { get; set; }

    public DateOnly? TranInStockFirstDate00 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockFirstDateText00 { get; set; }

    public DateOnly? TranInStockLastDate00 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockLastDateText00 { get; set; }

    public int? TranInStockSubTotal00 { get; set; }

    public int? TranInStockWithoutReceived00 { get; set; }

    public int? TranInStockWithReceived00 { get; set; }

    public DateOnly? SaleFirstDate00 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleFirstDateText00 { get; set; }

    public DateOnly? SaleLastDate00 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleLastDateText00 { get; set; }

    public int? SaleSubTotal00 { get; set; }

    public int? StockSubTotal00 { get; set; }

    public int? StockSubTotalWithReceived00 { get; set; }

    public int? StockSubTotalWithoutReceived00 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder00 { get; set; }

    public int? CustomerOrderQty00 { get; set; }

    public int? CustomerOrderQtyUnPackage00 { get; set; }

    public int? CustomerOrderQtyPackaged00 { get; set; }

    public DateOnly? TranInStockFirstDate10 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockFirstDateText10 { get; set; }

    public DateOnly? TranInStockLastDate10 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockLastDateText10 { get; set; }

    public int? TranInStockSubTotal10 { get; set; }

    public int? TranInStockWithoutReceived10 { get; set; }

    public int? TranInStockWithReceived10 { get; set; }

    public DateOnly? SaleFirstDate10 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleFirstDateText10 { get; set; }

    public DateOnly? SaleLastDate10 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? SaleLastDateText10 { get; set; }

    public int? SaleSubTotal10 { get; set; }

    public int? StockSubTotal10 { get; set; }

    public int? StockSubTotalWithReceived10 { get; set; }

    public int? StockSubTotalWithoutReceived10 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder10 { get; set; }

    public int? CustomerOrderQty10 { get; set; }

    public int? CustomerOrderQtyUnPackage10 { get; set; }

    public int? CustomerOrderQtyPackaged10 { get; set; }

    public DateOnly? TranInStockFirstDate11 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockFirstDateText11 { get; set; }

    public DateOnly? TranInStockLastDate11 { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TranInStockLastDateText11 { get; set; }

    public int? TranInStockSubTotal11 { get; set; }

    public int? TranInStockWithoutReceived11 { get; set; }

    public int? TranInStockWithReceived11 { get; set; }

    public int? StockSubTotal11 { get; set; }

    public int? StockSubTotalWithReceived11 { get; set; }

    public int? StockSubTotalWithoutReceived11 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder11 { get; set; }

    public int? CustomerOrderQty11 { get; set; }

    public int? CustomerOrderQtyUnPackage11 { get; set; }

    public int? CustomerOrderQtyPackaged11 { get; set; }

    public int? TranInStockSubTotal12 { get; set; }

    public int? TranInStockWithoutReceived12 { get; set; }

    public int? TranInStockWithReceived12 { get; set; }

    public int? StockSubTotal12 { get; set; }

    public int? StockSubTotalWithReceived12 { get; set; }

    public int? StockSubTotalWithoutReceived12 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder12 { get; set; }

    public int? CustomerOrderQty12 { get; set; }

    public int? CustomerOrderQtyUnPackage12 { get; set; }

    public int? CustomerOrderQtyPackaged12 { get; set; }

    public int? TranInStockSubTotal13 { get; set; }

    public int? TranInStockWithoutReceived13 { get; set; }

    public int? TranInStockWithReceived13 { get; set; }

    public int? StockSubTotal13 { get; set; }

    public int? StockSubTotalWithReceived13 { get; set; }

    public int? StockSubTotalWithoutReceived13 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder13 { get; set; }

    public int? CustomerOrderQty13 { get; set; }

    public int? CustomerOrderQtyUnPackage13 { get; set; }

    public int? CustomerOrderQtyPackaged13 { get; set; }

    public int? CustomerOrderQty85 { get; set; }

    public int? TranInStockSubTotal86 { get; set; }

    public int? TranInStockWithoutReceived86 { get; set; }

    public int? TranInStockWithReceived86 { get; set; }

    public int? StockSubTotal86 { get; set; }

    public int? StockSubTotalWithReceived86 { get; set; }

    public int? StockSubTotalWithoutReceived86 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder86 { get; set; }

    public int? CustomerOrderQty86 { get; set; }

    public int? CustomerOrderQtyUnPackage86 { get; set; }

    public int? CustomerOrderQtyPackaged86 { get; set; }

    public int? TranInStockSubTotal88 { get; set; }

    public int? TranInStockWithoutReceived88 { get; set; }

    public int? TranInStockWithReceived88 { get; set; }

    public int? StockSubTotal88 { get; set; }

    public int? StockSubTotalWithReceived88 { get; set; }

    public int? StockSubTotalWithoutReceived88 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder88 { get; set; }

    public int? CustomerOrderQty88 { get; set; }

    public int? CustomerOrderQtyUnPackage88 { get; set; }

    public int? CustomerOrderQtyPackaged88 { get; set; }

    public int? TranInStockSubTotal89 { get; set; }

    public int? TranInStockWithoutReceived89 { get; set; }

    public int? TranInStockWithReceived89 { get; set; }

    public int? StockSubTotal89 { get; set; }

    public int? StockSubTotalWithReceived89 { get; set; }

    public int? StockSubTotalWithoutReceived89 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder89 { get; set; }

    public int? CustomerOrderQty89 { get; set; }

    public int? CustomerOrderQtyUnPackage89 { get; set; }

    public int? CustomerOrderQtyPackaged89 { get; set; }

    public int? TranInStockWithoutReceived99 { get; set; }

    public int? StockSubTotal99 { get; set; }

    public int? StockSubTotalWithReceivedWithoutCustomerOrder99 { get; set; }

    public int? CustomerOrderQty99 { get; set; }

    public int? CustomerOrderQtyUnPackage99 { get; set; }

    public int? CustomerOrderQtyPackaged99 { get; set; }
}
