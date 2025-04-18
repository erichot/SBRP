using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPLogPsi.Repositories
{
    public class SaleOrderDetailLogRepository:EFCoreRepository<SaleOrderDetailLog>
    {
        private readonly IMapper m_Mapper;
        private readonly LogDbContext m_LogDbContext;

        public SaleOrderDetailLogRepository(IMapper mapper, LogDbContext _logDbContext) : base(_logDbContext)
        {
            m_Mapper = mapper;
            m_LogDbContext = _logDbContext;
        }




        public async Task<List<SaleOrderDetail>> GetDetailListAsync(int _logNo)
        {
            var list = await
                    m_LogDbContext
                        .SaleOrderDetailLogs
                        .AsNoTracking()
                        .Where(x => x.LogNo == _logNo)
                        .ToListAsync();
            
            if (list == null || list.Any() == false) return new List<SaleOrderDetail>();
            return m_Mapper.Map<List<SaleOrderDetail>>(list);
        }







        public async Task<SaleOrderDetail> AddEntityAsync(SaleOrderDetail _info)
        {
            var inserted = await base.AddEntityAsync(
                m_Mapper.Map<SaleOrderDetailLog>(_info)
                );

            await m_LogDbContext.SaveChangesAsync();
            return m_Mapper.Map<SaleOrderDetail>(inserted);
        }


        public async Task<SaleOrderDetail> UpdateEntityAsync(SaleOrderDetail _info)
        {
            var LogNo = _info.LogNo;
            var ItemNo = _info.ItemNo;

            var updating = await m_LogDbContext.SaleOrderDetailLogs
                .Where(c => 
                    c.LogNo == LogNo 
                    && 
                    c.ItemNo == ItemNo)
                .FirstOrDefaultAsync();

            if (updating == null)
                return null;


            updating.MergeFrom(_info);
            m_LogDbContext.Entry(updating).State = EntityState.Modified;
            await m_LogDbContext.SaveChangesAsync();
            return m_Mapper.Map<SaleOrderDetail>(updating);
        }



        public async Task<int> DeleteEntityAsync(int _logNo, short _itemNo)
        {
            //var deleting = await m_LogDbContext.SaleOrderDetailLogs
            //    .Where(c => c.LogNo == _logNo && c.ItemNo == _itemNo)
            //    .FirstOrDefaultAsync();

            //if (deleting == null) return default;
            // =========================================================
            var removeList = await
                m_LogDbContext.SaleOrderDetailLogs
                .Where(c => c.LogNo == _logNo && c.ItemNo >= _itemNo)
                .ToListAsync();

            if (removeList == null || removeList.Any() == false) return 0;
            m_LogDbContext.SaleOrderDetailLogs
                .RemoveRange(removeList);

            // =========================================================
            // Recreate the same data but with new ItemNo
            if (removeList.Any() && removeList.Count > 1)
            {
                var newList = removeList
                    .Where(c => c.ItemNo != _itemNo)
                    .Select(x => m_Mapper.Map<SaleOrderDetailLog>(x))
                    .ToList();
                newList.ForEach(r => r.ItemNo = (short)(r.ItemNo - 1));
                
                m_LogDbContext.SaleOrderDetailLogs
                    .AddRange(newList);
            }
            
            await m_LogDbContext.SaveChangesAsync();

            return 1;
        }






    }
}
