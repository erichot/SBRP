using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBussinessPsi.Services
{
    public class MenuitemService
    {
        private readonly PsiDbContext m_PsiDbContext;
        private readonly MenuitemRepository m_MenuitemRepository;


        public MenuitemService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_MenuitemRepository = new MenuitemRepository(psiDbContext);
        }




        //public async Task<List<Menuitem>> GetMenuitemByUserWithPermissionAsync(byte _sIGNo, short _userNo)
        //{
        //    return await
        //       m_MenuitemRepository.GetMenuitemByUserWithPermissionAsync(_sIGNo, _userNo);
        //}
        public async Task<List<Menuitem>> GetMenuitemWithPGCDByUserWithPermissionAsync(byte _sIGNo, short _userNo)
        {
            var result = await
               m_MenuitemRepository.GetMenuitemByUserWithPermissionAsync(_sIGNo, _userNo);

            var pgcd = await
                m_MenuitemRepository.GET_Menuitem_FromProductGeneralCategoryDefinition(_sIGNo, _userNo);
            if (pgcd.Any())
            {
                result.AddRange(pgcd);
            }

            return result;
        }





    }
}
