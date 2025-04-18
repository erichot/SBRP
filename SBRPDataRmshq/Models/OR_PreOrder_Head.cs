using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Table("OR_PreOrder_Head")]
[Index("HasItemForInStorePickUp", Name = "IX_OR_PreOrder_Head_HasItemForInStorePickUp")]
[Index("HasItemWithInStorePickUp", Name = "IX_OR_PreOrder_Head_HasItemWithInStorePickUp")]
[Index("HasItemWithStockUp", Name = "IX_OR_PreOrder_Head_HasItemWithStockUp")]
[Index("InActive", Name = "IX_OR_PreOrder_Head_InActive")]
[Index("IsFinishedForInStorePickUp", Name = "IX_OR_PreOrder_Head_IsFinishedForInStorePickUp")]
[Index("IsFinishedForStockUp", Name = "IX_OR_PreOrder_Head_IsFinishedForStockUp")]
[Index("IsImportFromSaleOrder", Name = "IX_OR_PreOrder_Head_IsImportFromSaleOrder")]
[Index("OrderDate", Name = "IX_OR_PreOrder_Head_OrderDate")]
[Index("PreOrderID", Name = "IX_OR_PreOrder_Head_PreOrderID", IsUnique = true)]
[Index("ReminderDateForCustomer", Name = "IX_OR_PreOrder_Head_ReminderDateForCustomer")]
[Index("SaleOrderID", Name = "IX_OR_PreOrder_Head_SaleOrderID")]
[Index("StoreID", Name = "IX_OR_PreOrder_Head_StoreID")]
public partial class OR_PreOrder_Head
{
    [Key]
    public int OrderSID { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string PreOrderID { get; set; } = null!;

    [StringLength(32)]
    public string StoreID { get; set; } = null!;

    public int MemberSID { get; set; }

    public DateOnly OrderDate { get; set; }

    public TimeOnly? OrderTime { get; set; }

    public byte ItemNo { get; set; }

    [StringLength(16)]
    public string ConsigneeName { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string ConsigneePhone { get; set; } = null!;

    [StringLength(60)]
    public string ConsigneeAddress { get; set; } = null!;

    [StringLength(32)]
    public string? SaleOrderID { get; set; }

    public bool IsImportFromSaleOrder { get; set; }

    [Column(TypeName = "money")]
    public decimal PaymentAmount { get; set; }

    [StringLength(300)]
    public string Remark { get; set; } = null!;

    public int? SubStockUpQty { get; set; }

    public short? CountStockUpTimes { get; set; }

    /// <summary>
    /// 已有任一品項備貨完成
    /// </summary>
    public bool? HasItemWithStockUp { get; set; }

    /// <summary>
    /// 整張單據被貨完成
    /// </summary>
    public bool IsFinishedForStockUp { get; set; }

    public short? ItemCountForAllowInStorePickUp { get; set; }

    /// <summary>
    /// 已有任一品項被取貨
    /// </summary>
    public bool HasItemWithInStorePickUp { get; set; }

    /// <summary>
    /// 該單據有任一品項可接受取貨（已備、未取）
    /// </summary>
    public bool HasItemForInStorePickUp { get; set; }

    public int? SubInStorePickUpQty { get; set; }

    public short? CountInStorePickUpTimes { get; set; }

    /// <summary>
    /// 整張單據取貨完成
    /// </summary>
    public bool IsFinishedForInStorePickUp { get; set; }

    public short DetailedRowCount { get; set; }

    public int? SubQty { get; set; }

    [Column(TypeName = "money")]
    public decimal? SubListPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal? SubPrice { get; set; }

    public int? PreOrderArrivalOrderSID { get; set; }

    public int? InStorePickUpOrderSID { get; set; }

    /// <summary>
    /// 存在任一項目需要提醒客戶（來取貨；目前等同與已備貨、未取貨）
    /// </summary>
    public bool HasItemToBeRemindedToCustomer { get; set; }

    public DateOnly? ReminderDateForCustomer { get; set; }

    public bool InActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TimeAddNew { get; set; }

    [StringLength(32)]
    public string UserAddNewID { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }

    [StringLength(32)]
    public string? UserStockUpLastID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeStockUpLast { get; set; }

    [StringLength(32)]
    public string? UserInStorePickUpLastID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeInStorePickUpLast { get; set; }

    [StringLength(32)]
    public string? UserNullifiedID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeNullified { get; set; }
}
