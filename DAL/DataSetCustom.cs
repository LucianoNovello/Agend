using Entity.Examples;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataSetCustom
    {
        private readonly SqlDataAdapter adapter;
   

        public DataSetCustom(SqlConnection connection)
        {
            DataAdapterCustom adapter = new DataAdapterCustom();
            
           
            this.adapter = adapter.GetAdapter(connection);
            
        }

        public DataSet GetContacts()
        {
            DataSet contactsDS = new DataSet();

            adapter.Fill(contactsDS);
            return contactsDS;
        }

     

       
    }
}
