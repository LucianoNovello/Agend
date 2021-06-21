using DAL;
using Entity.Examples;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Business
{
    public class CountryBusiness : IDisposable
    {


        public void Dispose()
        {
            ContactDAL dAL = new ContactDAL();
            dAL.Dispose();

        }

        public string GetOneCountryByID(int id)
        {
            try
            {
                using (CountryDAL dal = new CountryDAL())
                {
                    string country = null;
                    var connection = dal.OpenConnection();
                    var Country = dal.GetCountryByFilter(connection, id);
                    if (Country != null)
                    {
                        while (Country.Read())
                        {
                            country = Country.GetString(1);
                        }
                        return country;

                    }
                    else
                    {
                        return "No tiene un Pais ingresado";
                    }
                }

            }
            catch (Exception e)
            {
                ExceptionPrint.Print(e);
                return null;
            }
        }
       
        public List<string>GetCountrysOnlyName()

        {
            try
            {
                using (CountryDAL dal = new CountryDAL())
                {
                    List<string> listC = new List<string>();
                    string country = null;
                    var connection = dal.OpenConnection();
                    var Country = dal.GetAllCountrys(connection);
                    if (Country != null)
                    {
                        while (Country.Read())
                        {
                            country = Country.GetString(1);
                            listC.Add(country);
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
    }
        
}
