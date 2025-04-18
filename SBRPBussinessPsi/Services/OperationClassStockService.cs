using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SBRPBussinessPsi.Services
{
    public class OperationClassStockService : ISystemIsolationGroupInterface
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly CompanyService m_CompanyService;

        private readonly PsiDbContext m_PsiDbContext;
        private readonly StockRepository m_StockRepository;
        private readonly OperationClassStockRepository m_OperationClassStockRepository;

        public OperationClassStockService(PsiDbContext psiDbContext)
        {
            m_PsiDbContext = psiDbContext;
            m_StockRepository = new StockRepository(psiDbContext);
            m_OperationClassStockRepository = new OperationClassStockRepository(psiDbContext);
        }



        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_StockRepository.SetSIG(_sIGNo);
            m_OperationClassStockRepository.SetSIG(_sIGNo);
        }


        
















        #region "Basic based Procedure"
        public OperationClassStock? GetEntity(OperationClassEnum _operationClassNo, short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_storeNo.IsNullOrDefault()) return null;
            return m_OperationClassStockRepository.GetEntity(_operationClassNo, _storeNo, _enableTracking, _includeDetails);
        }
        public async Task<OperationClassStock?> GetEntityAsync(OperationClassEnum _operationClassNo, short _storeNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            if (_storeNo.IsNullOrDefault()) return null;
            return await m_OperationClassStockRepository.GetEntityAsync(_operationClassNo, _storeNo, _enableTracking, _includeDetails);
        } 
        public OperationClassStock? GetEntity(OperationClassStock _info, bool _enableTracking, bool _includeDetails = true)
        {
            return m_OperationClassStockRepository.GetEntity(_info, _enableTracking, _includeDetails);
        }
        public async Task<OperationClassStock?> GetEntityAsync(OperationClassStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_OperationClassStockRepository.GetEntityAsync(_info, _enableTracking, _includeDetails);
        }
        public List<OperationClassStock> GetList(OperationClassStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_OperationClassStockRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToList();
        }
        public async Task<List<OperationClassStock>> GetListAsync(OperationClassStock _info, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await m_OperationClassStockRepository
                 .GetQuery(_info, _enableTracking, _includeDetails)
                 .ToListAsync();
        }
        public IQueryable<OperationClassStock> GetQuery(OperationClassStock? _info, bool _enableTracking = false, bool _includeDetails = false)
        {
            return m_OperationClassStockRepository.GetQuery(_info, _enableTracking, _includeDetails);
        }
        #endregion




        public async Task<List<OperationClassStock>> GetListAsync(short _stockNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return await 
                GetListAsync(
                    new OperationClassStock() { StockNo = _stockNo }
                    , _enableTracking, _includeDetails);
        }




        public static List<OperationClassStock> AddNewListDefault(short _stockNo)
        {
            var result = new List<OperationClassStock>();
            foreach (OperationClassEnum operationClassNo in Enum.GetValues(typeof(OperationClassEnum)))
            {
                var item = new OperationClassStock()
                    {
                        StockNo = _stockNo,
                        OperationClassNo = operationClassNo
                    };

                switch (operationClassNo)
                {
                    case OperationClassEnum.InboundStock:
                        item.DisallowFromStock_NewDefault = true;
                        break;

                    case OperationClassEnum.Sale:
                        item.DisallowToStock_NewDefault = true;
                        item.AllowFromThisStock = true;
                        break;

                    case OperationClassEnum.StockTransfer:
                        item.AllowFromThisStock = true;
                        item.AllowToThisStock = true;
                        break;


                    default:
                        item = null;
                        break;
                }

                if (item != null)
                    result.Add(item);
            }
            return result;
        }











    }
}
