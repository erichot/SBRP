using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPDataPsi.Repositories
{
    public class SaleOrderDetailRepository : EFCoreRepository<SaleOrderDetail>
    {
        private readonly PsiDbContext m_PsiDbContext;
        public SaleOrderDetailRepository(PsiDbContext psiDbContext) : base(psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
        }

     

















        #region "Basic based Procedure"
        public SaleOrderDetail? GetEntity(int _orderNo, short _itemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return GetEntity(
                new SaleOrderDetail() { OrderNo =  _orderNo, ItemNo = _itemNo }, _enableTracking, _includeDetails);
        }
        public async Task<SaleOrderDetail?> GetEntityAsync(int _orderNo, short _itemNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetEntityAsync(
                    new SaleOrderDetail() { OrderNo =  _orderNo, ItemNo = _itemNo }, _enableTracking, _includeDetails);
        }
      
        public SaleOrderDetail? GetEntity(SaleOrderDetail _info, bool _enableTracking, bool _includeDetails = true)
        {
            return GetQuery(_info, _enableTracking, _includeDetails)
                .FirstOrDefault();
        }
        public async Task<SaleOrderDetail?> GetEntityAsync(SaleOrderDetail _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await
                GetQuery(_info, _enableTracking, _includeDetails)
                    .FirstOrDefaultAsync();
        }


        public IQueryable<SaleOrderDetail?> GetQuery(SaleOrderDetail? _info = null, bool _enableTracking = false, bool _includeDetails = false)
        {

            var OrderNo =  _info?.OrderNo;
            var ItemNo = _info?.ItemNo;


            IQueryable<SaleOrderDetail?> basedQuery;
            if (_includeDetails)
            {
                basedQuery = m_PsiDbContext
                    .SaleOrderDetails
                    .Include(f => f.Product)
                    ;
            }
            else
            {
                basedQuery = m_PsiDbContext
                    .SaleOrderDetails;
            }



            var result = basedQuery
                .Where(c => 
                    (OrderNo.IsNullOrDefault() || c.OrderNo == OrderNo)
                    &&
                    (ItemNo.IsNullOrDefault() || c.ItemNo == ItemNo)
                );

            if (_enableTracking == false) return result.AsNoTracking();

            return result;
        }

        #endregion






    }
}
