using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataRmshq.Services
{
    public class StoreService
    {
        public readonly BF_StoreRepository m_BF_StoreRepository;
        public readonly S_SystemCustomerAndStoreRepository m_S_SystemCustomerAndStoreRepository;

        public StoreService(BF_StoreRepository bF_StoreRepository, S_SystemCustomerAndStoreRepository systemCustomerAndStoreRepository)
        {
            m_BF_StoreRepository = bF_StoreRepository;
            m_S_SystemCustomerAndStoreRepository = systemCustomerAndStoreRepository;
        }

        public async Task<List<BF_Store>> GetListAsync(BF_Store? _filter)
        {
            return await m_BF_StoreRepository
                .GetQuery(_filter)
                .ToListAsync();
        }


        public async Task<List<BF_Store>> GetListWithPrimaryAsync()
        {
            var result = await (
                from store in m_BF_StoreRepository.GetQuery(null)
                join sc in m_S_SystemCustomerAndStoreRepository.GetQuery(null)
                    on store.StoreID equals sc.StoreID
                select store
                )
                .ToListAsync();

            return result;
        }





    }
}
