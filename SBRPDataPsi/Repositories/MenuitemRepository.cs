using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class MenuitemRepository : EFCoreRepository<Menuitem>
    {
        private readonly PsiDbContext m_PsiDbContext;

        public MenuitemRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }





        public async Task<List<Menuitem>> GetMenuitemByUserWithPermissionAsync(byte _sIGNo, short _userNo)
        {
            return await
                m_PsiDbContext
                    .udtfGET_Menuitem_ByUserWithPermission(_sIGNo, _userNo)
                    .AsNoTracking()
                    .ToListAsync();
        }



        public async Task<List<Menuitem>> GET_Menuitem_FromProductGeneralCategoryDefinition(byte _sIGNo, short _userNo)
        {
            return await
                m_PsiDbContext
                    .udtfGET_Menuitem_FromProductGeneralCategoryDefinition(_sIGNo, _userNo)
                    .AsNoTracking()
                    .ToListAsync();
        }




    }
}
