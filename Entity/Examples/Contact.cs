using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entity

{
    [Serializable]
    public class Contact

    {

        public int? id { get; set; }
        public string firstName { get; set; }

        public string secondName { get; set; }
         
        public char gen { get; set; }

        public string email { get; set; }

        public string cel { get; set; }

        public int country { get; set; }

        public string city { get; set; }

        public Boolean intern { get; set; }


        public int org {get;set;}


        public int area { get; set; }

        public DateTime dateAdmission { get; set; }

        public Boolean active { get; set; }
        
        public string direction { get; set; }        
        
        public string phone { get; set; }

        public string skype { get; set; }


    }
}
