using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SBRPDataKates.Repositories;
using SBRPDataKates.Models;


namespace SBRPBusinessTms.Services.KATES
{
    public class UserService
    {
        private CF_UserImportHeadRepository m_UserImportHeadRepository;

        public UserService(CF_UserImportHeadRepository userImportHeadRepository)
        {
            m_UserImportHeadRepository = userImportHeadRepository;
        }




        public async Task<CF_UserImportHead> AddNewEntityAsync(string _fileName, int _createdBy)
        {
            var inserting = new CF_UserImportHead()
            {
                FileName = _fileName,
                CreatedBy = _createdBy
            };

            var inserted = await m_UserImportHeadRepository.AddEntityAsync(inserting);
            await m_UserImportHeadRepository.SaveDbChangesAsync();

            return inserted;
        }







        public async Task<CF_UserImportHead> UploadWithDetailAsync(CF_UserImportHead _importHeadInfo)
        {
            m_UserImportHeadRepository.UpdateEntity(_importHeadInfo);

            await m_UserImportHeadRepository.SaveDbChangesAsync();

            return _importHeadInfo;
        }









    }
}
