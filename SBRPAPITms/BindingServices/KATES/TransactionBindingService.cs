
using SBRPBusinessTms.Services.KATES;
using SBRPDataKates.Models;
using SBRPDataKates.Repositories;
using System.Text.RegularExpressions;

namespace SBRPAPITms.BindingServices.KATES
{
    public class TransactionBindingService
    {
        private IMapper m_Mapper;
        private TransactionService m_TransactionService;

        public TransactionBindingService(IMapper mapper, TransactionService TransactionService)
        {
            m_Mapper = mapper;
            m_TransactionService = TransactionService;
        }




     


        public async Task<CF_TransactionImportHead> AddNewEntityAsync(string _fileName, int _createdBy, List<CF_TransactionImportDetail> _details)
        {
            return await m_TransactionService.AddNewEntityAsync(_fileName, _createdBy, _details);
        }









        public async Task<CF_TransactionImportHead> UploadWithDetailAsync(CF_TransactionImportHead _importHeadInfo)
        {
                       

            return await m_TransactionService.UploadWithDetailAsync(_importHeadInfo);
        }












        public async Task<OR_Transaction> AddEntityAsync(OR_Transaction _info)
        {
            return await m_TransactionService.AddEntityAsync(_info);
        }




        public async Task<OR_Transaction?> GetLastEntityAsync(bool _enableTracking = false, bool _includeDetails = false)
        {
            return await m_TransactionService.GetLastEntityAsync(_enableTracking, _includeDetails);
        }



    }
}
