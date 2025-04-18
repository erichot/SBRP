

namespace SBRPAPIPsi.Extensions
{
    public static class BindingListExtension
    {
        public static List<SelectItemEntity> ToSelectItemList<T>(this IList<T> _viewList) where T:IBindingDataInterface
        {
            if (_viewList == null)
                return new List<SelectItemEntity>();
                
            

            return (
                        from item in _viewList
                        select new SelectItemEntity()
                        {
                            SelectItemText = item.SelectItemText,
                            SelectItemValue = item.SelectItemValue
                        }
                    ).ToList();             
        }





        public static List<EdOptionEntity> ToEdOptionList<T>(this IList<T> _viewList) where T : IBindingDataInterface
        {
            if (_viewList == null)
                return new List<EdOptionEntity>();



            return (
                        from item in _viewList
                        select new EdOptionEntity()
                        {
                            label = item.SelectItemText,
                            value = item.SelectItemValue
                        }
                    ).ToList();
        }




    }
}
