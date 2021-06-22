using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Entity.Examples;

namespace Agend
{
    public partial class ListContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                LoadGrid();
            
            }






        }


        protected void EditContact(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            Response.Redirect("ConsultForm.aspx");
            LoadGrid();
        }



        protected void ContactInsert(object sender, EventArgs e)
        {
            Response.Redirect("ContactForm.aspx");
        }
      
        private void LoadGrid()
        {
            
           
            int? test = null;
            if (chkCintern.Checked)
            {
                test = 1;
            }
            int? testA = null;
            if (ActiveCheck.Checked)
            {
                testA = 1;
            }
            DateTime? date = new DateTime();

            if (DateTimeText.Text == "")
            {
                date = null;
            }

            ContactBusiness listFilter = new ContactBusiness();
            PaginateProperties properties = new PaginateProperties
            {
                Order = 1,
                PageIndex = 0,
                PageSize = 10,
                SortBy = "secondName"

            };
            ContactFilter filter = new ContactFilter
            {

                FirstName = txtFirstName.Text != "" ? txtFirstName.Text : null,

                SecondName = txtSecondName.Text != "" ? txtSecondName.Text : null,
                CIntern = test,
                Org = txtOrg.Text != "" ? txtOrg.Text : null,
                Area = txtArea.Text != "" ? txtArea.Text : null,
                City = txtCity.Text != "" ? txtCity.Text : null,
                Country = (DropDownList1.SelectedIndex)+1,
                Active = testA,
                dateAdmission = date,
                PaginateProperties = properties

            };


            GridView1.DataSource = listFilter.GetContactByFilter(filter);
            GridView1.DataBind();
            CountryBusiness countrys = new CountryBusiness();
            DropDownList1.DataSource = countrys.GetCountrysOnlyName(); ;
            DropDownList1.DataBind();
        }

        protected void CleanFilter(object sender, EventArgs e)
        {

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            chkCintern.Checked = false;
            txtOrg.Text = "";
            txtArea.Text = "";
            txtCity.Text = "";
            ActiveCheck.Checked = false;
            DropDownList1.SelectedIndex =-1;
            DateTimeText.Text = "";
            LoadGrid();




           
           
           

        }



        protected void DelectContact(object sender, GridViewDeleteEventArgs e)
        {
            LoadGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int n = e.RowIndex;
            
       
        }
    }
}

