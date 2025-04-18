using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPData.Repositories
{
    public class PersonContactEmailRepository : EFCoreRepository<PersonContactEmail>
    {
        private readonly CommonDbContext m_CommonDbContext;
        public PersonContactEmailRepository(CommonDbContext commonDbContext) : base(commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
        }





        public byte GetMaxItemNo(int _personNo)
        {
            return m_CommonDbContext
                .PersonContactEmails
                .IgnoreQueryFilters()
                .Where(x => x.PersonNo == _personNo)
                .DefaultIfEmpty()
                .Max(x => (byte?)x.ItemNo ?? default(byte));
        }




    }
}
