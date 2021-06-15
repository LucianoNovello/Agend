using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Examples;


namespace Entity.Examples


{
   
    public class Contact

    {

        public int? Id { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }
         
        public char Gen { get; set; }

        public string Email { get; set; }

        public string Cel { get; set; }

        public int Country { get; set; }

        public string City { get; set; }

        public bool Intern { get; set; }


        public int Org {get;set;}


        public int Area { get; set; }

        public DateTime DateAdmission { get; set; }

        public Boolean Active { get; set; }
        
        public string Direction { get; set; }        
        
        public string Phone { get; set; }

        public string Skype { get; set; }


    }
}
