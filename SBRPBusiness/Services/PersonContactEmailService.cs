using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class PersonContactEmailService
    {
        private readonly CommonDbContext m_CommonDbContext;

        private readonly PersonContactEmailRepository m_PersonContactEmailRepository;

        public PersonContactEmailService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_PersonContactEmailRepository = new PersonContactEmailRepository(commonDbContext);
        }



















        public byte GetNewItemNo(int _personNo) => (byte)(m_PersonContactEmailRepository.GetMaxItemNo(_personNo) + 1);






    }
}
