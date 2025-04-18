using SBRPDataPsi.Repositories;

namespace SBRPWebPsi.Services
{
    public class WebSystemService : ISystemIsolationGroupInterface
    {
        private readonly IWebHostEnvironment m_Environment;
        private readonly BaseWebPageService m_BaseWebPageService;


        public WebSystemService(IWebHostEnvironment environment, BaseWebPageService baseWebPageService)
        {
            m_Environment = environment;
            m_BaseWebPageService = baseWebPageService;
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_BaseWebPageService.SetSIG(_sIGNo);
        }





        public string GetPageTitle(string _pageId)
        {
            return m_BaseWebPageService.GetPageTitle(_pageId);
        }
        public string GetPageTitle(string _pageId, FormEditModeEnum _formEditModeEnum)
        {
            var subTitle = _formEditModeEnum.GetDisplayName();
            return m_BaseWebPageService.GetPageTitle(_pageId) + " " + subTitle;
        }

        public async Task<PageHeaderEntity> GetPageHeaderAsync(string _pageId)
        {
            return new PageHeaderEntity()
            {
                Title = await m_BaseWebPageService.GetPageTitleAsync(_pageId),
                PageId = _pageId
            };
        }
        public async Task<PageHeaderEntity> GetPageHeaderAsync(string _pageId, FormEditModeEnum _formEditModeEnum)
        {
            return new PageHeaderEntity()
            {
                Title = await m_BaseWebPageService.GetPageTitleAsync(_pageId),
                SubTitle = _formEditModeEnum.GetDisplayName(),
                PageId = _pageId
            };
        }



        public async Task<PageHeaderEntity> GetPageHeaderAsync(ProductGeneralCategoryDefinitionViewModel _pGCD, FormEditModeEnum _formEditModeEnum)
        {
            return new PageHeaderEntity()
            {
                Title = _pGCD?.PGCategoryName??string.Empty,
                SubTitle = _formEditModeEnum.GetDisplayName(),
                PageId = _pGCD?.PGCategoryId ?? string.Empty
            };
        }

    }
}
