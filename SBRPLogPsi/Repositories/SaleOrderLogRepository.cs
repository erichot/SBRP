using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Repositories
{
    public class SaleOrderLogRepository : EFCoreRepository<SaleOrderLog>
    {
        private readonly IMapper m_Mapper;
        private readonly LogDbContext m_LogDbContext;

        public SaleOrderLogRepository(IMapper mapper, LogDbContext _logDbContext) : base(_logDbContext)
        {
            m_Mapper = mapper;
            m_LogDbContext = _logDbContext;
        }







        public async Task<SaleOrder> AddEntityAsync(SaleOrder _info, LogTypeEnum _logTypeNo)
        {
            var inserting = m_Mapper.Map<SaleOrderLog>(_info);
            inserting.LogTypeNo = _logTypeNo;

            var inserted = await base.AddEntityAsync(inserting);

            await m_LogDbContext.SaveChangesAsync();
            return m_Mapper.Map<SaleOrder>(inserted);
        }







        public async Task<SaleOrderLog?> UpdateEntityAsync(SaleOrder _info, LogTypeEnum _logTypeNo)
        {
            var updating = await
                m_LogDbContext
                .SaleOrderLogs
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
