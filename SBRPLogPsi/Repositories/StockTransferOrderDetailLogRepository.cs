using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Repositories
{
    public class StockTransferOrderDetailLogRepository:EFCoreRepository<StockTransferOrderDetailLog>
    {
        private readonly IMapper m_Mapper;
        private readonly LogDbContext m_LogDbContext;

        public StockTransferOrderDetailLogRepository(IMapper mapper, LogDbContext _logDbContext) : base(_logDbContext)
        {
            m_Mapper = mapper;
            m_LogDbContext = _logDbContext;
        }




        public async Task<List<StockTransferOrderDetail>> GetDetailListAsync(int _logNo)
        {
            var list = await
                    m_LogDbContext
                        .StockTransferOrderDetailLogs
                        .AsNoTracking()
                        .Where(x => x.LogNo == _logNo)
                        .ToListAsync();
            
            if (list == null || list.Any() == false) return new List<StockTransferOrderDetail>();
            return m_Mapper.Map<List<StockTransferOrderDetail>>(list);
        }







        public async Task<StockTransferOrderDetail> AddEntityAsync(StockTransferOrderDetail _info)
        {
            var inserted = await base.AddEntityAsync(
                m_Mapper.Map<StockTransferOrderDetailLog>(_info)
                );

            await m_LogDbContext.SaveChangesAsync();
            return m_Mapper.Map<StockTransferOrderDetail>(inserted);
        }






    }
}
