using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Repositories
{
    public class StockTransferOrderLogRepository : EFCoreRepository<StockTransferOrderLog>
    {
        private readonly IMapper m_Mapper;
        private readonly LogDbContext m_LogDbContext;

        public StockTransferOrderLogRepository(IMapper mapper, LogDbContext _logDbContext) : base(_logDbContext)
        {
            m_Mapper = mapper;
            m_LogDbContext = _logDbContext;
        }







        public async Task<StockTransferOrder> AddEntityAsync(StockTransferOrder _info)
        {
            var inserting = m_Mapper.Map<StockTransferOrderLog>(_info);
            inserting.LogTypeNo = LogTypeEnum.Add;

            var inserted = await base.AddEntityAsync(inserting);

            await m_LogDbContext.SaveChangesAsync();
            return m_Mapper.Map<StockTransferOrder>(inserted);
        }







        public async Task<StockTransferOrderLog?> UpdateEntityAsync(StockTransferOrder _info, LogTypeEnum _logTypeNo)
        {
            var updating = await
                m_LogDbContext
                .StockTransferOrderLogs
                .Where(c => c.LogNo == _info.LogNo)
                .FirstOrDefaultAsync();

            if (updating == null)
                return null;


            updating.MergeFrom(_info, _logTypeNo);
            m_LogDbContext.Entry(updating).State = EntityState.Modified;
            await m_LogDbContext.SaveChangesAsync();

            return updating;
        }




    }
}
