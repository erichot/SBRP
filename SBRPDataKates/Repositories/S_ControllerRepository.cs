using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataKates.Repositories
{
    public class S_ControllerRepository: EFCoreRepository<S_Controller>
    {
        private readonly KatesDbContext m_KatesDbContext;

        public S_ControllerRepository(KatesDbContext katesDbContext):base(katesDbContext)
        {
            m_KatesDbContext = katesDbContext;
        }











        public S_Controller? GetEntity( bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetQuery(_enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<S_Controller?> GetEntityAsync(bool _enableTracking = false, bool _includeDetails = true)
        {
           
            return await GetQuery(_enableTracking, _includeDetails)
                .FirstOrDefaultAsync();
        }

       
        












        public IQueryable<S_Controller> GetQuery( bool _enableTracking = false, bool _includeDetails = false)
        {
            

            IQueryable<S_Controller> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_KatesDbContext
                    .S_Controllers;
            }
            else
            {
                basedQuery = m_KatesDbContext
                    .S_Controllers;
            }



            var result = basedQuery;


            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }














    }
}
