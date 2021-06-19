using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DAL
{
    class CountryDAL
    {

        public SqlConnection connection;

        public CountryDAL()
        {
            connection = new SqlConnection
            {
                ConnectionString = Configuration.GetConnectionString()
            };
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Esto se debería leer entre que abro y cierro la conexión a BD");
                return connection;
            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
                return null;

            }
        }

        public int ExecuteTransaction(SqlTransaction transaction, SqlConnection connection, string nonNonQwerySentence)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandText = "insertCountry",
                CommandType = CommandType.StoredProcedure,
                
            };
            int registrosAfectados = cmd.ExecuteNonQuery();

            return registrosAfectados;
        }





        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }




    }
}
