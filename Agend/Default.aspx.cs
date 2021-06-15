
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using System;
using Entity.Examples;

namespace Agend
{
    public partial class _Default : Page
    {
     
            private void print(List<Entity.Examples.Contact> listado)
            {
                foreach (Entity.Contact example in listado)
                {
                    Response.Write(string.Concat("Id: ", example.id.ToString(), " Name: ", example.name, "Email:", example.email));
                    Response.Write("<BR/>");
                }
            }

            protected void Page_Load(object sender, EventArgs e)
            {
                //Instancio mi business
                ClientBusiness business = new ContactBusiness((List<Entity.Contact>)Application["lstExample"]);

                Response.Write("Obtengo el registro con Id = 3 y lo imprimo en pantalla:");
                Response.Write("<BR/>");
                Entity.Contact example = business.GetContactByID(new Entity.Contact { id = 3 });
                Response.Write(string.Concat("Id: ", example.id.ToString(), " Name: ", example.name));
                Response.Write("<BR/>");
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");



                Response.Write("Actualizo el registro obtenido, lo recupero y lo imprimo en pantalla:");
                Response.Write("<BR/>");
                example.name = "Luxito";
                example.email = "Luzito@hotmail.com";
                business.Update(example);
                Entity.Contact exampleUpdate = business.GetContactByID(new Entity.Contact { id = 3 });
                Response.Write(string.Concat("Id: ", exampleUpdate.id.ToString(), " Name: ", exampleUpdate.name, " Email: ", exampleUpdate.email));
                Response.Write("<BR/>");
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");



                Response.Write("Elimino el registro con Id=7:");
                Response.Write("<BR/>");
                business.Delete(new Entity.Contact() { id = 7 });
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");



                Response.Write("Inserto un nuevo registro y lo imprimo en pantalla:");
                Response.Write("<BR/>");
                Entity.Contact exampleInsert = business.Insert(new Entity.Contact() { name = "Melixa", email="Meliza@hotmail.com" });
                Response.Write(string.Concat("Id: ", exampleInsert.id.ToString(), " Name: ", exampleInsert.name, " Email: ", exampleInsert.email));
                Response.Write("<BR/>");
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");



                Response.Write("Imprimo en pantalla el listado de registros:");
                Response.Write("<BR/>");
                print(business.GetListContactByFilter(new Entity.ContactFilter()));
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");

                
                
                Response.Write("Imprimo en pantalla el listado de registros filtrados en el que su nombre tenga X:");
                Response.Write("<BR/>");
                print(business.GetListContactByFilter(new Entity.ContactFilter() { name = "x" }));


                    
            }
        }
    }
    
