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
    public class ContactDAL : IDisposable
    {

        public SqlConnection connection;

        public ContactDAL()
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
                CommandType = CommandType.Text,
                CommandText = nonNonQwerySentence
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
