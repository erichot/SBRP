using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SBRPDataKates.Repositories;
using SBRPDataKates.Models;


namespace SBRPBusinessTms.Services.KATES
{
    public class TransactionService
    {
        private CF_TransactionImportHeadRepository m_TransactionImportHeadRepository;
        private OR_TransactionRepository m_OR_TransactionRepository;

        public TransactionService(CF_TransactionImportHeadRepository transactionImportHeadRepository, OR_TransactionRepository oR_TransactionRepository)
        {
            m_TransactionImportHeadRepository = transactionImportHeadRepository;
            m_OR_TransactionRepository = oR_TransactionRepository;
        }






        public async Task<CF_TransactionImportHead> AddNewEntityAsync(string _fileName, int _createdBy, List<CF_TransactionImportDetail> _details)
        {
            var inserting = new CF_TransactionImportHead()
            {
                CF_TransactionImportDetails = _details,
                TotalRecord = Convert.ToInt16(_details.Count()),
                FileName = _fileName,
                CreatedBy = _createdBy
            };

            var inserted = await m_TransactionImportHeadRepository.AddEntityAsync(inserting);
            await m_TransactionImportHeadRepository.SaveDbChangesAsync();

            return inserted;
        }







        public async Task<CF_TransactionImportHead> UploadWithDetailAsync(CF_TransactionImportHead _importHeadInfo)
        {
            m_TransactionImportHeadRepository.UpdateEntity(_importHeadInfo);

            await m_TransactionImportHeadRepository.SaveDbChangesAsync();

            return _importHeadInfo;
        }









        public async Task<OR_Transaction> AddEntityAsync(OR_Transaction _info)
        {
            var inserted = await m_OR_TransactionRepository.AddEntityAsync(_info);
            await m_OR_TransactionRepository.SaveDbChangesAsync();
            return inserted;
        }





        public async Task<OR_Transaction?> GetLastEntityAsync(bool _enableTracking = false, bool _includeDetails = false)
        {
            return await m_OR_TransactionRepository.GetLastEntityAsync(_enableTracking, _includeDetails);
        }





    }
}
