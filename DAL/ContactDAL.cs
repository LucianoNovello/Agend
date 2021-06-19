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
                Console.WriteLine("Esto se debería leer entre que abro y cierro la conexión a BD");
                return connection;
            }
            catch (Exception e)
            { 
                ExceptionPrint.Print(e);
                return null;

            }
        }

        public int ExecuteTransaction(SqlTransaction transaction, SqlConnection connection, Contact C)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.StoredProcedure,
                CommandText = "insertContact"
            };
            Parameters(C, cmd);
            int registrosAfectados = cmd.ExecuteNonQuery();
            return registrosAfectados;
        }

        private static void Parameters(Contact C, SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter[]

                    {


                new SqlParameter() { ParameterName = "@firstName", Value = C.FirstName, SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@secondName", Value = C.SecondName, SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@gen", Value = C.Gen, SqlDbType = SqlDbType.Char },

                new SqlParameter() { ParameterName = "@country", Value = C.Country, SqlDbType = SqlDbType.Int },

                new SqlParameter() { ParameterName = "@city", Value = C.City, SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@cIntern", Value = C.Intern, SqlDbType = SqlDbType.Int },

                new SqlParameter() { ParameterName = "@org", Value = C.Org, SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@area", Value = C.Area, SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@date", Value = C.DateAdmission, SqlDbType = SqlDbType.DateTime },

                new SqlParameter() { ParameterName = "@active", Value = C.Active, SqlDbType = SqlDbType.Bit },

                new SqlParameter() { ParameterName = "@phone", Value = C.Direction, SqlDbType = SqlDbType.VarChar},

                new SqlParameter() { ParameterName = "@email", Value = C.Org, SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@skype", Value = C.Org, SqlDbType = SqlDbType.VarChar }



                    });
        }

 
        public DataSet GetContactByFilter(SqlConnection connection, ContactFilter filter)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.SelectCommand = ConfigSelectCommand(connection, filter);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                if (DataSetHelper.HasRecords(ds) && filter.PaginateProperties != null)
                {
                    filter.PaginateProperties.RecordsCount = Convert.ToInt32(ds.Tables[0].Rows[0]["total_records"]);
                }
                return ds;
            }
        }
        private SqlCommand ConfigSelectCommand(SqlConnection connection, ContactFilter filter)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "selectContactbyFilter",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };
            cmd.Parameters.AddRange(new SqlParameter[]
            {

                new SqlParameter() { ParameterName = "@firstName",     Value = filter.FirstName,      SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@secondName",   Value = filter.SecondName,    SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@idCountry",   Value = filter.Country,    SqlDbType = SqlDbType.Int },

                new SqlParameter() { ParameterName = "@city",   Value = filter.City,    SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@cIntern",   Value = filter.CIntern,    SqlDbType = SqlDbType.Int },

                new SqlParameter() { ParameterName = "@org",   Value = filter.Org,    SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@area",   Value = filter.Area,    SqlDbType = SqlDbType.VarChar },

                new SqlParameter() { ParameterName = "@dateAdmission",   Value = filter.dateAdmission,    SqlDbType = SqlDbType.DateTime },

                new SqlParameter() { ParameterName = "@active",   Value = filter.Active,    SqlDbType = SqlDbType.Bit},

                
                //Parametros del Paginado
                new SqlParameter(){ ParameterName = "@PageSize", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties?.PageSize },
                new SqlParameter(){ ParameterName = "@PageIndex", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties?.PageIndex },
                new SqlParameter(){ ParameterName = "@SortBy", SqlDbType = SqlDbType.VarChar, Value = filter.PaginateProperties?.SortBy },
                new SqlParameter(){ ParameterName = "@Order", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties?.Order }
            });
            return cmd;
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
