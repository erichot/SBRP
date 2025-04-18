namespace SBRPWebPsi.Extensions
{
    public static class ViewListExtension
    {
        public static List<SelectListItem> ToSelectListItem<T>(this IList<T> _viewList) where T : IBasedViewSelectItemInterface
        {
            if (_viewList == null)
                return new List<SelectListItem>();



            return (
                        from item in _viewList
                        select item.SelectItemInfo
                    ).ToList();
        }



        public static List<SelectListItem> ToSelectListItemCode<T>(this IList<T> _viewList) where T : IBasedViewSelectItemInterface, IBasedViewSelectItemCodeInterface
        {
            if (_viewList == null)
                return new List<SelectListItem>();



            return (
                        from item in _viewList
                        select item.SelectItemCodeInfo
                    ).ToList();
        }




        public static List<SelectListItem> ToSelectListItemName<T>(this IList<T> _viewList) where T : IBasedViewSelectItemInterface, IBasedViewSelectItemCodeInterface, IBasedViewSelectItemNameInterface
        {
            if (_viewList == null)
                return new List<SelectListItem>();



            return (
                        from item in _viewList
                        select item.SelectItemNameInfo
                    ).ToList();
        }




        public static IEnumerable<SelectItemEntity> ToSelectItemValueText<T>(this IList<T> _viewList) where T : IBasedViewSelectItemValueTextInterface
        {
            if (_viewList == null)
                return Enumerable.Empty<SelectItemEntity>();



            return (
                        from item in _viewList
                        select item.SelectItemValueTextInfo
                    ).AsEnumerable();
        }


    }
}
