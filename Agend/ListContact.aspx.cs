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

                ContactBusiness contactBusiness = new ContactBusiness();
                GridView1.DataSource = contactBusiness.GetContacts();
                GridView1.DataBind();
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

            DateTime date = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTimeText.Text));


            ContactBusiness listFilter = new ContactBusiness();
            PaginateProperties properties = new PaginateProperties
            {
                Order = 1,
                PageIndex = 0,
                PageSize = 5,
                SortBy = "secondName"

            }
;
            ContactFilter filter = new ContactFilter
            {
                FirstName = txtFirstName.Text,
                SecondName = txtSecondName.Text,
                CIntern = chkCintern.Checked,
                Org = txtOrg.Text,
                Area = txtArea.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                Active = ActiveCheck.Checked,
                dateAdmission = date

            };

            GridView1.DataSource = listFilter.GetContactByFilter(filter);
            GridView1.DataBind();


        }
        protected void CleanFilter(object sender, EventArgs e)
        {

            ContactBusiness contactBusiness = new ContactBusiness();
            CleanFilterText();
            GridView1.DataSource = contactBusiness.GetContacts();
            GridView1.DataBind();

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
    }
}

