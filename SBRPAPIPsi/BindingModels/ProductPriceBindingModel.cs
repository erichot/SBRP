namespace SBRPAPIPsi.BindingModels
{
    public class ProductPriceBindingModel : ProductPrice
    {
        [JsonIgnore]
        public ProductBindingModel Product { get; set; }
    }



}
