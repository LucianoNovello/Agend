using Entity.Examples;
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
    public class CountryDAL : IDisposable
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
                return connection;
            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
                return null;

            }
        }
        public SqlDataReader GetAllCountrys(SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "Select * from [country]"
            };
            SqlDataReader result = cmd.ExecuteReader();
            return result;
        }
        public SqlDataReader GetCountryByFilter(SqlConnection connection, int? id)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "getCountryById"
            };

            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter() { ParameterName = "@id",  Value = id,      SqlDbType = SqlDbType.Int }
            });

            SqlDataReader result = cmd.ExecuteReader();

            return result;
        }
    
        public int ExecuteTransactionCI(SqlTransaction transaction, SqlConnection connection, string nonNonQwerySentence)
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
