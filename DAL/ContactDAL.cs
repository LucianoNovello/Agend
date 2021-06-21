﻿using Entity.Examples;
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

  public int ExecuteTransactionI(SqlTransaction transaction, SqlConnection connection, Contact C)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.StoredProcedure,
                CommandText = "insertContact"
            };
            ParametersI(C, cmd);
            int registrosAfectados = cmd.ExecuteNonQuery();
            return registrosAfectados;
        }

        private static void ParametersI(Contact C, SqlCommand cmd)
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
        public SqlDataReader GetContactById(SqlConnection connection, int id)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetContactById"
            };

            cmd.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter() { ParameterName = "@id",  Value = id,      SqlDbType = SqlDbType.Int }
            });

            SqlDataReader result = cmd.ExecuteReader();

            return result;
        }
        public int ExecuteTransactionU(SqlTransaction transaction, SqlConnection connection, Contact editContact)
              {
                  SqlCommand cmd = new SqlCommand
                  {
                      Connection = transaction != null ? transaction.Connection : connection,
                      Transaction = transaction,
                      CommandType = CommandType.StoredProcedure,
                      CommandText = "updateContact"
                  };
                  ParametersU(editContact, cmd);
                  int registrosAfectados = cmd.ExecuteNonQuery();
                  return registrosAfectados;
              }

              private static void ParametersU(Contact C, SqlCommand cmd)
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

        public int ExecuteTransactionD(SqlTransaction transaction, SqlConnection connection, Contact editContact)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.StoredProcedure,
                CommandText = "deleteContact"
            };
            ParametersD(editContact, cmd);
            int registrosAfectados = cmd.ExecuteNonQuery();
            return registrosAfectados;
        }

        private static void ParametersD(Contact C, SqlCommand cmd)
        {
            cmd.Parameters.Add(new SqlParameter[]

                    {


                      new SqlParameter() { ParameterName = "@id", Value = C.Id, SqlDbType = SqlDbType.Int }

                      



                    });
        }
        public SqlDataReader GetContactByFilterV2(SqlConnection connection, ContactFilter filter)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "ContactByFilter"
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

                
              
         
        });
            SqlDataReader result = cmd.ExecuteReader();

            return result;
        }

        public DataSet GetContactsByFilter(SqlConnection connection, ContactFilter filter)
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
                CommandText = "ContactByFilter",
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
