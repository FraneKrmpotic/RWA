using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAFraneProject.Models;

namespace WAFraneProject.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            if (Request.Cookies["account"] != null)
            {
                HttpCookie httpCookie = Request.Cookies["account"];
                if (IsUserRegistered(httpCookie["username"], httpCookie["password"]))
                    Response.Redirect("~/WebForms/AllClients.aspx");
            }
        }

        private bool IsUserRegistered(string username, string password)
        {
            if (Repository.GetUserAccountCount(username, password) > 0)
                return true;
            else
                return false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Repository.GetUserAccountCount(txtUsername.Text, txtPassword.Text) > 0)
            {
                HttpCookie kuki = new HttpCookie("account");
                kuki["username"] = txtUsername.Text;
                kuki["password"] = txtPassword.Text;
                kuki.Expires = DateTime.Now.AddSeconds(300);
                Response.Cookies.Add(kuki);
                Response.Redirect("~/WebForms/AllClients.aspx");
            }
            else
            {
                ClearForm();

                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Incorrect username or password!";
                cv.IsValid = false;
                Validators.Add(cv);
            }
        }
        private void ClearForm()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtRepeatPass.Text = "";
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (Repository.GetUserAccountCount(txtUsername.Text, txtPassword.Text) > 0)
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "User with this username already exists!";
                cv.IsValid = false;
                Validators.Add(cv);
            }
            else
            {
                UserAccount userAccount = new UserAccount
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };
                Repository.CreateUserAccount(userAccount);
            }

        }
    }
}