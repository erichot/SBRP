using SBRPDataRmshq.Models;

namespace SBRPWebPsi.ViewModels.Rmshq
{
    public class StoreViewModel:BF_Store, IBasedViewSelectItemInterface
    {

        private string m_StoreID;
        public string StoreID 
        {
            get { return m_StoreID.Trim(); }
            set { m_StoreID = value; }
        }



        public SelectListItem SelectItemInfo
        {
            get
            {
                return new SelectListItem
                {
                    Value = this.StoreID
                    ,
                    Text = this.StoreID + " " + this.StoreName
                };
            }
        }

    }
}
