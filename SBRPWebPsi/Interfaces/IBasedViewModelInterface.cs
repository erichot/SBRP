using Microsoft.AspNetCore.Mvc.Rendering;

namespace SBRPWebPsi.Interfaces
{
    public interface IBasedViewModelInterface
    {
        bool IsReadonly { get; set; }

        //FormEditModeEnum FormEditMode { get; set; }

        int LoginActionNo { get; set; }
    }


    // Value 主key為數值代碼（系統內碼）
    public interface IBasedViewSelectItemInterface
    {
        SelectListItem SelectItemInfo { get; }
    }

    // Value 主key為代碼（使用者定義英數字碼）
    public interface IBasedViewSelectItemCodeInterface
    {
        SelectListItem SelectItemCodeInfo { get; }
    }

    // Value 主key為Text
    public interface IBasedViewSelectItemNameInterface
    {
        SelectListItem SelectItemNameInfo { get; }
    }




    // JSON
    public interface IBasedViewSelectItemValueTextInterface
    {
        SelectItemEntity SelectItemValueTextInfo { get; }
    }



    // 
    public interface IBasedViewFormDataUserIdName
    {
        string CreatePersonId { get; set; }
        string EditPersonId { get; set; }
        string ApprovedPersonId { get; set; }

        string CreatePersonName { get; set; }
        string EditPersonName { get; set; }
        string ApprovedPersonName { get; set; }
    }
}
