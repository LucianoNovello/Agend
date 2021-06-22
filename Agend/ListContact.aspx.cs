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


        protected void ContactEdit(object sender, EventArgs e)
        {
            int idContact = -1;
            if (GridView1.SelectedIndex >= 0)
            {
                idContact = Convert.ToInt32(ViewState["SelectedKey"]);
            }

            Response.Redirect(string.Format("ContactForm.aspx?id={0}", idContact));
        }



        protected void ContactInsert(object sender, EventArgs e)
        {
            Response.Redirect("ContactForm.aspx");
        }
        protected void ContactFilter(object sender, EventArgs e)
        {
            LoadGrid();

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
                PageSize = 5,
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
                Country = txtCountry.Text != "" ? txtCountry.Text : null,
                Active = testA,
                dateAdmission = date,
                PaginateProperties = properties

            };


            GridView1.DataSource = listFilter.GetContactByFilter(filter);
            GridView1.DataBind();
        }

        protected void CleanFilter(object sender, EventArgs e)
        {

           
            CleanFilterText();
            LoadGrid();

        }

        protected void CleanFilterText()
        {
            txtFirstName.Text = " ";
            txtSecondName.Text = " ";
            txtOrg.Text = " ";
            txtArea.Text = " ";
            txtCity.Text = " ";
            txtCountry.Text = " ";
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //codigo
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["id"]);
            Response.Redirect("~/ContactForm.aspx?id =" + id);
        }
        protected void DelectContact(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            int id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Values["id"]);
            ContactBusiness contact = new ContactBusiness();
            contact.DeleteContact(id);


        }

    }
}

