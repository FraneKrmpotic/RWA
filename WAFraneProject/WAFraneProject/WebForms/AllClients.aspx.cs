using WAFraneProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WAFraneProject.WebForms
{
    public partial class ClientsForms : System.Web.UI.Page
    {
        private static int selectedVal;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUser();

            if (!IsPostBack)
            {
                FillDdlCountries();
                FillDdlCities();
            }
            FillTable();
        }

        private void FillTable()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("FirstName");
            dummy.Columns.Add("LastName");
            dummy.Columns.Add("Email");
            dummy.Columns.Add("Phone");
            dummy.Columns.Add("City");
            dummy.Columns.Add("Country");
            dummy.Columns.Add(" ");
            dummy.Rows.Add();
            gvCustomers.DataSource = dummy;
            gvCustomers.DataBind();

            //Required for jQuery DataTables to work.
            gvCustomers.UseAccessibleHeader = true;
            gvCustomers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        [WebMethod]
        public static IEnumerable<Client> GetCustomers()
        {
            IEnumerable<Client> customers = Repository.GetClientsByCity(selectedVal);
            return customers;
        }

        //[WebMethod]
        //public static List<ListItem> GetReceipts(int id)
        //{
        //    IEnumerable<Receipt> receipts = Repository.GetAllReceipts(id);
        //    List<ListItem> items = new List<ListItem>();

        //    foreach (var receipt in receipts)
        //    {
        //        items.Add(new ListItem
        //        {
        //            Value = receipt.ID.ToString(),
        //            Text = receipt.Number.ToString()
        //        });
        //    }

        //    return items;
        //}

        //[WebMethod]
        //public static Receipt GetReceiptDetails(int id)
        //{
        //    Receipt receipts = Repository.GetReceiptDetails(id);
        //    return receipts;
        //}

        private void CheckUser()
        {
            if (Request.Cookies["account"] == null) 
                Response.Redirect("~/WebForms/Login.aspx");
        }

        private void FillDdlCities()
        {
            ddlCities.Items.Clear();

            int IDCountry = int.Parse(ddlCountries.SelectedValue);
            foreach (City city in Repository.GetCities(IDCountry))
            {
                ddlCities.Items.Add(new ListItem(city.Name, city.IDCity.ToString()));
            }
        }

        private void FillDdlCountries()
        {
            foreach (Country country in Repository.GetCountries())
            {
                ddlCountries.Items.Add(new ListItem(country.Name, country.IDCountry.ToString()));
            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlCities();
            selectedVal = int.Parse(ddlCities.SelectedValue);
        }

        protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedVal = int.Parse(ddlCities.SelectedValue);
        }
    }
}