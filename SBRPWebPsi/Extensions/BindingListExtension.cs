namespace SBRPWebPsi.Extensions
{
    public static class BindingListExtension
    {
        public static List<SelectItemEntity> ToSelectItemList<T>(this IList<T> _viewList) where T : IBindingDataInterface
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


        public static SelectList ToSelectList<T>(this IList<T> _viewList) where T : IBindingDataInterface
        {
            if (_viewList == null)
                return null;

            return new SelectList(_viewList, "SelectItemValue", "SelectItemText");
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









        public static List<KdOptionEntity> ToKdOptionList<T>(this IList<T> _viewList) where T : IBindingDataInterface
        {
            if (_viewList == null)
                return new List<KdOptionEntity>();


            return (
                        from item in _viewList
                        select new KdOptionEntity()
                        {
                            text = item.SelectItemText,
                            value = item.SelectItemValue
                        }
                    ).ToList();
        }



    }
}
