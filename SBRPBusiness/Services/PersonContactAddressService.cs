using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class PersonContactAddressService
    {
        private readonly CommonDbContext m_CommonDbContext;

        private readonly PersonContactAddressRepository m_PersonContactAddressRepository;

        public PersonContactAddressService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_PersonContactAddressRepository = new PersonContactAddressRepository(commonDbContext);
        }



















        public byte GetNewItemNo(int _personNo) => (byte)(m_PersonContactAddressRepository.GetMaxItemNo(_personNo) + 1);






    }
}
