using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;



namespace SBRPWebPsi.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IEnumerable<SelectListItem> GetEnumSelectListWithDefaultValue<TEnum>(this IHtmlHelper htmlHelper, TEnum defaultValue)
            where TEnum : struct
        {
            var selectList = htmlHelper.GetEnumSelectList<TEnum>().ToList();
            //selectList.Single(x => x.Value == $"{(byte)(object)defaultValue}").Selected = true;
            var selectedItem = selectList
                .FirstOrDefault(x => x.Value == $"{(byte)(object)defaultValue}");

            if (selectedItem != null) selectedItem.Selected = true;
            return selectList;
        }





        public static IEnumerable<SelectListItem> GetEnumSelectListWhereClause<TEnum>(this IHtmlHelper htmlHelper, Func<SelectListItem, bool> _filterExpression)
            where TEnum : struct
        {
            return  htmlHelper.GetEnumSelectList<TEnum>().Where(_filterExpression).ToList();
        }




        // 2022/11/20 not working
        public static string IsDisabled(this HtmlHelper helper, bool isDisabled)
        {
            // 是否傳出 disabled = 'disabled' 字串
            return isDisabled ? "disabled = 'disabled'" : string.Empty;
        }








        //public static MvcHtmlString SanitizedRaw(this HtmlHelper html, string rawHtml)
        //{
        //    var sanitizer = new HtmlSanitizer();
        //    MvcHtmlString.Create(sanitizer.Sanitize(rawHtml));
        //}
            


    }
}

