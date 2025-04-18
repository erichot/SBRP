using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Repositories
{
    public class PersonRepository : EFCoreRepository<Person>
    {
        private readonly CommonDbContext m_CommonDbContext;
        public PersonRepository(CommonDbContext commonDbContext) : base(commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
        }





        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
        }




    }
}
