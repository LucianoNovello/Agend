
using System;
using System.Collections.Generic;
using Entity.Examples;
using DAL;
using System.Data.SqlClient;
using Utils;
using System.Data;

namespace Business
{
    public class ContactBusiness :  IDisposable
    {
        

        public void Dispose()
        {

        }

       
        public void InsertContact(Contact C)
            {
                using (ContactDAL dal = new ContactDAL())
                {
                    var connection = dal.OpenConnection();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        dal.ExecuteTransactionI(transaction, connection, C);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        ExceptionPrint.Print(e);
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }

          /*public void UpdateContact(Contact C)
          {
              using (ContactDAL dal = new ContactDAL())
              {
                  var connection = dal.OpenConnection();
                  SqlTransaction transaction = connection.BeginTransaction();

                  try
                  {

                      dal.ExecuteTransactionU(transaction, connection, C.Id);


                      transaction.Commit();
                  }
                  catch (Exception e)
                  {
                      transaction.Rollback();
                      ExceptionPrint.Print(e);
                  }
                  finally
                  {
                      transaction.Dispose();
                  }
              }
          }*/

          public void DeleteContact(int id)
          {
              using (ContactDAL dal = new ContactDAL())
              {
                  var connection = dal.OpenConnection();
                  SqlTransaction transaction = connection.BeginTransaction();

                  try
                  {
                      dal.ExecuteTransactionD(transaction, connection,  id);


                      transaction.Commit();
                  }
                  catch (Exception e)
                  {
                      transaction.Rollback();
                      ExceptionPrint.Print(e);
                  }
                  finally
                  {
                      transaction.Dispose();
                  }
              }
          }
        
            public List<Contact> GetContactByFilter(ContactFilter filter)
        {
            try
            {
                using (ContactDAL dal = new ContactDAL())
                {
                    var connection = dal.OpenConnection();
                    DataSet ds = dal.GetContactsByFilter(connection, filter);
                    return MapDataSetToContacts(ds);
                }
            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
                return null;
            }
        }
           
        private List<Contact> MapDataSetToContacts(DataSet ds)
        {
            List<Contact> list = new List<Contact>();

            if (DataSetHelper.HasRecords(ds))
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    list.Add(MapDataRowToContact(row));
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        private static Contact MapDataRowToContact(DataRow row)
        {
            ContactBusiness contact = new ContactBusiness();
            return new Contact
            {
                Id = Convert.ToInt32(row["id"]),
                FirstName = Convert.ToString(row["firstName"]),
                SecondName = Convert.ToString(row["secondName"]),
                DateAdmission = Convert.ToDateTime(row["dateAdmission"]),
                Gen =  Convert.ToChar(row["gen"]),
                Email = Convert.ToString(row["email"]),
                Cel = Convert.ToString(row["cel"]),
                Country = contact.IdCountryToCountryName(Convert.ToInt32(row["idCountry"])),
                City = Convert.ToString(row["city"]),
                Intern = Convert.ToBoolean(row["cIntern"]),
                Org = Convert.ToString(row["org"]),
                Area = Convert.ToString(row["area"]),
                Active = Convert.ToBoolean(row["active"]),
                Direction= Convert.ToString(row["direction"]),
                Phone = Convert.ToString(row["phone"]),
                Skype= Convert.ToString(row["skype"])
                

            };
        }
        private string IdCountryToCountryName(int Id)
        {
            CountryBusiness countryBusiness = new CountryBusiness();
            return countryBusiness.GetOneCountryByID(Id);
        }
        public List<Contact>GetContacts()

        {
            try
            {
                using (ContactDAL dal = new ContactDAL())
                {
                    var connection = dal.OpenConnection();
                    DataSetCustom ds = new DataSetCustom(connection);
                    DataSet dsa = ds.GetContacts();
                    return MapDataSetToContacts(dsa);
                }
            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
                return null;
            }
        }



       
    }
}
