using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataKates.Repositories
{
    public class S_SystemSettingRepository: EFCoreRepository<S_SystemSetting>
    {
        private readonly KatesDbContext m_KatesDbContext;

        public S_SystemSettingRepository(KatesDbContext katesDbContext):base(katesDbContext)
        {
            m_KatesDbContext = katesDbContext;
        }











        public S_SystemSetting GetEntity(byte _iD, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new S_SystemSetting() { ID = _iD }, _enableTracking, _includeDetails);
        }
        public async Task<S_SystemSetting> GetEntityAsync(byte _iD, bool _enableTracking = false, bool _includeDetails = true)
        {
           
            return await GetEntityAsync(
                new S_SystemSetting() { ID = _iD }, _enableTracking, _includeDetails);
        }

        public S_SystemSetting GetEntity(S_SystemSetting _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefault();
        }
        public async Task<S_SystemSetting> GetEntityAsync(S_SystemSetting _filterInfo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_filterInfo, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }

        












        public IQueryable<S_SystemSetting> GetQuery(S_SystemSetting? _filterInfo, bool _enableTracking = false, bool _includeDetails = false)
        {
            var ID = _filterInfo?.ID ?? default(byte);
            

            IQueryable<S_SystemSetting> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_KatesDbContext
                    .S_SystemSettings;
            }
            else
            {
                basedQuery = m_KatesDbContext
                    .S_SystemSettings;
            }



            var result = basedQuery
                .Where(c =>
                    (c.ID == ID)                    
                )
                ;


            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }














    }
}
