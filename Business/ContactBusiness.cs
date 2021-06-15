
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Examples;
using DAL;
using System.Data.SqlClient;
using Utils;


namespace Business
{
    public class ContactBusiness :  IDisposable
    {
        private List<Contact> lstContact;

        public void Dispose()
        {
        }

        public ContactBusiness(List<Contact> lstContact)
        {
            this.lstContact = lstContact;
        }

      /*  public Contact GetContactByID(Contact Contact)
        {
            return this.lstContact.Single(p => p.id.Equals(Contact.id));
        }

       /* public List<Contact> GetListContactByFilter(ContactFilter ContactFilter)
        {
            if (!string.IsNullOrEmpty(ContactFilter.name))
            {
                return this.lstContact.FindAll( p => p.name.Contains(ContactFilter.name)).OrderBy(p => p.id).ToList();
            }
            else
            {
                return this.lstContact.OrderBy(p => p.id).ToList();
            }
        }*/

        public void InsertContact(Contact C)
        {
            using (ContactDAL dal = new ContactDAL())
            {
                var connection = dal.OpenConnection();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {


                   string firstName = C.FirstName;
                   string secondName = C.SecondName;
                   bool intern = C.Intern;
                   int org = C.Org;
                   string phone = C.Phone;
                   string skype = C.Skype;
                   char gen =   C.Gen;
                   string direction = C.Direction;
                   string city = C.City;
                   int area =  C.Area;
                   DateTime admission = C.DateAdmission;
                   int country = C.Country;
                   string cel =  C.Cel;
                   bool active = C.Active;
                  

                    dal.ExecuteTransaction(transaction, connection, "EXEC insertContact 'firstName, secondName, gen, country, city, intern, org, area, admission, active, direction, phone, cel, email, skype'");
                   

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
                    dal.ExecuteTransaction(transaction, connection, "");


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
                    dal.ExecuteTransaction(transaction, connection, "");


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
