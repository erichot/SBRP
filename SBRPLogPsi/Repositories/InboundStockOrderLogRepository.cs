using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Repositories
{
    public class InboundStockOrderLogRepository : EFCoreRepository<InboundStockOrderLog>
    {
        private readonly IMapper m_Mapper;
        private readonly LogDbContext m_LogDbContext;

        public InboundStockOrderLogRepository(IMapper mapper, LogDbContext _logDbContext) : base(_logDbContext)
        {
            m_Mapper = mapper;
            m_LogDbContext = _logDbContext;
        }







        public async Task<InboundStockOrder> AddEntityAsync(InboundStockOrder _info, LogTypeEnum _logTypeNo)
        {
            var inserting = m_Mapper.Map<InboundStockOrderLog>(_info);
            inserting.LogTypeNo = _logTypeNo;

            var inserted = await base.AddEntityAsync(inserting);

            await m_LogDbContext.SaveChangesAsync();
            return m_Mapper.Map<InboundStockOrder>(inserted);
        }







        public async Task<InboundStockOrderLog?> UpdateEntityAsync(InboundStockOrder _info, LogTypeEnum _logTypeNo)
        {
            var updating = await
                m_LogDbContext
                .InboundStockOrderLogs
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
