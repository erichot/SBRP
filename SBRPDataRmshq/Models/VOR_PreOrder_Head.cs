using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

[Keyless]
public partial class VOR_PreOrder_Head
{
    [StringLength(11)]
    [Unicode(false)]
    public string? PreOrderID { get; set; }

    public int? MemberSID { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? MemberAccount { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? MemberID { get; set; }

    [StringLength(16)]
    public string? MemberName { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? MemberLevel { get; set; }

    [StringLength(16)]
    public string? ConsigneeName { get; set; }

    [StringLength(16)]
    public string? ConsigneeName_ToMemberName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ConsigneePhone { get; set; }

    [StringLength(60)]
    public string? ConsigneeAddress { get; set; }

    [StringLength(32)]
    public string? StoreID { get; set; }

    [StringLength(32)]
    public string? StoreName { get; set; }

    [StringLength(6)]
    public string? StoreAbbreviation { get; set; }

    public int? OrderSID { get; set; }

    [StringLength(32)]
    public string? SaleOrderID { get; set; }

    public DateOnly? OrderDate { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? OrderDateText { get; set; }

    public TimeOnly? OrderTime { get; set; }

    [StringLength(300)]
    public string? Remark { get; set; }

    public bool? IsImportFromSaleOrder { get; set; }

    public short? DetailedRowCount { get; set; }

    public int? SubQty { get; set; }

    [Column(TypeName = "money")]
    public decimal? SubPrice { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? SubPriceText { get; set; }

    [Column(TypeName = "money")]
    public decimal? SubListPrice { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? SubListPriceText { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeStockUpLast { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeStockUpLastText { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeStockUpDateText { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? Account { get; set; }

    [StringLength(64)]
    [Unicode(false)]
    public string? ID { get; set; }

    public DateOnly? ReminderDateForCustomer { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? ReminderDateForCustomerText { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeAddNew { get; set; }

    [StringLength(32)]
    public string? UserAddNewID { get; set; }

    [StringLength(16)]
    public string UserAddNewName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? TimeModified { get; set; }

    [StringLength(32)]
    public string? UserModifiedID { get; set; }

    [StringLength(32)]
    public string? UserStockUpLastID { get; set; }

    [StringLength(16)]
    public string? UserStockUpLastName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TimeInStorePickUpLast { get; set; }

    [StringLength(32)]
    public string? UserInStorePickUpLastID { get; set; }

    [StringLength(16)]
    public string? UserInStorePickUpLastName { get; set; }

    [StringLength(18)]
    [Unicode(false)]
    public string? TimeInStorePickUpLastText { get; set; }

    public bool? IsFinishedForStockUp { get; set; }

    public bool? IsFinishedForInStorePickUp { get; set; }

    public short? ItemCountForAllowInStorePickUp { get; set; }

    public bool? HasItemWithStockUp { get; set; }

    public bool? HasItemWithInStorePickUp { get; set; }

    public bool? HasItemForInStorePickUp { get; set; }

    public int? SubStockUpQty { get; set; }

    public int? SubInStorePickUpQty { get; set; }

    public short? CountStockUpTimes { get; set; }

    public short? CountInStorePickUpTimes { get; set; }

    [Column(TypeName = "money")]
    public decimal? PaymentAmount { get; set; }

    [StringLength(8000)]
    [Unicode(false)]
    public string? PaymentAmountText { get; set; }

    [StringLength(128)]
    [Unicode(false)]
    public string? Email { get; set; }
}
