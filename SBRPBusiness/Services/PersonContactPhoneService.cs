using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class PersonContactPhoneService
    {
        private readonly CommonDbContext m_CommonDbContext;

        private readonly PersonContactPhoneRepository m_PersonContactPhoneRepository;

        public PersonContactPhoneService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_PersonContactPhoneRepository = new PersonContactPhoneRepository(commonDbContext);
        }



















        public byte GetNewItemNo(int _personNo) => (byte)(m_PersonContactPhoneRepository.GetMaxItemNo(_personNo) + 1);






    }
}
