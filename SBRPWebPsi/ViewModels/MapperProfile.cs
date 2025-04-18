

namespace SBRPWebPsi.ViewModels
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppUserViewModel, AppUser>();




            CreateMap<InboundStockOrder, InboundStockOrderViewModel>();
            CreateMap<InboundStockOrderViewModel,InboundStockOrder>();
            CreateMap<InboundStockOrderDetail, InboundStockOrderDetailViewModel>();
            CreateMap<InboundStockOrderDetailViewModel, InboundStockOrderDetail>();
            CreateMap<InboundStockOrderFilterViewModel, InboundStockOrderFilter>();



            CreateMap<Member, MemberViewModel>();
            CreateMap<MemberViewModel, Member>();


            CreateMap<Menuitem, MenuitemViewModel>();



            CreateMap<OperationClassStock, OperationClassStockViewModel>();
            CreateMap<OperationClassStockViewModel, OperationClassStock>();




            CreateMap<ProductGeneralCategory, ProductGeneralCategoryViewModel>();
            CreateMap<ProductGeneralCategoryViewModel, ProductGeneralCategory>();

            CreateMap<ProductGeneralCategoryDefinition, ProductGeneralCategoryDefinitionViewModel>();
            CreateMap<ProductGeneralCategoryDefinitionViewModel, ProductGeneralCategoryDefinition>();

            CreateMap<ProductGeneralCategoryItem, ProductGeneralCategoryItemViewModel>();
            CreateMap<ProductGeneralCategoryItemViewModel, ProductGeneralCategoryItem>();

            CreateMap<ProductIdStructureDefinition, ProductIdStructureDefinitionViewModel>();
            CreateMap<ProductIdStructureDefinitionViewModel, ProductIdStructureDefinition>();

            CreateMap<ProductSupplier, ProductSupplierViewModel>();
            CreateMap<ProductSupplierViewModel, ProductSupplier>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<ProductCost, ProductCostViewModel>();
            CreateMap<ProductCostViewModel, ProductCost>();

            CreateMap<ProductPrice, ProductPriceViewModel>();
            CreateMap<ProductPriceViewModel, ProductPrice>();

            CreateMap<ProductPriceDefinition, ProductPriceDefinitionViewModel>();
            CreateMap<ProductPriceDefinitionViewModel, ProductPriceDefinition>();

            CreateMap<ProductStockPivotReportViewFilter, ProductStockPivotReportFilter>();


            CreateMap<SaleOrder, SaleOrderViewModel>();
            CreateMap<SaleOrderViewModel, SaleOrder>();
            CreateMap<SaleOrderDetail, SaleOrderDetailViewModel>();
            CreateMap<SaleOrderDetailViewModel, SaleOrderDetail>();
            CreateMap<SaleOrderFilterViewModel, SaleOrderFilter>();



            CreateMap<Stock, StockViewModel>();
            CreateMap<StockViewModel, Stock>();
            //CreateMap<StockFilter, StockFilterViewEntity>();
            CreateMap<StockFilterViewEntity, StockFilter>();


            CreateMap<StockTransferOrder, StockTransferOrderViewModel>();
            CreateMap<StockTransferOrderViewModel, StockTransferOrder>();
            CreateMap<StockTransferOrderDetail, StockTransferOrderDetailViewModel>();
            CreateMap<StockTransferOrderDetailViewModel, StockTransferOrderDetail>();


            CreateMap<Store, StoreViewModel>();
            CreateMap<StoreViewModel, Store>();


            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<SupplierFilterViewEntity, SupplierFilter>();
        }
    }
}

