using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity.Examples;

namespace Agend
{
    public partial class ContactForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idContact = Convert.ToInt32(Request.QueryString["id"]);
                if (idContact >= 0)
                {
                    EditContact(idContact);
                }
                else
                {
                    CountryBusiness counBusiness = new CountryBusiness();
                    List<string> listC = new List<string>();
                    listC = counBusiness.GetCountrysOnlyName();
                    DropDownList1.DataSource = listC;
                    DropDownList1.DataBind();
                }

            }
        }
        protected void SaveContact(object sender, EventArgs e)
        {
            DateTime admission = DateTime.Now.ToLocalTime();
            Contact newContact = new Contact
            {
                FirstName = txtFirstName.Text,
                SecondName = txtSecondName.Text,
                Gen = Convert.ToChar(txtGen.Text),
                Country = Convert.ToString(DropDownList1.SelectedIndex),
                Intern = chkCintern.Checked,
                Org = txtOrg.Text,
                Area = txtArea.Text,
                Phone = txtPhone.Text,
                Cel = txtCel.Text,
                Email = txtEmail.Text,
                Skype = txtSkype.Text,
                DateAdmission = admission,
                Active = ActiveCheck.Checked

            };
            ContactBusiness business = new ContactBusiness();
            business.InsertContact(newContact);
            Response.Redirect("ListContact.aspx");


            }
        protected void EditContact(int id)
        {
           
            ContactBusiness contact = new ContactBusiness();
            Contact editC = contact.GetContactsById(id);
            txtFirstName.Text = editC.FirstName;
            txtSecondName.Text = editC.SecondName;
            txtGen.Text = Convert.ToString(editC.Gen);
            DropDownList1.SelectedValue = editC.Country;
            chkCintern.Checked = editC.Intern;
            txtOrg.Text = editC.Org;
            txtArea.Text = editC.Area;
            txtPhone.Text = editC.Phone;
            txtCel.Text = editC.Cel;
            txtEmail.Text = editC.Email;
            txtSkype.Text = editC.Skype;
            ActiveCheck.Checked= editC.Active;

        }


    }












    }
