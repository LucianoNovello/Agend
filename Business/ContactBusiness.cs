
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DataSet SelectAllContact()
        {
            try
            {
                using ( ContactDAL dal = new ContactDAL())
                {
                    var connection = dal.OpenConnection();
                    DataSetCustom ds = new DataSetCustom(connection);
                    DataSet dsa = ds.GetContacts();
                    return dsa;
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
                    dal.ExecuteTransaction(transaction, connection, C);
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

        public void UpdateContact(Contact C)
        {
            using (ContactDAL dal = new ContactDAL())
            {
                var connection = dal.OpenConnection();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    
                    dal.ExecuteTransactionU(transaction, connection, C);


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
        }
        public List<Contact> GetContactByFilter(ContactFilter filter)
        {
            try
            {
                using (ContactDAL dal = new ContactDAL())
                {
                    var connection = dal.OpenConnection();
                    DataSet ds = dal.GetContactByFilter(connection, filter);
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
            return new Contact
            {
                FirstName = Convert.ToString(row["firstName"]),
                SecondName = Convert.ToString(row["secondName"]),
                DateAdmission = Convert.ToDateTime(row["dateAdmission"]),
                Gen =  Convert.ToChar(row["gen"]),
                Email = Convert.ToString(row["email"]),
                Cel = Convert.ToString(row["cel"]),
                Country = Convert.ToInt32(row["idCountry"]),
                City = Convert.ToString(row["city"]),
                Intern = Convert.ToInt32(row["cIntern"]),
                Org = Convert.ToString(row["org"]),
                Area = Convert.ToString(row["area"]),
                Active = Convert.ToBoolean(row["active"]),
                Direction= Convert.ToString(row["direction"]),
                Phone = Convert.ToString(row["phone"]),
                Skype= Convert.ToString(row["skype"])
                

            };
        }

        public void OpenConnection()
        {
            try
            {
                using (ContactDAL dal = new ContactDAL())
                {
                    var connection = dal.OpenConnection();
                    Console.WriteLine("Esto se debería leer entre que abro y cierro la conexión a BD");
                }
            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
            }
        }

    }
}
