using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class CompanyContactPersonService
    {
        private readonly CommonDbContext m_CommonDbContext;

        private readonly CompanyContactPersonRepository m_CompanyContactPersonRepository;

        public CompanyContactPersonService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_CompanyContactPersonRepository = new CompanyContactPersonRepository(commonDbContext);
        }












        public List<CompanyContactPerson> AddNewDefaultList(byte _sIGNo, short _createdPerson)
        {
            var result = new List<CompanyContactPerson>()
                { new CompanyContactPerson(1) , new CompanyContactPerson(2) };

            return result;
        }








        public short GetNewContractItemNo(int _companyNo) => (short)(m_CompanyContactPersonRepository.GetMaxItemNo(_companyNo) + 1);






    }
}
