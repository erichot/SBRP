using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Models
{
    public class GeneralModel
    {

        

    }








    // rmshq 【可銷表】樞紐分析交叉格式
    public class PSPTableRow
    {
        public int RowNo { get; set; }

        public string ProductID { get; set; }

        public IDictionary<short,PSPStoreCol> ColValues { get; set; }

        public Queue<string> StoreNames { get; set; }

        public Queue<int> StockQtys { get; set; }

        public Queue<int> SaleQtys { get; set; }
    }



    public class PSPStoreCol
    {
        public short OrdreNo { get; set; }  

        public string StoreName { get; set; }

        public string StoreID { get; set; }

        public int StoreQty { get; set; }

    }


}
