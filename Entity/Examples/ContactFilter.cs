using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Examples
{
    public class ContactFilter
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime? dateAdmission { get; set; }

        public int? CIntern { get; set; }
        public int? Active { get; set; }

        public int? Country { get; set; }

        public string City { get; set; }
        public string Org { get; set; }
        public string Area { get; set; }

        public PaginateProperties PaginateProperties {get; set;}
       


    }
}
