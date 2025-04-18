using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Services
{
    public class PersonService
    {
        private readonly CommonDbContext m_CommonDbContext;

        private readonly PersonRepository m_PersonRepository;
        private readonly PersonContactPhoneRepository m_PersonContactPhoneRepository;

        public PersonService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_PersonRepository = new PersonRepository(commonDbContext);
            m_PersonContactPhoneRepository = new PersonContactPhoneRepository(commonDbContext);
        }




        private byte m_SIGNo;
        public void SetSIG(byte _sIGNo)
        {
            m_SIGNo = _sIGNo;
            m_PersonRepository.SetSIG(_sIGNo);
        }







        public Person AddNewDefault()
        {
            var personContactAddresses = new List<PersonContactAddress>() { new PersonContactAddress() };
            var personContactEmails = new List<PersonContactEmail>() { new PersonContactEmail() };
            var personContactPhones = new List<PersonContactPhone>() { new PersonContactPhone() };

            var result = new Person()
            { 
                PersonContactAddresses = personContactAddresses,
                PersonContactEmails = personContactEmails,
                PersonContactPhones = personContactPhones
            };

            return result;
        }








    


    }
}
