using Azure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class BaseWebPageSIGRepository:EFCoreRepository<BaseWebPageSIG>
    {
        private PsiDbContext m_PsiDbContext;

        public BaseWebPageSIGRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }


        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }



        public string GetPageTitle(string _pageId)
        {

            var pageInfo = m_PsiDbContext
                .BaseWebPageSIGs
                .Include(f => f.BaseWebPageTemplate)
                .Include(f => f.ParentBaseWebPageSIG)

                .Include(f => f.MenuitemSIG)
                    .ThenInclude(ff => ff.Menuitem)

                .Include(f => f.ParentBaseWebPageSIG)
                    .ThenInclude(ff => ff.MenuitemSIG)
                        .ThenInclude(fff => fff.Menuitem)
                .Include(f => f.ParentBaseWebPageSIG)
                    .ThenInclude(ff => ff.BaseWebPageTemplate)

                .AsNoTracking()
                .Where(c => 
                    c.PageId == _pageId
                    && (m_SIGNo.IsNullOrDefault() == true || c.SIGNo == m_SIGNo)
                    )
                .FirstOrDefault();
            
            return ExtractPageTitle(pageInfo);
        }


        public async Task<string> GetPageTitleAsync(string _pageId)
        {
            var pageInfo = await m_PsiDbContext
                .BaseWebPageSIGs
                .Include(f => f.BaseWebPageTemplate)                              
                .Include(f => f.MenuitemSIG)
                    .ThenInclude(ff => ff.Menuitem)

                .Include(f => f.ParentBaseWebPageSIG)
                    .ThenInclude(ff => ff.MenuitemSIG)
                        .ThenInclude(fff => fff.Menuitem)
                .Include(f => f.ParentBaseWebPageSIG)
                    .ThenInclude(ff => ff.BaseWebPageTemplate)

                .AsNoTracking()
                .Where(c =>
                    c.PageId == _pageId
                    && (m_SIGNo.IsNullOrDefault() == true || c.SIGNo == m_SIGNo)
                    )
                .FirstOrDefaultAsync();

            return ExtractPageTitle(pageInfo);
        }








        private string ExtractPageTitle(BaseWebPageSIG _pageInfo)
        {
            if (_pageInfo == null)
                return string.Empty;

            // 1. BaseWebPageSIG.PageTitle优先
            if (string.IsNullOrEmpty(_pageInfo.PageTitle) == false)
            {
                return _pageInfo.PageTitle;
            }


            // 2. BaseWebPageTemplate.PageTitle次之
            if (string.IsNullOrEmpty(_pageInfo.BaseWebPageTemplate?.PageTitle) == false)
            {
                return _pageInfo.BaseWebPageTemplate.PageTitle;
            }

            if (_pageInfo.MenuitemSIG != null)
            {
                var menuitemSIG = _pageInfo.MenuitemSIG;
                // 3. MenuitemSIG.NodeName再次之
                if (string.IsNullOrEmpty(menuitemSIG.NodeName) == false)
                {
                    return menuitemSIG.NodeName;
                }

                // 4. MenuitemSIG.Menuitem.NodeName再次之
                if (string.IsNullOrEmpty(menuitemSIG.Menuitem?.NodeName) == false)
                {
                    return menuitemSIG.Menuitem.NodeName;
                }
            }


            if (_pageInfo.ParentBaseWebPageSIG != null)
            {
                return ExtractPageTitle(_pageInfo.ParentBaseWebPageSIG);
            }

            return string.Empty;
        }










    }
}
