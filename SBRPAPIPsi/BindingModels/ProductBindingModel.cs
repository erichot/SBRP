namespace SBRPAPIPsi.BindingModels
{
    public class ProductBindingModel : Product
    {

        public List<ProductCostBindingModel> ProductCosts { get; set; }

        public List<ProductGeneralCategoryBindingModel> ProductGeneralCategories { get; set; }

        public List<ProductPriceBindingModel> ProductPrices { get; set; }

        public List<ProductSupplierBindingModel> ProductSuppliers { get; set; }





        public decimal GetProductCost(byte _costNo)
        {
            if (this.ProductCosts != null && this.ProductCosts.Any())
            {
                return this
                        .ProductCosts
                        .FirstOrDefault(c => c.CostNo == _costNo)?
                        .UnitCost ?? default;
            }
            return default;
        }
    }


    public class ProductBindingModel_Brief
    {
        public ProductBindingModel_Brief() { }

        public ProductBindingModel_Brief(ProductBindingModel _info)
        {
            ProductId = _info.ProductId;
            ProductName = _info.ProductName;

            if (_info.ProductCosts != null && _info.ProductCosts.Any())
            {
                UnitCost = _info.ProductCosts[0].UnitCost;
            }

            if (_info.ProductPrices != null && _info.ProductPrices.Any())
            {
                UnitPrice = _info.ProductPrices[0].UnitPrice;
            }
        }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitCost { get; set; }    

        public decimal UnitPrice { get; set; }
    }

}
