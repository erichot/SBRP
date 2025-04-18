namespace SBRPAPIPsi.BindingModels
{
    public class ProductCostBindingModel : ProductCost
    {
        [JsonIgnore]
        public ProductBindingModel Product { get; set; }
    }



}
