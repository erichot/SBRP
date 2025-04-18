
namespace SBRPAPIPsi.BindingModels
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {

            CreateMap<AppUser, AppUserBindingModel>();
            CreateMap<AppUserBindingModel, AppUser>();


            CreateMap<InboundStockOrderDetail, InboundStockOrderDetailBindingModel>();
            CreateMap<InboundStockOrderDetailBindingModel, InboundStockOrderDetail>();


            CreateMap<Member, MemberBindingModel>();
            CreateMap<MemberBindingModel, Member>();



            CreateMap<Product, ProductBindingModel>();
            CreateMap<ProductBindingModel, Product>();

            CreateMap<ProductCost, ProductCostBindingModel>();
            CreateMap<ProductCostBindingModel, ProductCost>();

            CreateMap<ProductGeneralCategory, ProductGeneralCategoryBindingModel>();
            CreateMap<ProductGeneralCategoryBindingModel, ProductGeneralCategory>();

            CreateMap<ProductPrice, ProductPriceBindingModel>();
            CreateMap<ProductPriceBindingModel, ProductPrice>();

            CreateMap<ProductSupplier, ProductSupplierBindingModel>();
            CreateMap<ProductSupplierBindingModel, ProductSupplier>();

            CreateMap<ProductGeneralCategoryDefinition, ProductGeneralCategoryDefinitionBindingModel>();
            CreateMap<ProductGeneralCategoryDefinitionBindingModel, ProductGeneralCategoryDefinition>();


            
            CreateMap<ProductGeneralCategoryItem, ProductGeneralCategoryItemBindingModel>();
            CreateMap<ProductGeneralCategoryItemBindingModel, ProductGeneralCategoryItem>();
            CreateMap<BusinessProcessResult<ProductGeneralCategoryItem>, BusinessProcessResult<ProductGeneralCategoryItemBindingModel>>();


            CreateMap<SaleOrderDetail, SaleOrderDetailBindingModel>();
            CreateMap<SaleOrderDetailBindingModel, SaleOrderDetail>();




            CreateMap<Stock, StockBindingModel>();
            CreateMap<StockBindingModel, Stock>();
            

            CreateMap<StockTransferOrderDetail, StockTransferOrderDetailBindingModel>();
            CreateMap<StockTransferOrderDetailBindingModel,StockTransferOrderDetail>();


            CreateMap<Supplier, SupplierBindingModel>();
            CreateMap<SupplierBindingModel, Supplier>();
            

        }
    }
}
