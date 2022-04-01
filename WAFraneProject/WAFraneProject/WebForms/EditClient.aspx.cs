using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAFraneProject.Models;

namespace WAFraneProject.WebForms
{
    public partial class EditClient : System.Web.UI.Page
    {
        private Client Client
        {
            get
            {
                var id = Request.Url.Segments.Last();
                if (id == null)
                    Session["client"] = new Client();

                Session["client"] = Repository.GetClient(int.Parse(id));    
                return (Client)Session["client"];
            }
            set { Session["client"] = value; }
        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Client != null)
            {
                FillInput();
            }
        }

        private void FillInput()
        {
            txtFName.Text = Client.FirstName;
            txtLName.Text = Client.LastName;
            txtEmail.Text = Client.Email;
            txtPhone.Text = Client.Phone;
            FillDdlCountry();
            ddlCountry.Items.FindByText(Client.Country).Selected = true;
            FillDdlCity();
            ddlCity.Items.FindByText(Client.City).Selected = true;
        }

        private void FillDdlCountry()
        {
            foreach (Country country in Repository.GetCountries())
            {
                ddlCountry.Items.Add(new ListItem(country.Name, country.IDCountry.ToString()));
            }
        }

        private void FillDdlCity()
        {
            ddlCity.Items.Clear();

            int IDCountry = int.Parse(ddlCountry.SelectedValue);
            foreach (City city in Repository.GetCities(IDCountry))
            {
                ddlCity.Items.Add(new ListItem(city.Name, city.IDCity.ToString()));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUser();
        }
        private void CheckUser()
        {
            if (Request.Cookies["account"] == null)
                Response.Redirect("~/WebForms/Login.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpdateClient();
            Response.Redirect("~/WebForms/AllClients.aspx");
        }

        private void UpdateClient()
        {
            Client client = new Client();

            client.IDClient = Client.IDClient;
            client.FirstName = txtFName.Text;
            client.LastName = txtLName.Text;
            client.Email = txtEmail.Text;
            client.Phone = txtPhone.Text;
            client.CityID = int.Parse(ddlCity.SelectedValue);
            client.City = ddlCity.SelectedItem.ToString();
            client.Country = ddlCountry.SelectedItem.ToString();

            Repository.UpdateKupac(client);
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlCity();
        }
    }
}