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
    class DataAdapterCustom
    {
        public SqlDataAdapter GetAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = ConfigSelectCommand(connection)
            };
            return adapter;
        }

        private SqlCommand ConfigSelectCommand(SqlConnection connection)
        {
            return new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM [contacts]"
            };
        }

        public SqlDataAdapter GetAdapterCountrys(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = ConfigSelectCommandCountrys(connection)
            };
            return adapter;
        }

        private SqlCommand ConfigSelectCommandCountrys(SqlConnection connection)
        {
            return new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "SELECT * FROM [country]"
            };
        }
    }
}
