using SBRPData.Models;

namespace SBRPWebPsi.ViewModels.common
{
    public class PersonViewModel : Person
    {

        // 用於Partial Page 中PersonContactPhones的子元素id制式名稱
        public readonly string HtmlDv_PCA_Container = "dvPtPCA_Container";
        public readonly string HtmlDv_PCA_ChildRow_PrefixName = "dvPtPCA_ChildRow_";

        public readonly string HtmlDv_PCE_Container = "dvPtPCE_Container";
        public readonly string HtmlDv_PCE_ChildRow_PrefixName = "dvPtPCE_ChildRow_";

        public readonly string HtmlDv_PCP_Container = "dvPtPCP_Container";
        public readonly string HtmlDv_PCP_ChildRow_PrefixName = "dvPtPCP_ChildRow_";

        
        public List<PersonContactAddressViewModel> PersonContactAddresses { get; set; }

        public List<PersonContactEmailViewModel> PersonContactEmails { get; set; }

        public List<PersonContactPhoneViewModel> PersonContactPhones { get; set; }
    }
}
