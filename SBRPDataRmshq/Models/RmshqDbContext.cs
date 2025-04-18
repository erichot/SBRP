using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SBRPDataRmshq.Models;

public partial class RmshqDbContext : DbContext
{
    public RmshqDbContext()
    {
    }

    public RmshqDbContext(DbContextOptions<RmshqDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BC_PreOrderContactResult> BC_PreOrderContactResults { get; set; }

    public virtual DbSet<BC_PreOrderOperationType> BC_PreOrderOperationTypes { get; set; }

    public virtual DbSet<BF_Coupon> BF_Coupons { get; set; }

    public virtual DbSet<BF_DistributionProductStorePriority> BF_DistributionProductStorePriorities { get; set; }

    public virtual DbSet<BF_DistributionStorePriority> BF_DistributionStorePriorities { get; set; }

    public virtual DbSet<BF_EmployeeStoreBelonging> BF_EmployeeStoreBelongings { get; set; }

    public virtual DbSet<BF_Member> BF_Members { get; set; }

    public virtual DbSet<BF_Product> BF_Products { get; set; }

    public virtual DbSet<BF_ProductCode_Preserved> BF_ProductCode_Preserveds { get; set; }

    public virtual DbSet<BF_ProductCode_Removed> BF_ProductCode_Removeds { get; set; }

    public virtual DbSet<BF_ProductSafetyStockSettingPivot> BF_ProductSafetyStockSettingPivots { get; set; }

    public virtual DbSet<BF_ProductStopSetting> BF_ProductStopSettings { get; set; }

    public virtual DbSet<BF_Store> BF_Stores { get; set; }

    public virtual DbSet<BF_StorePrioritySetting> BF_StorePrioritySettings { get; set; }

    public virtual DbSet<BF_StorePrioritySetting_Import> BF_StorePrioritySetting_Imports { get; set; }

    public virtual DbSet<BF_StoreSafetyStockSetting> BF_StoreSafetyStockSettings { get; set; }

    public virtual DbSet<BF_StoreSafetyStockSettingPivot> BF_StoreSafetyStockSettingPivots { get; set; }

    public virtual DbSet<BF_User> BF_Users { get; set; }

    public virtual DbSet<MT_CompanyPurchasingOrder> MT_CompanyPurchasingOrders { get; set; }

    public virtual DbSet<MT_ProductCustomerOrder_ByStore> MT_ProductCustomerOrder_ByStores { get; set; }

    public virtual DbSet<MT_ProductFlowStatistics_ByProduct> MT_ProductFlowStatistics_ByProducts { get; set; }

    public virtual DbSet<MT_ProductFlowStatistics_ByStore> MT_ProductFlowStatistics_ByStores { get; set; }

    public virtual DbSet<MT_ProductInStockOrder_ByStore> MT_ProductInStockOrder_ByStores { get; set; }

    public virtual DbSet<MT_ProductSaleOrder_ByStore> MT_ProductSaleOrder_ByStores { get; set; }

    public virtual DbSet<MT_ProductStockAdjustment_ByStore> MT_ProductStockAdjustment_ByStores { get; set; }

    public virtual DbSet<MT_ProductStock_ByStore> MT_ProductStock_ByStores { get; set; }

    public virtual DbSet<MT_ProductStoreTransfer_ByFromStore> MT_ProductStoreTransfer_ByFromStores { get; set; }

    public virtual DbSet<MT_ProductStoreTransfer_ByStore> MT_ProductStoreTransfer_ByStores { get; set; }

    public virtual DbSet<MT_ProductStoreTransfer_ByToStore> MT_ProductStoreTransfer_ByToStores { get; set; }

    public virtual DbSet<OR_CompanyPreOrderInStore_Detail> OR_CompanyPreOrderInStore_Details { get; set; }

    public virtual DbSet<OR_CompanyPreOrderInStore_Head> OR_CompanyPreOrderInStore_Heads { get; set; }

    public virtual DbSet<OR_CompanyPreOrderInStore_Product> OR_CompanyPreOrderInStore_Products { get; set; }

    public virtual DbSet<OR_CompanyPreOrderInStore_Store> OR_CompanyPreOrderInStore_Stores { get; set; }

    public virtual DbSet<OR_CompanyPurchasingOrder_Detail> OR_CompanyPurchasingOrder_Details { get; set; }

    public virtual DbSet<OR_CompanyPurchasingOrder_Head> OR_CompanyPurchasingOrder_Heads { get; set; }

    public virtual DbSet<OR_CounterProductOrderDetail> OR_CounterProductOrderDetails { get; set; }

    public virtual DbSet<OR_CounterProductOrderHead> OR_CounterProductOrderHeads { get; set; }

    public virtual DbSet<OR_DistributionProductStoreDetailDist> OR_DistributionProductStoreDetailDists { get; set; }

    public virtual DbSet<OR_DistributionProductStoreDetailRec> OR_DistributionProductStoreDetailRecs { get; set; }

    public virtual DbSet<OR_DistributionProductStoreHead> OR_DistributionProductStoreHeads { get; set; }

    public virtual DbSet<OR_EXPORT_ProductInfo> OR_EXPORT_ProductInfos { get; set; }

    public virtual DbSet<OR_EXPORT_ProductInfo_Detail> OR_EXPORT_ProductInfo_Details { get; set; }

    public virtual DbSet<OR_EXPORT_ProductInfo_Summary> OR_EXPORT_ProductInfo_Summaries { get; set; }

    public virtual DbSet<OR_EXPORT_ProductInfo_Summary_0226> OR_EXPORT_ProductInfo_Summary_0226s { get; set; }

    public virtual DbSet<OR_EXPORT_Response_Detail> OR_EXPORT_Response_Details { get; set; }

    public virtual DbSet<OR_EXPORT_SaleOrder> OR_EXPORT_SaleOrders { get; set; }

    public virtual DbSet<OR_EXPORT_SaleOrder_Detail> OR_EXPORT_SaleOrder_Details { get; set; }

    public virtual DbSet<OR_EXPORT_SaleOrder_Detail_After202302> OR_EXPORT_SaleOrder_Detail_After202302s { get; set; }

    public virtual DbSet<OR_EXPORT_SaleOrder_Exclusion> OR_EXPORT_SaleOrder_Exclusions { get; set; }

    public virtual DbSet<OR_EXPORT_SaleOrder_Head_Member> OR_EXPORT_SaleOrder_Head_Members { get; set; }

    public virtual DbSet<OR_InStock_Detail> OR_InStock_Details { get; set; }

    public virtual DbSet<OR_InStock_Detail_Archive> OR_InStock_Detail_Archives { get; set; }

    public virtual DbSet<OR_InStock_Head> OR_InStock_Heads { get; set; }

    public virtual DbSet<OR_InStock_Head_Archive> OR_InStock_Head_Archives { get; set; }

    public virtual DbSet<OR_NotificationMessage> OR_NotificationMessages { get; set; }

    public virtual DbSet<OR_PreOrderArrival_Detail> OR_PreOrderArrival_Details { get; set; }

    public virtual DbSet<OR_PreOrderArrival_Detail_UpdatedLog> OR_PreOrderArrival_Detail_UpdatedLogs { get; set; }

    public virtual DbSet<OR_PreOrderArrival_Head> OR_PreOrderArrival_Heads { get; set; }

    public virtual DbSet<OR_PreOrderArrival_Head_UpdatedLog> OR_PreOrderArrival_Head_UpdatedLogs { get; set; }

    public virtual DbSet<OR_PreOrderInStorePickUp_Detail> OR_PreOrderInStorePickUp_Details { get; set; }

    public virtual DbSet<OR_PreOrderInStorePickUp_Head> OR_PreOrderInStorePickUp_Heads { get; set; }

    public virtual DbSet<OR_PreOrderReminder_Detail> OR_PreOrderReminder_Details { get; set; }

    public virtual DbSet<OR_PreOrder_Detail> OR_PreOrder_Details { get; set; }

    public virtual DbSet<OR_PreOrder_Head> OR_PreOrder_Heads { get; set; }

    public virtual DbSet<OR_ProductAdditionalOrderDetail> OR_ProductAdditionalOrderDetails { get; set; }

    public virtual DbSet<OR_ProductAdditionalOrderHead> OR_ProductAdditionalOrderHeads { get; set; }

    public virtual DbSet<OR_ProductAdditionalOrderSource> OR_ProductAdditionalOrderSources { get; set; }

    public virtual DbSet<OR_ProductBarcodeImportDetail> OR_ProductBarcodeImportDetails { get; set; }

    public virtual DbSet<OR_ProductBarcodeImportHead> OR_ProductBarcodeImportHeads { get; set; }

    public virtual DbSet<OR_ProductUploadDetail> OR_ProductUploadDetails { get; set; }

    public virtual DbSet<OR_ProductUploadHead> OR_ProductUploadHeads { get; set; }

    public virtual DbSet<OR_RemotelyMemberQuerying> OR_RemotelyMemberQueryings { get; set; }

    public virtual DbSet<OR_SaleOrder_Detail> OR_SaleOrder_Details { get; set; }

    public virtual DbSet<OR_SaleOrder_Detail_Archive> OR_SaleOrder_Detail_Archives { get; set; }

    public virtual DbSet<OR_SaleOrder_Detail_Temp> OR_SaleOrder_Detail_Temps { get; set; }

    public virtual DbSet<OR_SaleOrder_Head> OR_SaleOrder_Heads { get; set; }

    public virtual DbSet<OR_SaleOrder_Head_Archive> OR_SaleOrder_Head_Archives { get; set; }

    public virtual DbSet<OR_SaleOrder_Head_Temp> OR_SaleOrder_Head_Temps { get; set; }

    public virtual DbSet<OR_SaleReturnOrder_Head> OR_SaleReturnOrder_Heads { get; set; }

    public virtual DbSet<OR_StockAdjustment_Detail> OR_StockAdjustment_Details { get; set; }

    public virtual DbSet<OR_StockAdjustment_Head> OR_StockAdjustment_Heads { get; set; }

    public virtual DbSet<OR_StoreInTransitCommit_Head> OR_StoreInTransitCommit_Heads { get; set; }

    public virtual DbSet<OR_StoreSafetyStockImportDetail> OR_StoreSafetyStockImportDetails { get; set; }

    public virtual DbSet<OR_StoreSafetyStockImportHead> OR_StoreSafetyStockImportHeads { get; set; }

    public virtual DbSet<OR_StoreSafetyStockSettingPOPivot_Import> OR_StoreSafetyStockSettingPOPivot_Imports { get; set; }

    public virtual DbSet<OR_StoreSafetyStockSettingPivot_Import> OR_StoreSafetyStockSettingPivot_Imports { get; set; }

    public virtual DbSet<OR_StoreTransfer_Detail> OR_StoreTransfer_Details { get; set; }

    public virtual DbSet<OR_StoreTransfer_Detail_Archive> OR_StoreTransfer_Detail_Archives { get; set; }

    public virtual DbSet<OR_StoreTransfer_Head> OR_StoreTransfer_Heads { get; set; }

    public virtual DbSet<OR_StoreTransfer_Head_Archive> OR_StoreTransfer_Head_Archives { get; set; }

    public virtual DbSet<SOR_LogLoginAction> SOR_LogLoginActions { get; set; }

    public virtual DbSet<S_Normalization_SaleOrder_Log> S_Normalization_SaleOrder_Logs { get; set; }

    public virtual DbSet<S_PreCalculation> S_PreCalculations { get; set; }

    public virtual DbSet<S_ReplicateTransaction> S_ReplicateTransactions { get; set; }

    public virtual DbSet<S_SystemCustomerAndStore> S_SystemCustomerAndStores { get; set; }

    public virtual DbSet<S_SystemParameter> S_SystemParameters { get; set; }

    public virtual DbSet<S_SystemSetting> S_SystemSettings { get; set; }

    public virtual DbSet<S_TreeviewMenu> S_TreeviewMenus { get; set; }

    public virtual DbSet<S_TreeviewMenu_bak20230619> S_TreeviewMenu_bak20230619s { get; set; }

    public virtual DbSet<TMP_PreOrderArrival_Head> TMP_PreOrderArrival_Heads { get; set; }

    public virtual DbSet<TMP_PreOrderArrival_OrderList> TMP_PreOrderArrival_OrderLists { get; set; }

    public virtual DbSet<TMP_PreOrderArrival_ProductDetail> TMP_PreOrderArrival_ProductDetails { get; set; }

    public virtual DbSet<TMP_PreOrderArrival_ProductHead> TMP_PreOrderArrival_ProductHeads { get; set; }

    public virtual DbSet<TMP_PreOrderProductSelected> TMP_PreOrderProductSelecteds { get; set; }

    public virtual DbSet<TMP_Product> TMP_Products { get; set; }

    public virtual DbSet<TMP_ProductAdditionalOrder> TMP_ProductAdditionalOrders { get; set; }

    public virtual DbSet<TMP_ProductSelected> TMP_ProductSelecteds { get; set; }

    public virtual DbSet<TMP_SaleOrder_Detail> TMP_SaleOrder_Details { get; set; }

    public virtual DbSet<TMP_SaleOrder_Head> TMP_SaleOrder_Heads { get; set; }

    public virtual DbSet<TMP_StoreProductQty> TMP_StoreProductQties { get; set; }

    public virtual DbSet<TMP_StoreProductSelected> TMP_StoreProductSelecteds { get; set; }

    public virtual DbSet<TMP_StoreSafetyStockSettingPOPivot_Import> TMP_StoreSafetyStockSettingPOPivot_Imports { get; set; }

    public virtual DbSet<TMP_StoreSafetyStockSettingPivot_Import> TMP_StoreSafetyStockSettingPivot_Imports { get; set; }

    public virtual DbSet<TMP_TransactionResult> TMP_TransactionResults { get; set; }

    public virtual DbSet<TMP_TransactionSource> TMP_TransactionSources { get; set; }

    public virtual DbSet<VBF_Category> VBF_Categories { get; set; }

    public virtual DbSet<VBF_Color> VBF_Colors { get; set; }

    public virtual DbSet<VBF_DistributionStorePriority> VBF_DistributionStorePriorities { get; set; }

    public virtual DbSet<VBF_Employee> VBF_Employees { get; set; }

    public virtual DbSet<VBF_EmployeeStoreBelonging> VBF_EmployeeStoreBelongings { get; set; }

    public virtual DbSet<VBF_Member> VBF_Members { get; set; }

    public virtual DbSet<VBF_Product> VBF_Products { get; set; }

    public virtual DbSet<VBF_ProductStopSetting> VBF_ProductStopSettings { get; set; }

    public virtual DbSet<VBF_Product_Code> VBF_Product_Codes { get; set; }

    public virtual DbSet<VBF_Size> VBF_Sizes { get; set; }

    public virtual DbSet<VBF_Store> VBF_Stores { get; set; }

    public virtual DbSet<VBF_StorePrioritySetting> VBF_StorePrioritySettings { get; set; }

    public virtual DbSet<VBF_StoreSafetyStockSetting> VBF_StoreSafetyStockSettings { get; set; }

    public virtual DbSet<VBF_StoreSafetyStockSettingPivot> VBF_StoreSafetyStockSettingPivots { get; set; }

    public virtual DbSet<VBF_Supplier> VBF_Suppliers { get; set; }

    public virtual DbSet<VBF_User> VBF_Users { get; set; }

    public virtual DbSet<VGB_InventoryTransactionItem00> VGB_InventoryTransactionItem00s { get; set; }

    public virtual DbSet<VGB_InventoryTransactionItem01> VGB_InventoryTransactionItem01s { get; set; }

    public virtual DbSet<VGB_InventoryTransactionItem02> VGB_InventoryTransactionItem02s { get; set; }

    public virtual DbSet<VGB_InventoryTransactionItem03> VGB_InventoryTransactionItem03s { get; set; }

    public virtual DbSet<VGB_InventoryTransactionItem1612> VGB_InventoryTransactionItem1612s { get; set; }

    public virtual DbSet<VGB_SaleItem00_ProductId> VGB_SaleItem00_ProductIds { get; set; }

    public virtual DbSet<VGB_SaleItem01_ProductId> VGB_SaleItem01_ProductIds { get; set; }

    public virtual DbSet<VGB_SaleItem02_ProductId> VGB_SaleItem02_ProductIds { get; set; }

    public virtual DbSet<VGB_SaleItem03_ProductId> VGB_SaleItem03_ProductIds { get; set; }

    public virtual DbSet<VGB_SaleItem1612_ProductId> VGB_SaleItem1612_ProductIds { get; set; }

    public virtual DbSet<VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail> VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetails { get; set; }

    public virtual DbSet<VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail_VGB> VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail_VGBs { get; set; }

    public virtual DbSet<VJN_ProductStockALL> VJN_ProductStockALLs { get; set; }

    public virtual DbSet<VJN_Product_EachStore_Stock_Sale> VJN_Product_EachStore_Stock_Sales { get; set; }

    public virtual DbSet<VJN_Supplier_VGB_InventoryTransactionItem00> VJN_Supplier_VGB_InventoryTransactionItem00s { get; set; }

    public virtual DbSet<VJN_Supplier_VGB_InventoryTransactionItem01> VJN_Supplier_VGB_InventoryTransactionItem01s { get; set; }

    public virtual DbSet<VJN_Supplier_VGB_InventoryTransactionItem02> VJN_Supplier_VGB_InventoryTransactionItem02s { get; set; }

    public virtual DbSet<VJN_Supplier_VGB_InventoryTransactionItem03> VJN_Supplier_VGB_InventoryTransactionItem03s { get; set; }

    public virtual DbSet<VJN_Supplier_VGB_InventoryTransactionItem1612> VJN_Supplier_VGB_InventoryTransactionItem1612s { get; set; }

    public virtual DbSet<VJN_Supplier_VGB_InventoryTransactionItemALL> VJN_Supplier_VGB_InventoryTransactionItemALLs { get; set; }

    public virtual DbSet<VJN_Supplier_VGB_InventoryTransactionItemALL_VGB_Sum_ProductID> VJN_Supplier_VGB_InventoryTransactionItemALL_VGB_Sum_ProductIDs { get; set; }

    public virtual DbSet<VJN_VGB_SaleItemALL> VJN_VGB_SaleItemALLs { get; set; }

    public virtual DbSet<VMT_ProductFlowStatistics_ByStore> VMT_ProductFlowStatistics_ByStores { get; set; }

    public virtual DbSet<VMT_ProductFlowStatistics_ByStore_00> VMT_ProductFlowStatistics_ByStore_00s { get; set; }

    public virtual DbSet<VMT_ProductFlowStatistics_ByStore_01> VMT_ProductFlowStatistics_ByStore_01s { get; set; }

    public virtual DbSet<VMT_ProductFlowStatistics_ByStore_02> VMT_ProductFlowStatistics_ByStore_02s { get; set; }

    public virtual DbSet<VMT_ProductFlowStatistics_ByStore_03> VMT_ProductFlowStatistics_ByStore_03s { get; set; }

    public virtual DbSet<VMT_ProductFlowStatistics_ByStore_04> VMT_ProductFlowStatistics_ByStore_04s { get; set; }

    public virtual DbSet<VMT_ProductFlowStatistics_ByStore_1612> VMT_ProductFlowStatistics_ByStore_1612s { get; set; }

    public virtual DbSet<VMT_ProductStock_ByStore> VMT_ProductStock_ByStores { get; set; }

    public virtual DbSet<VOR_CompanyPreOrderInStore_Head> VOR_CompanyPreOrderInStore_Heads { get; set; }

    public virtual DbSet<VOR_CompanyPreOrderInStore_Store> VOR_CompanyPreOrderInStore_Stores { get; set; }

    public virtual DbSet<VOR_CompanyPurchasingOrder_Detail> VOR_CompanyPurchasingOrder_Details { get; set; }

    public virtual DbSet<VOR_CompanyPurchasingOrder_Head> VOR_CompanyPurchasingOrder_Heads { get; set; }

    public virtual DbSet<VOR_CounterProductOrderDetail> VOR_CounterProductOrderDetails { get; set; }

    public virtual DbSet<VOR_CounterProductOrderHead> VOR_CounterProductOrderHeads { get; set; }

    public virtual DbSet<VOR_DistributionProductStoreDetailRec> VOR_DistributionProductStoreDetailRecs { get; set; }

    public virtual DbSet<VOR_DistributionProductStoreHead> VOR_DistributionProductStoreHeads { get; set; }

    public virtual DbSet<VOR_EXPORT_ProductInfo_Detail> VOR_EXPORT_ProductInfo_Details { get; set; }

    public virtual DbSet<VOR_EXPORT_SaleOrder> VOR_EXPORT_SaleOrders { get; set; }

    public virtual DbSet<VOR_EXPORT_SaleOrder_Head_Member> VOR_EXPORT_SaleOrder_Head_Members { get; set; }

    public virtual DbSet<VOR_InStock_Detail> VOR_InStock_Details { get; set; }

    public virtual DbSet<VOR_InStock_Detail_UnionArchive> VOR_InStock_Detail_UnionArchives { get; set; }

    public virtual DbSet<VOR_InStock_Head> VOR_InStock_Heads { get; set; }

    public virtual DbSet<VOR_InStock_Head_UnionArchive> VOR_InStock_Head_UnionArchives { get; set; }

    public virtual DbSet<VOR_InventoryTransaction00> VOR_InventoryTransaction00s { get; set; }

    public virtual DbSet<VOR_InventoryTransaction00_VJN_Supplier> VOR_InventoryTransaction00_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransaction01> VOR_InventoryTransaction01s { get; set; }

    public virtual DbSet<VOR_InventoryTransaction01_VJN_Supplier> VOR_InventoryTransaction01_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransaction02> VOR_InventoryTransaction02s { get; set; }

    public virtual DbSet<VOR_InventoryTransaction02_VJN_Supplier> VOR_InventoryTransaction02_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransaction03> VOR_InventoryTransaction03s { get; set; }

    public virtual DbSet<VOR_InventoryTransaction03_VJN_Supplier> VOR_InventoryTransaction03_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransaction1612> VOR_InventoryTransaction1612s { get; set; }

    public virtual DbSet<VOR_InventoryTransaction1612_VJN_Supplier> VOR_InventoryTransaction1612_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem00> VOR_InventoryTransactionItem00s { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem00_VJN_Supplier> VOR_InventoryTransactionItem00_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem01> VOR_InventoryTransactionItem01s { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem01_VJN_Supplier> VOR_InventoryTransactionItem01_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem02> VOR_InventoryTransactionItem02s { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem02_VJN_Supplier> VOR_InventoryTransactionItem02_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem03> VOR_InventoryTransactionItem03s { get; set; }

    public virtual DbSet<VOR_InventoryTransactionItem03_VJN_Supplier> VOR_InventoryTransactionItem03_VJN_Suppliers { get; set; }

    public virtual DbSet<VOR_PreOrderArrival_Detail> VOR_PreOrderArrival_Details { get; set; }

    public virtual DbSet<VOR_PreOrderArrival_Head> VOR_PreOrderArrival_Heads { get; set; }

    public virtual DbSet<VOR_PreOrderInStorePickUp_Detail> VOR_PreOrderInStorePickUp_Details { get; set; }

    public virtual DbSet<VOR_PreOrderInStorePickUp_Head> VOR_PreOrderInStorePickUp_Heads { get; set; }

    public virtual DbSet<VOR_PreOrderReminder_Detail> VOR_PreOrderReminder_Details { get; set; }

    public virtual DbSet<VOR_PreOrder_Detail> VOR_PreOrder_Details { get; set; }

    public virtual DbSet<VOR_PreOrder_Head> VOR_PreOrder_Heads { get; set; }

    public virtual DbSet<VOR_ProductAdditionalOrderHead> VOR_ProductAdditionalOrderHeads { get; set; }

    public virtual DbSet<VOR_ProductBarcodeImportDetail> VOR_ProductBarcodeImportDetails { get; set; }

    public virtual DbSet<VOR_ProductUploadDetail> VOR_ProductUploadDetails { get; set; }

    public virtual DbSet<VOR_SaleOrder_Detail> VOR_SaleOrder_Details { get; set; }

    public virtual DbSet<VOR_SaleOrder_Detail_Archive> VOR_SaleOrder_Detail_Archives { get; set; }

    public virtual DbSet<VOR_SaleOrder_Detail_Archive_GroupBySaleOrderID> VOR_SaleOrder_Detail_Archive_GroupBySaleOrderIDs { get; set; }

    public virtual DbSet<VOR_SaleOrder_Detail_GroupBySaleOrderID> VOR_SaleOrder_Detail_GroupBySaleOrderIDs { get; set; }

    public virtual DbSet<VOR_SaleOrder_Detail_UnionArchive> VOR_SaleOrder_Detail_UnionArchives { get; set; }

    public virtual DbSet<VOR_SaleOrder_Head> VOR_SaleOrder_Heads { get; set; }

    public virtual DbSet<VOR_SaleOrder_Head_ExclusivePreOrder> VOR_SaleOrder_Head_ExclusivePreOrders { get; set; }

    public virtual DbSet<VOR_SaleOrder_Head_Member> VOR_SaleOrder_Head_Members { get; set; }

    public virtual DbSet<VOR_SaleOrder_Head_Member_Archive> VOR_SaleOrder_Head_Member_Archives { get; set; }

    public virtual DbSet<VOR_SaleOrder_Head_Member_bak> VOR_SaleOrder_Head_Member_baks { get; set; }

    public virtual DbSet<VOR_SaleOrder_Head_UnionArchive> VOR_SaleOrder_Head_UnionArchives { get; set; }

    public virtual DbSet<VOR_SaleReturnOrder_Head> VOR_SaleReturnOrder_Heads { get; set; }

    public virtual DbSet<VOR_StoreInTransitCommit_Head> VOR_StoreInTransitCommit_Heads { get; set; }

    public virtual DbSet<VOR_StoreInTransitCommit_SourceList> VOR_StoreInTransitCommit_SourceLists { get; set; }

    public virtual DbSet<VOR_StoreTransfer_Detail> VOR_StoreTransfer_Details { get; set; }

    public virtual DbSet<VOR_StoreTransfer_Detail_UnionArchive> VOR_StoreTransfer_Detail_UnionArchives { get; set; }

    public virtual DbSet<VOR_StoreTransfer_Head> VOR_StoreTransfer_Heads { get; set; }

    public virtual DbSet<VOR_StoreTransfer_Head_InTransitXXXXX> VOR_StoreTransfer_Head_InTransitXXXXXes { get; set; }

    public virtual DbSet<VOR_StoreTransfer_Head_UnionArchive> VOR_StoreTransfer_Head_UnionArchives { get; set; }

    public virtual DbSet<VRP_ProductAdditionalOrderDetail> VRP_ProductAdditionalOrderDetails { get; set; }

    public virtual DbSet<VRP_ProductAdditionalOrderInsert> VRP_ProductAdditionalOrderInserts { get; set; }

    public virtual DbSet<VRP_ProductCounterInventoryForSaleQty_EachStore_YURUBRA> VRP_ProductCounterInventoryForSaleQty_EachStore_YURUBRAs { get; set; }

    public virtual DbSet<VRP_ProductCounterInventorySaleQty_EachStore> VRP_ProductCounterInventorySaleQty_EachStores { get; set; }

    public virtual DbSet<VRP_ProductCounterInventorySaleQty_EachStore_31851271> VRP_ProductCounterInventorySaleQty_EachStore_31851271s { get; set; }

    public virtual DbSet<VRP_ProductCounterInventorySaleQty_EachStore_YURUBRA> VRP_ProductCounterInventorySaleQty_EachStore_YURUBRAs { get; set; }

    public virtual DbSet<VS_ReplicateTransaction> VS_ReplicateTransactions { get; set; }

    public virtual DbSet<VS_SystemParameter> VS_SystemParameters { get; set; }

    public virtual DbSet<VTMP_PreOrderArrival_ProductDetail> VTMP_PreOrderArrival_ProductDetails { get; set; }

    public virtual DbSet<VTMP_PreOrderArrival_ProductHead> VTMP_PreOrderArrival_ProductHeads { get; set; }

    public virtual DbSet<VTMP_PreOrderProductSelected> VTMP_PreOrderProductSelecteds { get; set; }

    public virtual DbSet<VTMP_SaleOrder_Detail> VTMP_SaleOrder_Details { get; set; }

    public virtual DbSet<VTMP_SaleOrder_Detail_GroupBySaleOrderID> VTMP_SaleOrder_Detail_GroupBySaleOrderIDs { get; set; }

    public virtual DbSet<VTMP_SaleOrder_Head> VTMP_SaleOrder_Heads { get; set; }

    public virtual DbSet<V_OR_CounterProductOrderDetail_ByProductID_SumQty_ALL> V_OR_CounterProductOrderDetail_ByProductID_SumQty_ALLs { get; set; }

    public virtual DbSet<V_OR_ProductAdditionalOrderDetail_ByProduct_SumQty_ALL> V_OR_ProductAdditionalOrderDetail_ByProduct_SumQty_ALLs { get; set; }

    public virtual DbSet<V_poitemstrntemp1> V_poitemstrntemp1s { get; set; }

    public virtual DbSet<vwUser> vwUsers { get; set; }

    public virtual DbSet<xxxVOR_CounterProductOrder> xxxVOR_CounterProductOrders { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=LOCALHOST\\MSSQLSERVER2012;Initial Catalog=RmsHq_YURUBRA;Persist Security Info=True;Integrated Security=True;TrustServerCertificate=true;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BF_Coupon>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<BF_DistributionProductStorePriority>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<BF_DistributionStorePriority>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeLastModified).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_EmployeeStoreBelonging>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.StoreOrderNo).HasDefaultValue(100);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_Member>(entity =>
        {
            entity.Property(e => e.MemberLevel)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.MobilePhoneTW).IsFixedLength();
            entity.Property(e => e.Points).HasDefaultValue(0);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_Product>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_ProductSafetyStockSettingPivot>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<BF_ProductStopSetting>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_Store>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.OrderNo).HasDefaultValue((short)0);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TransitFromStoreID).IsFixedLength();
        });

        modelBuilder.Entity<BF_StorePrioritySetting>(entity =>
        {
            entity.Property(e => e.SettingTypeID)
                .HasDefaultValue("S：By門市；U：By人員")
                .IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewID).HasDefaultValue("ADMIN");
        });

        modelBuilder.Entity<BF_StorePrioritySetting_Import>(entity =>
        {
            entity.Property(e => e.SettingTypeID)
                .HasDefaultValue("S：By門市；U：By人員")
                .IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.StoreName).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewID).HasDefaultValue("ADMIN");
        });

        modelBuilder.Entity<BF_StoreSafetyStockSetting>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_StoreSafetyStockSettingPivot>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<BF_User>(entity =>
        {
            entity.Property(e => e.StoreID_Default).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_CompanyPurchasingOrder>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<MT_ProductCustomerOrder_ByStore>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductFlowStatistics_ByProduct>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductFlowStatistics_ByStore>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductInStockOrder_ByStore>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductSaleOrder_ByStore>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductStockAdjustment_ByStore>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductStock_ByStore>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<MT_ProductStoreTransfer_ByFromStore>(entity =>
        {
            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductStoreTransfer_ByStore>(entity =>
        {
            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.ToStoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<MT_ProductStoreTransfer_ByToStore>(entity =>
        {
            entity.Property(e => e.ToStoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_CompanyPreOrderInStore_Detail>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SelfStoreToStockUpQty)
                .HasDefaultValue(0)
                .HasComment("門市自身庫存分配量");
        });

        modelBuilder.Entity<OR_CompanyPreOrderInStore_Head>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_CompanyPreOrderInStore_Product>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_CompanyPreOrderInStore_Store>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreDemandQty).HasComment("門市淨需求量：如果未到貨量（門市需求）超過該門市的庫存");
        });

        modelBuilder.Entity<OR_CompanyPurchasingOrder_Detail>(entity =>
        {
            entity.Property(e => e.OrderSID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_CompanyPurchasingOrder_Head>(entity =>
        {
            entity.Property(e => e.OrderSID).ValueGeneratedNever();
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_CounterProductOrderDetail>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewID).HasDefaultValue("");
        });

        modelBuilder.Entity<OR_CounterProductOrderHead>(entity =>
        {
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewID).HasDefaultValue("");
        });

        modelBuilder.Entity<OR_DistributionProductStoreDetailDist>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_DistributionProductStoreDetailRec>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<OR_DistributionProductStoreHead>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_EXPORT_ProductInfo>(entity =>
        {
            entity.Property(e => e.ExportGID).ValueGeneratedNever();
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.ReturnValue).HasDefaultValue("");
            entity.Property(e => e.SerialNo).ValueGeneratedOnAdd();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_EXPORT_ProductInfo_Detail>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_EXPORT_ProductInfo_Summary>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_EXPORT_ProductInfo_Summary_0226>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_EXPORT_Response_Detail>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_EXPORT_SaleOrder>(entity =>
        {
            entity.Property(e => e.ExportGID).ValueGeneratedNever();
            entity.Property(e => e.ExportTypeID).IsFixedLength();
            entity.Property(e => e.HasErrorWhenSendData)
                .HasDefaultValue("0")
                .IsFixedLength();
            entity.Property(e => e.SerialNo).ValueGeneratedOnAdd();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_EXPORT_SaleOrder_Detail>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_EXPORT_SaleOrder_Exclusion>(entity =>
        {
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_EXPORT_SaleOrder_Head_Member>(entity =>
        {
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_InStock_Detail>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.InStockItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_InStock_Detail_Archive>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.InStockItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_InStock_Head>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SupplierID).IsFixedLength();
        });

        modelBuilder.Entity<OR_InStock_Head_Archive>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SupplierID).IsFixedLength();
        });

        modelBuilder.Entity<OR_NotificationMessage>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_PreOrderArrival_Detail>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StockUpQty).HasComment("已到貨件數（系統計算，此單據成立前，其它到貨單的件數）");
            entity.Property(e => e.ToStockUpQty).HasComment("本張單據指定之到貨件數（操作人員設定）");
        });

        modelBuilder.Entity<OR_PreOrderArrival_Detail_UpdatedLog>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_PreOrderArrival_Head>(entity =>
        {
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_PreOrderArrival_Head_UpdatedLog>(entity =>
        {
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_PreOrderInStorePickUp_Detail>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.Remark).HasDefaultValue("");
        });

        modelBuilder.Entity<OR_PreOrderInStorePickUp_Head>(entity =>
        {
            entity.Property(e => e.InStorePickUpQty).HasComment("本張單據成立之前，該預購單的累計已取貨量");
            entity.Property(e => e.IsFinishedToPreOrder).HasComment("本次取貨，造成預購單全部取貨完畢");
            entity.Property(e => e.RemainQtyForInStorePickUp).HasComment("本張預購單剩餘未取的數量");
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_PreOrderReminder_Detail>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_PreOrder_Detail>(entity =>
        {
            entity.Property(e => e.InStorePickUpQty).HasComment("本單據本貨號累計已取貨數量");
            entity.Property(e => e.InStorePickUpTimes).HasComment("取貨次數");
            entity.Property(e => e.IsAllowItemForInStorePickUp).HasComment("該項目是否允許取貨（有存在已到貨、尚未取貨之項目）");
            entity.Property(e => e.IsFinishedItemForStockUp).HasComment("該項目已全部到貨完成");
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StockUpQty).HasComment("紀錄本單據本貨號的到貨數量（資料來源：OR_PreOrderInStorePickUp_Detail）");
            entity.Property(e => e.StockUpTimes).HasComment("到貨次數");
        });

        modelBuilder.Entity<OR_PreOrder_Head>(entity =>
        {
            entity.Property(e => e.ConsigneeAddress).HasDefaultValue("");
            entity.Property(e => e.ConsigneeName).HasDefaultValue("");
            entity.Property(e => e.ConsigneePhone)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.HasItemForInStorePickUp).HasComment("該單據有任一品項可接受取貨（已備、未取）");
            entity.Property(e => e.HasItemToBeRemindedToCustomer).HasComment("存在任一項目需要提醒客戶（來取貨；目前等同與已備貨、未取貨）");
            entity.Property(e => e.HasItemWithInStorePickUp).HasComment("已有任一品項被取貨");
            entity.Property(e => e.HasItemWithStockUp)
                .HasDefaultValue(false)
                .HasComment("已有任一品項備貨完成");
            entity.Property(e => e.IsFinishedForInStorePickUp).HasComment("整張單據取貨完成");
            entity.Property(e => e.IsFinishedForStockUp).HasComment("整張單據被貨完成");
            entity.Property(e => e.ItemCountForAllowInStorePickUp).HasDefaultValue((short)0);
            entity.Property(e => e.PreOrderID).IsFixedLength();
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SubPrice).HasDefaultValue(0m);
            entity.Property(e => e.SubQty).HasDefaultValue(0);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_ProductAdditionalOrderDetail>(entity =>
        {
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_ProductAdditionalOrderHead>(entity =>
        {
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Remark).HasDefaultValue("");
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_ProductAdditionalOrderSource>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_ProductBarcodeImportDetail>(entity =>
        {
            entity.Property(e => e.ProductCode).IsFixedLength();
        });

        modelBuilder.Entity<OR_ProductBarcodeImportHead>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_ProductUploadDetail>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_ProductUploadHead>(entity =>
        {
            entity.Property(e => e.OrderID).IsFixedLength();
            entity.Property(e => e.OrderTypeID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_RemotelyMemberQuerying>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_SaleOrder_Detail>(entity =>
        {
            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_SaleOrder_Detail_Archive>(entity =>
        {
            entity.HasKey(e => new { e.StoreID, e.SaleItemID }).HasName("PK_OR_SaleOrder_Detail_Archive_1");

            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_SaleOrder_Detail_Temp>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<OR_SaleOrder_Head>(entity =>
        {
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.CashierId)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.IsReturnToStore).HasComment("該筆銷貨單是否有被產生對應的銷退單");
            entity.Property(e => e.IsSaleReturn).HasComment("該筆單據銷退單（依據一筆先前實際發生的銷貨單）");
            entity.Property(e => e.MemberID)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_SaleOrder_Head_Archive>(entity =>
        {
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.CashierId)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.IsReturnToStore).HasComment("該筆銷貨單是否有被產生對應的銷退單");
            entity.Property(e => e.IsSaleReturn).HasComment("該筆單據銷退單（依據一筆先前實際發生的銷貨單）");
            entity.Property(e => e.MemberID)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_SaleOrder_Head_Temp>(entity =>
        {
            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<OR_SaleReturnOrder_Head>(entity =>
        {
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_StockAdjustment_Detail>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_StockAdjustment_Head>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<OR_StoreInTransitCommit_Head>(entity =>
        {
            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OrderType).HasComment("1：入庫單；2：轉貨（TranIn）單");
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<OR_StoreSafetyStockImportDetail>(entity =>
        {
            entity.Property(e => e.ProductCode).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<OR_StoreSafetyStockImportHead>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_StoreSafetyStockSettingPOPivot_Import>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_StoreSafetyStockSettingPivot_Import>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<OR_StoreTransfer_Detail>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.StoreTransferItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_StoreTransfer_Detail_Archive>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.StoreTransferItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<OR_StoreTransfer_Head>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ToStoreID).IsFixedLength();
        });

        modelBuilder.Entity<OR_StoreTransfer_Head_Archive>(entity =>
        {
            entity.Property(e => e.TransactionID).IsFixedLength();
            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ToStoreID).IsFixedLength();
        });

        modelBuilder.Entity<SOR_LogLoginAction>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_Normalization_SaleOrder_Log>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_PreCalculation>(entity =>
        {
            entity.Property(e => e.TimeBeginPreCalculate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_ReplicateTransaction>(entity =>
        {
            entity.Property(e => e.ReplicatedCategoryID).HasDefaultValue((byte)1);
            entity.Property(e => e.ReplicatedDirectionID).HasDefaultValue((byte)1);
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TimeBeginReplicating).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_SystemCustomerAndStore>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<S_SystemParameter>(entity =>
        {
            entity.Property(e => e.ParameterNo).ValueGeneratedNever();
            entity.Property(e => e.ParameterID).IsFixedLength();
        });

        modelBuilder.Entity<S_SystemSetting>(entity =>
        {
            entity.Property(e => e.SystemID).IsFixedLength();
        });

        modelBuilder.Entity<S_TreeviewMenu>(entity =>
        {
            entity.HasKey(e => e.NodeValue).HasName("PK_S_TreeviewMenu_1");

            entity.Property(e => e.NodeValue).IsFixedLength();
            entity.Property(e => e.ParentNodeValue).IsFixedLength();
        });

        modelBuilder.Entity<S_TreeviewMenu_bak20230619>(entity =>
        {
            entity.Property(e => e.NodeValue).IsFixedLength();
            entity.Property(e => e.ParentNodeValue).IsFixedLength();
        });

        modelBuilder.Entity<TMP_PreOrderArrival_Head>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_PreOrderArrival_ProductDetail>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<TMP_PreOrderArrival_ProductHead>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.IsSelected).HasDefaultValue(true);
            entity.Property(e => e.PreOrderHeadCount).HasComment("同一貨號有存在於幾張預購單中");
        });

        modelBuilder.Entity<TMP_PreOrderProductSelected>(entity =>
        {
            entity.Property(e => e.ItemID)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.ItemSID).ValueGeneratedOnAdd();
            entity.Property(e => e.ProductCode).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_Product>(entity =>
        {
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_ProductAdditionalOrder>(entity =>
        {
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserAddNewID).HasDefaultValue("");
        });

        modelBuilder.Entity<TMP_ProductSelected>(entity =>
        {
            entity.Property(e => e.ProductSelectedGID).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_SaleOrder_Detail>(entity =>
        {
            entity.HasKey(e => e.SaleItemID).HasName("PK_TMP_SaleOrder_Detail_1");

            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_SaleOrder_Head>(entity =>
        {
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.CashierId)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.IsReturnToStore).HasComment("該筆銷貨單是否有被產生對應的銷退單");
            entity.Property(e => e.IsSaleReturn).HasComment("該筆單據銷退單（依據一筆先前實際發生的銷貨單）");
            entity.Property(e => e.MemberID)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TMP_StoreProductQty>(entity =>
        {
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.UserID).IsFixedLength();
            entity.Property(e => e.ProductCode)
                .HasDefaultValue("")
                .IsFixedLength();
        });

        modelBuilder.Entity<TMP_StoreProductSelected>(entity =>
        {
            entity.HasKey(e => new { e.ProductSelectedGID, e.StoreID, e.ProductID, e.SerialNo }).HasName("PK_TMP_StoreProductSelected_1");

            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SerialNo).ValueGeneratedOnAdd();
            entity.Property(e => e.TableOrderCode)
                .HasDefaultValue("")
                .IsFixedLength();
            entity.Property(e => e.TimeAddNew).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<VBF_Category>(entity =>
        {
            entity.ToView("VBF_Category");
        });

        modelBuilder.Entity<VBF_Color>(entity =>
        {
            entity.ToView("VBF_Color");
        });

        modelBuilder.Entity<VBF_DistributionStorePriority>(entity =>
        {
            entity.ToView("VBF_DistributionStorePriority");

            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VBF_Employee>(entity =>
        {
            entity.ToView("VBF_Employee");
        });

        modelBuilder.Entity<VBF_EmployeeStoreBelonging>(entity =>
        {
            entity.ToView("VBF_EmployeeStoreBelonging");
        });

        modelBuilder.Entity<VBF_Member>(entity =>
        {
            entity.ToView("VBF_Member");

            entity.Property(e => e.MemberSID).ValueGeneratedOnAdd();
            entity.Property(e => e.MobilePhoneTW).IsFixedLength();
        });

        modelBuilder.Entity<VBF_Product>(entity =>
        {
            entity.ToView("VBF_Product");
        });

        modelBuilder.Entity<VBF_ProductStopSetting>(entity =>
        {
            entity.ToView("VBF_ProductStopSetting");
        });

        modelBuilder.Entity<VBF_Product_Code>(entity =>
        {
            entity.ToView("VBF_Product_Code");
        });

        modelBuilder.Entity<VBF_Size>(entity =>
        {
            entity.ToView("VBF_Size");
        });

        modelBuilder.Entity<VBF_Store>(entity =>
        {
            entity.ToView("VBF_Store");
        });

        modelBuilder.Entity<VBF_StorePrioritySetting>(entity =>
        {
            entity.ToView("VBF_StorePrioritySetting");

            entity.Property(e => e.SettingTypeID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VBF_StoreSafetyStockSetting>(entity =>
        {
            entity.ToView("VBF_StoreSafetyStockSetting");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VBF_StoreSafetyStockSettingPivot>(entity =>
        {
            entity.ToView("VBF_StoreSafetyStockSettingPivot");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VBF_Supplier>(entity =>
        {
            entity.ToView("VBF_Supplier");
        });

        modelBuilder.Entity<VBF_User>(entity =>
        {
            entity.ToView("VBF_User");

            entity.Property(e => e.StoreID_Default).IsFixedLength();
        });

        modelBuilder.Entity<VGB_InventoryTransactionItem00>(entity =>
        {
            entity.ToView("VGB_InventoryTransactionItem00");
        });

        modelBuilder.Entity<VGB_InventoryTransactionItem01>(entity =>
        {
            entity.ToView("VGB_InventoryTransactionItem01");
        });

        modelBuilder.Entity<VGB_InventoryTransactionItem02>(entity =>
        {
            entity.ToView("VGB_InventoryTransactionItem02");
        });

        modelBuilder.Entity<VGB_InventoryTransactionItem03>(entity =>
        {
            entity.ToView("VGB_InventoryTransactionItem03");
        });

        modelBuilder.Entity<VGB_InventoryTransactionItem1612>(entity =>
        {
            entity.ToView("VGB_InventoryTransactionItem1612");
        });

        modelBuilder.Entity<VGB_SaleItem00_ProductId>(entity =>
        {
            entity.ToView("VGB_SaleItem00_ProductId");
        });

        modelBuilder.Entity<VGB_SaleItem01_ProductId>(entity =>
        {
            entity.ToView("VGB_SaleItem01_ProductId");
        });

        modelBuilder.Entity<VGB_SaleItem02_ProductId>(entity =>
        {
            entity.ToView("VGB_SaleItem02_ProductId");
        });

        modelBuilder.Entity<VGB_SaleItem03_ProductId>(entity =>
        {
            entity.ToView("VGB_SaleItem03_ProductId");
        });

        modelBuilder.Entity<VGB_SaleItem1612_ProductId>(entity =>
        {
            entity.ToView("VGB_SaleItem1612_ProductId");
        });

        modelBuilder.Entity<VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail>(entity =>
        {
            entity.ToView("VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail");
        });

        modelBuilder.Entity<VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail_VGB>(entity =>
        {
            entity.ToView("VJN_OR_ProductAdditionalOrderSource_CounterProductOrderDetail_VGB");
        });

        modelBuilder.Entity<VJN_ProductStockALL>(entity =>
        {
            entity.ToView("VJN_ProductStockALL");
        });

        modelBuilder.Entity<VJN_Product_EachStore_Stock_Sale>(entity =>
        {
            entity.ToView("VJN_Product_EachStore_Stock_Sale");
        });

        modelBuilder.Entity<VJN_Supplier_VGB_InventoryTransactionItem00>(entity =>
        {
            entity.ToView("VJN_Supplier_VGB_InventoryTransactionItem00");
        });

        modelBuilder.Entity<VJN_Supplier_VGB_InventoryTransactionItem01>(entity =>
        {
            entity.ToView("VJN_Supplier_VGB_InventoryTransactionItem01");
        });

        modelBuilder.Entity<VJN_Supplier_VGB_InventoryTransactionItem02>(entity =>
        {
            entity.ToView("VJN_Supplier_VGB_InventoryTransactionItem02");
        });

        modelBuilder.Entity<VJN_Supplier_VGB_InventoryTransactionItem03>(entity =>
        {
            entity.ToView("VJN_Supplier_VGB_InventoryTransactionItem03");
        });

        modelBuilder.Entity<VJN_Supplier_VGB_InventoryTransactionItem1612>(entity =>
        {
            entity.ToView("VJN_Supplier_VGB_InventoryTransactionItem1612");
        });

        modelBuilder.Entity<VJN_Supplier_VGB_InventoryTransactionItemALL>(entity =>
        {
            entity.ToView("VJN_Supplier_VGB_InventoryTransactionItemALL");
        });

        modelBuilder.Entity<VJN_Supplier_VGB_InventoryTransactionItemALL_VGB_Sum_ProductID>(entity =>
        {
            entity.ToView("VJN_Supplier_VGB_InventoryTransactionItemALL_VGB_Sum_ProductID");
        });

        modelBuilder.Entity<VJN_VGB_SaleItemALL>(entity =>
        {
            entity.ToView("VJN_VGB_SaleItemALL");
        });

        modelBuilder.Entity<VMT_ProductFlowStatistics_ByStore>(entity =>
        {
            entity.ToView("VMT_ProductFlowStatistics_ByStore");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_ProductFlowStatistics_ByStore_00>(entity =>
        {
            entity.ToView("VMT_ProductFlowStatistics_ByStore_00");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_ProductFlowStatistics_ByStore_01>(entity =>
        {
            entity.ToView("VMT_ProductFlowStatistics_ByStore_01");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_ProductFlowStatistics_ByStore_02>(entity =>
        {
            entity.ToView("VMT_ProductFlowStatistics_ByStore_02");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_ProductFlowStatistics_ByStore_03>(entity =>
        {
            entity.ToView("VMT_ProductFlowStatistics_ByStore_03");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_ProductFlowStatistics_ByStore_04>(entity =>
        {
            entity.ToView("VMT_ProductFlowStatistics_ByStore_04");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_ProductFlowStatistics_ByStore_1612>(entity =>
        {
            entity.ToView("VMT_ProductFlowStatistics_ByStore_1612");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VMT_ProductStock_ByStore>(entity =>
        {
            entity.ToView("VMT_ProductStock_ByStore");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_CompanyPreOrderInStore_Head>(entity =>
        {
            entity.ToView("VOR_CompanyPreOrderInStore_Head");
        });

        modelBuilder.Entity<VOR_CompanyPreOrderInStore_Store>(entity =>
        {
            entity.ToView("VOR_CompanyPreOrderInStore_Store");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_CompanyPurchasingOrder_Detail>(entity =>
        {
            entity.ToView("VOR_CompanyPurchasingOrder_Detail");

            entity.Property(e => e.OrderSID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_CompanyPurchasingOrder_Head>(entity =>
        {
            entity.ToView("VOR_CompanyPurchasingOrder_Head");
        });

        modelBuilder.Entity<VOR_CounterProductOrderDetail>(entity =>
        {
            entity.ToView("VOR_CounterProductOrderDetail");
        });

        modelBuilder.Entity<VOR_CounterProductOrderHead>(entity =>
        {
            entity.ToView("VOR_CounterProductOrderHead");
        });

        modelBuilder.Entity<VOR_DistributionProductStoreDetailRec>(entity =>
        {
            entity.ToView("VOR_DistributionProductStoreDetailRec");

            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_DistributionProductStoreHead>(entity =>
        {
            entity.ToView("VOR_DistributionProductStoreHead");

            entity.Property(e => e.OrderSID).ValueGeneratedOnAdd();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_EXPORT_ProductInfo_Detail>(entity =>
        {
            entity.ToView("VOR_EXPORT_ProductInfo_Detail");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_EXPORT_SaleOrder>(entity =>
        {
            entity.ToView("VOR_EXPORT_SaleOrder");

            entity.Property(e => e.ExportTypeID).IsFixedLength();
            entity.Property(e => e.SerialNo).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<VOR_EXPORT_SaleOrder_Head_Member>(entity =>
        {
            entity.ToView("VOR_EXPORT_SaleOrder_Head_Member");

            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_InStock_Detail>(entity =>
        {
            entity.ToView("VOR_InStock_Detail");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SupplierID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_InStock_Detail_UnionArchive>(entity =>
        {
            entity.ToView("VOR_InStock_Detail_UnionArchive");

            entity.Property(e => e.InStockItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_InStock_Head>(entity =>
        {
            entity.ToView("VOR_InStock_Head");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SupplierID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_InStock_Head_UnionArchive>(entity =>
        {
            entity.ToView("VOR_InStock_Head_UnionArchive");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.SupplierID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_InventoryTransaction00>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction00");
        });

        modelBuilder.Entity<VOR_InventoryTransaction00_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction00_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransaction01>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction01");
        });

        modelBuilder.Entity<VOR_InventoryTransaction01_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction01_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransaction02>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction02");
        });

        modelBuilder.Entity<VOR_InventoryTransaction02_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction02_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransaction03>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction03");
        });

        modelBuilder.Entity<VOR_InventoryTransaction03_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction03_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransaction1612>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction1612");
        });

        modelBuilder.Entity<VOR_InventoryTransaction1612_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransaction1612_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem00>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem00");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem00_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem00_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem01>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem01");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem01_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem01_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem02>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem02");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem02_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem02_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem03>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem03");
        });

        modelBuilder.Entity<VOR_InventoryTransactionItem03_VJN_Supplier>(entity =>
        {
            entity.ToView("VOR_InventoryTransactionItem03_VJN_Supplier");
        });

        modelBuilder.Entity<VOR_PreOrderArrival_Detail>(entity =>
        {
            entity.ToView("VOR_PreOrderArrival_Detail");

            entity.Property(e => e.PreOrderID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_PreOrderArrival_Head>(entity =>
        {
            entity.ToView("VOR_PreOrderArrival_Head");

            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_PreOrderInStorePickUp_Detail>(entity =>
        {
            entity.ToView("VOR_PreOrderInStorePickUp_Detail");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_PreOrderInStorePickUp_Head>(entity =>
        {
            entity.ToView("VOR_PreOrderInStorePickUp_Head");

            entity.Property(e => e.PreOrderID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_PreOrderReminder_Detail>(entity =>
        {
            entity.ToView("VOR_PreOrderReminder_Detail");
        });

        modelBuilder.Entity<VOR_PreOrder_Detail>(entity =>
        {
            entity.ToView("VOR_PreOrder_Detail");

            entity.Property(e => e.IsAllowItemForInStorePickUpText).IsFixedLength();
            entity.Property(e => e.IsFinishedItemForInStorePickUpText).IsFixedLength();
            entity.Property(e => e.IsFinishedItemForStockUpText).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_PreOrder_Head>(entity =>
        {
            entity.ToView("VOR_PreOrder_Head");

            entity.Property(e => e.ConsigneePhone).IsFixedLength();
            entity.Property(e => e.MemberLevel).IsFixedLength();
            entity.Property(e => e.PreOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_ProductAdditionalOrderHead>(entity =>
        {
            entity.ToView("VOR_ProductAdditionalOrderHead");
        });

        modelBuilder.Entity<VOR_ProductBarcodeImportDetail>(entity =>
        {
            entity.ToView("VOR_ProductBarcodeImportDetail");
        });

        modelBuilder.Entity<VOR_ProductUploadDetail>(entity =>
        {
            entity.ToView("VOR_ProductUploadDetail");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Detail>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Detail");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Detail_Archive>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Detail_Archive");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Detail_Archive_GroupBySaleOrderID>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Detail_Archive_GroupBySaleOrderID");

            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Detail_GroupBySaleOrderID>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Detail_GroupBySaleOrderID");

            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Detail_UnionArchive>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Detail_UnionArchive");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Head>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Head");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Head_ExclusivePreOrder>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Head_ExclusivePreOrder");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Head_Member>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Head_Member");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.NewSaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Head_Member_Archive>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Head_Member_Archive");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.NewSaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Head_Member_bak>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Head_Member_bak");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleOrder_Head_UnionArchive>(entity =>
        {
            entity.ToView("VOR_SaleOrder_Head_UnionArchive");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_SaleReturnOrder_Head>(entity =>
        {
            entity.ToView("VOR_SaleReturnOrder_Head");

            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_StoreInTransitCommit_Head>(entity =>
        {
            entity.ToView("VOR_StoreInTransitCommit_Head");

            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_StoreInTransitCommit_SourceList>(entity =>
        {
            entity.ToView("VOR_StoreInTransitCommit_SourceList");

            entity.Property(e => e.FromID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_StoreTransfer_Detail>(entity =>
        {
            entity.ToView("VOR_StoreTransfer_Detail");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreTransferItemID).IsFixedLength();
            entity.Property(e => e.ToStoreID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_StoreTransfer_Detail_UnionArchive>(entity =>
        {
            entity.ToView("VOR_StoreTransfer_Detail_UnionArchive");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.StoreTransferItemID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_StoreTransfer_Head>(entity =>
        {
            entity.ToView("VOR_StoreTransfer_Head");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.ToStoreID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_StoreTransfer_Head_InTransitXXXXX>(entity =>
        {
            entity.ToView("VOR_StoreTransfer_Head_InTransitXXXXX");

            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.ToStoreID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VOR_StoreTransfer_Head_UnionArchive>(entity =>
        {
            entity.ToView("VOR_StoreTransfer_Head_UnionArchive");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.FromStoreID).IsFixedLength();
            entity.Property(e => e.ToStoreID).IsFixedLength();
            entity.Property(e => e.TransactionID).IsFixedLength();
        });

        modelBuilder.Entity<VRP_ProductAdditionalOrderDetail>(entity =>
        {
            entity.ToView("VRP_ProductAdditionalOrderDetail");
        });

        modelBuilder.Entity<VRP_ProductAdditionalOrderInsert>(entity =>
        {
            entity.ToView("VRP_ProductAdditionalOrderInsert");
        });

        modelBuilder.Entity<VRP_ProductCounterInventoryForSaleQty_EachStore_YURUBRA>(entity =>
        {
            entity.ToView("VRP_ProductCounterInventoryForSaleQty_EachStore_YURUBRA");
        });

        modelBuilder.Entity<VRP_ProductCounterInventorySaleQty_EachStore>(entity =>
        {
            entity.ToView("VRP_ProductCounterInventorySaleQty_EachStore");
        });

        modelBuilder.Entity<VRP_ProductCounterInventorySaleQty_EachStore_31851271>(entity =>
        {
            entity.ToView("VRP_ProductCounterInventorySaleQty_EachStore_31851271");
        });

        modelBuilder.Entity<VRP_ProductCounterInventorySaleQty_EachStore_YURUBRA>(entity =>
        {
            entity.ToView("VRP_ProductCounterInventorySaleQty_EachStore_YURUBRA");
        });

        modelBuilder.Entity<VS_ReplicateTransaction>(entity =>
        {
            entity.ToView("VS_ReplicateTransaction");
        });

        modelBuilder.Entity<VS_SystemParameter>(entity =>
        {
            entity.ToView("VS_SystemParameter");

            entity.Property(e => e.ParameterID).IsFixedLength();
        });

        modelBuilder.Entity<VTMP_PreOrderArrival_ProductDetail>(entity =>
        {
            entity.ToView("VTMP_PreOrderArrival_ProductDetail");

            entity.Property(e => e.PreOrderID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VTMP_PreOrderArrival_ProductHead>(entity =>
        {
            entity.ToView("VTMP_PreOrderArrival_ProductHead");

            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VTMP_PreOrderProductSelected>(entity =>
        {
            entity.ToView("VTMP_PreOrderProductSelected");

            entity.Property(e => e.ItemID).IsFixedLength();
            entity.Property(e => e.ProductID).IsFixedLength();
        });

        modelBuilder.Entity<VTMP_SaleOrder_Detail>(entity =>
        {
            entity.ToView("VTMP_SaleOrder_Detail");

            entity.Property(e => e.ProductID).IsFixedLength();
            entity.Property(e => e.SaleItemID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VTMP_SaleOrder_Detail_GroupBySaleOrderID>(entity =>
        {
            entity.ToView("VTMP_SaleOrder_Detail_GroupBySaleOrderID");

            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<VTMP_SaleOrder_Head>(entity =>
        {
            entity.ToView("VTMP_SaleOrder_Head");

            entity.Property(e => e.CashierId).IsFixedLength();
            entity.Property(e => e.MemberID).IsFixedLength();
            entity.Property(e => e.SaleOrderID).IsFixedLength();
            entity.Property(e => e.SaleOrderID_BeforeReturn).IsFixedLength();
            entity.Property(e => e.SaleReturnOrderID).IsFixedLength();
            entity.Property(e => e.StoreID).IsFixedLength();
        });

        modelBuilder.Entity<V_OR_CounterProductOrderDetail_ByProductID_SumQty_ALL>(entity =>
        {
            entity.ToView("V_OR_CounterProductOrderDetail_ByProductID_SumQty_ALL");
        });

        modelBuilder.Entity<V_OR_ProductAdditionalOrderDetail_ByProduct_SumQty_ALL>(entity =>
        {
            entity.ToView("V_OR_ProductAdditionalOrderDetail_ByProduct_SumQty_ALL");
        });

        modelBuilder.Entity<V_poitemstrntemp1>(entity =>
        {
            entity.ToView("V_poitemstrntemp1");
        });

        modelBuilder.Entity<vwUser>(entity =>
        {
            entity.ToView("vwUser");
        });

        modelBuilder.Entity<xxxVOR_CounterProductOrder>(entity =>
        {
            entity.ToView("xxxVOR_CounterProductOrder");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
