using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
namespace Agend
{
    public partial class ListContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
                 if (!IsPostBack)
                {
                    string dataArchivo = File.ReadAllText(ConfigurationManager.AppSettings.Get("PathContactos"));

                    if (dataArchivo != null)
                    {
                        List<Contacto> contactos = JsonConvert.DeserializeObject<List<Contacto>>(dataArchivo);

                        Session["Contactos"] = contactos;
                    }
                }


        }








    }
}