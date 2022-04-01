<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WAFraneProject.WebForms.Login" UnobtrusiveValidationMode="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <h1 runat="server" id="header" class="text-center">Log in</h1>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            Username:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ErrorMessage="Username required!" ControlToValidate="txtUsername" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtUsername"
                            CssClass="form-control" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            Password:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ErrorMessage="Password required!" ControlToValidate="txtPassword" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtPassword"
                            CssClass="form-control"
                            TextMode="Password" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            Repeat password:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPass" runat="server" ErrorMessage="Repeated password required!" ControlToValidate="txtRepeatPass" Font-Bold="True" ForeColor="Red" Display="Dynamic"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidatorPass" runat="server" ControlToCompare="txtRepeatPass" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password fields do not match!" Font-Bold="False" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:CompareValidator>
                        </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtRepeatPass"
                            CssClass="form-control"
                            TextMode="Password" />
                    </div>
                </div>
            </div>
                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Class="btnLogin" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign up" Class="btnSignup" OnClick="btnSignUp_Click" />
                </div>
        </div>

        <div>
            <asp:ValidationSummary runat="server" CssClass="text-center" DisplayMode="List" />
        </div>
    </form>
</body>
</html>
