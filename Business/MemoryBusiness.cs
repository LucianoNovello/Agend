
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;



namespace Business
{
    public class MemoryBusiness : IBusiness, IDisposable
    {
        private List<Contact> lstContact;

        public void Dispose()
        {
        }

        public MemoryBusiness(List<Contact> lstContact)
        {
            this.lstContact = lstContact;
        }

        public Contact GetContactByID(Contact Contact)
        {
            return this.lstContact.Single(p => p.id.Equals(Contact.id));
        }

        public List<Contact> GetListContactByFilter(ContactFilter ContactFilter)
        {
            if (!string.IsNullOrEmpty(ContactFilter.name))
            {
                return this.lstContact.FindAll( p => p.name.Contains(ContactFilter.name)).OrderBy(p => p.id).ToList();
            }
            else
            {
                return this.lstContact.OrderBy(p => p.id).ToList();
            }
        }

        public Contact Insert(Contact Contact)
        {
            int max = this.lstContact.OrderByDescending(x => x.id).First().id.Value;
            Contact.id = (max + 1);
            this.lstContact.Add(Contact);
            return Contact;
        }

        public void Update(Contact Contact)
        {
            Contact ContactUpdate = this.lstContact.Find(p => p.id.Equals(Contact.id));
            if (ContactUpdate != null)
            {
                this.lstContact.Remove(ContactUpdate);
                this.lstContact.Add(Contact);
            }
        }

        public void Delete(Contact Contact)
        {
            Contact ContactDelete = this.lstContact.Find(p => p.id.Equals(Contact.id));
            if (ContactDelete != null)
            {
                this.lstContact.Remove(ContactDelete);
            }
        }

    }
}
