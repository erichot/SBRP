using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class BaseWebPageService : ISystemIsolationGroupInterface
    {
        private readonly PsiDbContext m_PsiDbContext;
        private readonly BaseWebPageSIGRepository m_BaseWebPageSIGRepository;

        public BaseWebPageService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_BaseWebPageSIGRepository = new BaseWebPageSIGRepository(psiDbContext);
        }

        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_BaseWebPageSIGRepository.SetSIG(_sIGNo);
        }








        public string GetPageTitle(string _pageId)
        {
            return m_BaseWebPageSIGRepository.GetPageTitle(_pageId);
        }
        public async Task<string> GetPageTitleAsync(string _pageId)
        {
            return await m_BaseWebPageSIGRepository.GetPageTitleAsync( _pageId);
        }




    }
}
