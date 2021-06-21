
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

        public Contact GetContactsById(int id)

        {
            try
            {
                using (ContactDAL dal = new ContactDAL())
                {
                    ContactBusiness aux = new ContactBusiness();
                    Contact contactFilter = new Contact();
                    var connection = dal.OpenConnection();
                    var Contact = dal.GetContactById(connection, id);
                    if (Contact != null)
                    {
                        while (Contact.Read())
                        {
                            contactFilter.FirstName = Contact.GetString(1);
                            contactFilter.SecondName = Contact.GetString(2);
                            contactFilter.Gen = Contact.GetChar(3);
                            contactFilter.Country = aux.IdCountryToCountryName(Contact.GetInt32(4));
                            contactFilter.City = Contact.GetString(5);
                            contactFilter.Intern = Contact.GetBoolean(6);
                            contactFilter.Org = Contact.GetString(7);
                            contactFilter.Area = Contact.GetString(8);
                            contactFilter.DateAdmission = Contact.GetDateTime(9);
                            contactFilter.Active = Contact.GetBoolean(10);
                            contactFilter.Direction = Contact.GetString(11);
                            contactFilter.Phone = Contact.GetString(12);
                            contactFilter.Cel = Contact.GetString(13);
                            contactFilter.Email = Contact.GetString(14);
                            contactFilter.Skype = Contact.GetString(15);
                        }
                        return contactFilter;

                    }
                    else
                    {
                        return contactFilter;
                    }
                }

            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
                return null;
            }
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

        /*  public void UpdateContact(Contact C)
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
          }

          public void DeleteContact(Contact Contact)
          {
              using (ContactDAL dal = new ContactDAL())
              {
                  var connection = dal.OpenConnection();
                  SqlTransaction transaction = connection.BeginTransaction();

                  try
                  {
                      dal.ExecuteTransactionD(transaction, connection, "");


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
        public List<Contact> GetContactsByFilterV2(ContactFilter filter)

        {
            try
            {
                using (ContactDAL dal = new ContactDAL())
                {
                    ContactBusiness aux = new ContactBusiness();
                    List<Contact> listC = new List<Contact>();
                    Contact contactFilter = new Contact();
                    var connection = dal.OpenConnection();
                    var Contact = dal.GetContactByFilterV2(connection, filter);
                    if (Contact != null)
                    {
                        while (Contact.Read())
                        {
                            contactFilter.FirstName = Contact.GetString(1);
                            contactFilter.SecondName = Contact.GetString(2);
                            contactFilter.Gen = Contact.GetChar(3);
                            contactFilter.Country = aux.IdCountryToCountryName(Contact.GetInt32(4));
                            contactFilter.City = Contact.GetString(5);
                            contactFilter.Intern = Contact.GetBoolean(6);
                            contactFilter.Org = Contact.GetString(7);
                            contactFilter.Area = Contact.GetString(8);
                            contactFilter.DateAdmission = Contact.GetDateTime(9);
                            contactFilter.Active = Contact.GetBoolean(10);
                            contactFilter.Direction = Contact.GetString(11);
                            contactFilter.Phone = Contact.GetString(12);
                            contactFilter.Cel = Contact.GetString(13);
                            contactFilter.Email = Contact.GetString(14);
                            contactFilter.Skype = Contact.GetString(15);
                            listC.Add(contactFilter);
                        }
                        return listC;

                    }
                    else
                    {
                        return listC;
                    }
                }

            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
                return null;
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
