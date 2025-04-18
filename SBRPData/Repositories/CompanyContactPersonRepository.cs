using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Repositories
{
    public class CompanyContactPersonRepository : EFCoreRepository<CompanyContactPerson>
    {
        private readonly CommonDbContext m_CommonDbContext;
        public CompanyContactPersonRepository(CommonDbContext commonDbContext) : base(commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
        }





        public short GetMaxItemNo(int _companyNo)
        {
            return m_CommonDbContext
                .CompanyContactPersons
                .IgnoreQueryFilters()
                .Where(x => x.CompanyNo == _companyNo)
                .DefaultIfEmpty()
                .Max(x => (short?)x.ContactItemNo ?? default(short));
        }




    }
}
