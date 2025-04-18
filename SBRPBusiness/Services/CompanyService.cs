using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class CompanyService
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly CompanyContactPersonService m_CompanyContactPersonService;



        public CompanyService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;

            m_CompanyContactPersonService = new CompanyContactPersonService(commonDbContext);
        }








        public Company AddNewDefault(byte _sIGNo, short _createdPerson)
        {
            var entity = new Company();
            entity.CompanyContactPersons = m_CompanyContactPersonService.AddNewDefaultList(_sIGNo, _createdPerson);
            return entity;
        }






    }
}
