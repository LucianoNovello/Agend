
using Entity;
using System.Collections.Generic;

namespace Business
{
    public interface IBusiness
    {

                   
       Contact GetContactByID(Contact example);
        List<Contact> GetListContactByFilter(ContactFilter exampleFilter);
        Contact Insert(Contact example);
        void Update(Contact example);
        void Delete(Contact example);
    }


}

