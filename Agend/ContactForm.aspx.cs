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
             
                    CountryBusiness counBusiness = new CountryBusiness();      
                    DropDownList1.DataSource = counBusiness.GetCountrysOnlyName(); ;
                    DropDownList1.DataBind();
                }

            }
        
        protected void SaveContact(object sender, EventArgs e)
        {
            DateTime admission = DateTime.Now.ToLocalTime();
            bool? test;
            if (!chkCintern.Checked)
            {
                test = null;
            }
            else
            {
                test= true;
            }
            bool? testA;
            if (!ActiveCheck.Checked)
            {
                testA = null;
            }
            else
            {
                testA = true;
            }


            Contact newContact = new Contact
            {

                FirstName = txtFirstName.Text != "" ? txtFirstName.Text : null,
                SecondName = txtSecondName.Text != "" ? txtSecondName.Text : null,
                Gen = txtGen.Text != "" ? txtGen.Text : null,
                Country = Convert.ToString(DropDownList1.SelectedIndex+1),
                Intern = test,
                Org = txtOrg.Text != "" ? txtOrg.Text : null,
                Area = txtArea.Text != "" ? txtArea.Text : null,
                City = txtCity.Text != "" ? txtCity.Text : null,
                Phone = txtPhone.Text != "" ? txtPhone.Text : null,
                Cel = txtCel.Text != "" ? txtCel.Text : null,
                Direction = txtDir.Text != "" ? txtDir.Text : null,
                Email = txtEmail.Text != "" ?txtEmail.Text : null,
                Skype = txtSkype.Text != "" ? txtSkype.Text : null,
                Active = testA,
                DateAdmission = admission,
            };
            if (newContact.Id == null)
            {
                ContactBusiness busi = new ContactBusiness();
                busi.InsertContact(newContact);
            }
            else
            {
                ContactBusiness business = new ContactBusiness();
                business.UpdateContact(newContact);
            }
            Response.Redirect("ListContact.aspx");


            }
     


    }












    }
