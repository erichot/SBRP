namespace SBRPWebPsi.Models
{
    /// <summary>
    /// API System 的資料實體（設定值、常數）
    /// </summary>
    /// <remarks>
    /// API & WEB兩系統共用，且以WEB為主
    /// </remarks>
    public class ApiSystemModel
    {
    }



    public class ApiSystem
    {

    }




    public static class ApiStatusCode
    {
        // 403 Forbidden    Unauthorized request. The client does not have access rights to the content. Unlike 401, the client’s identity is known to the server
        public const int ForbidOnGeneralAccess = 403;


        // 404 Not Found    The server can not find the requested resource.
        public const int NoFoundOnGetProfile = 404;

        public const int MethodNotAllowed = 405;

        public const int NotAcceptable = 406;


        // Duplicated   The request could not be completed due to a conflict with the current state of the resource
        public const int Conflict = 409;


        // The 422 (Unprocessable Entity) status code means the server understands the content type of the request entity (hence a 415(Unsupported Media Type) status code is inappropriate), and the syntax of the request entity is correct (thus a 400 (Bad Request) status code is inappropriate) but was unable to process the contained instructions
        // validation errors
        public const int UnprocessableEntity = 422;


        public const int InternalServerError = 500;

    }







    public class ApiUrlPath
    {
        public const string BasicInfo_Supplier_SIL = "api/BasicInfo/Supplier/SIL/";


        public const string Members_Member_KDSI = "api/Members/Member/KDSI/";



        public const string Orders_InboundStock_Detail_DataTable = "api/Orders/InboundStock/Detail/DT/";
        public const string Orders_InboundStock_Detail_Editor = "api/Orders/InboundStock/Detail/ED/";
        public const string Orders_InboundStock_Detail_SingleInput = "api/Orders/InboundStock/Detail/SI/";


        public const string Orders_Sale_Detail_DataTable = "api/Orders/Sale/Detail/DT/";
        public const string Orders_Sale_Detail_Editor = "api/Orders/Sale/Detail/ED/";
        public const string Orders_Sale_Detail_SingleInput = "api/Orders/Sale/Detail/SI/";



        public const string Orders_StockTransfer_Detail_DataTable = "api/Orders/StockTransfer/Detail/DT/";
        public const string Orders_StockTransfer_Detail_Editor = "api/Orders/StockTransfer/Detail/ED/";
        public const string Orders_StockTransfer_Detail_SingleInput = "api/Orders/StockTransfer/Detail/SI/";


        public const string Products_Brief_ProductName = "api/Products/Product/Brief/ProductName/";
        public const string Products_Brief_ProductNameWithCost = "api/Products/Product/Brief/ProductNameWithCost/";
        public const string Products_GeneralCategoryItem_DataTable = "api/Products/GeneralCategoryItem/DT/";
        public const string Products_GeneralCategoryItem_Editor = "api/Products/GeneralCategoryItem/ED/";


        public const string Products_GeneralCategoryItem_SIL = "api/Products/GeneralCategoryItem/SIL/";


    }


}
