<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditClient.aspx.cs" Inherits="WAFraneProject.WebForms.EditClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/EditClients.css" rel="stylesheet" />
    <title>EditClient</title>
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>
                        <a class="nav-link active" aria-current="page" href="/WebForms/AllClients.aspx">Home</a>
                    </li>
                    <li>
                        <a class="nav-link active" aria-current="page" href="/CRUD?tab=category">Categories</a>
                    </li>
                    <li>
                        <a class="nav-link active" aria-current="page" href="/CRUD?tab=product">Product</a>
                    </li>
                    <li>
                        <a class="nav-link active" aria-current="page" href="/CRUD?tab=subcategory">Subcategories</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
        <div class="jumbotron body-content">
            <div class="row">
                <div class="col-sm-12">
                    <h1 runat="server" id="header">Client</h1>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            First name:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFName" runat="server" ErrorMessage="First name is required!" ControlToValidate="txtFName" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtFName"
                            CssClass="form-control" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            Last name:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLName" runat="server" ErrorMessage="Last name is required!" ControlToValidate="txtLName" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                        </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtLName"
                            CssClass="form-control" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            Email:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email is required!" ControlToValidate="txtEmail" Display="Dynamic" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Email is in incorrect format!" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" Font-Bold="True" ForeColor="Red">*</asp:RegularExpressionValidator>
                        </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtEmail"
                            CssClass="form-control" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            Phone:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ErrorMessage="Phone number is required!" ControlToValidate="txtPhone" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>

                        </label>
                        <asp:TextBox
                            runat="server"
                            ID="txtPhone"
                            CssClass="form-control" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            City:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCity" runat="server" ErrorMessage="City is required!" ControlToValidate="ddlCity" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                        </label>
                        <asp:DropDownList AutoPostBack="true" ID="ddlCity" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label>
                            Country:
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCountry" runat="server" ErrorMessage="Country is required!" ControlToValidate="ddlCountry" Font-Bold="True" ForeColor="Red"><span class="badge rounded-pill bg-secondary">!</span></asp:RequiredFieldValidator>
                        </label>
                        <asp:DropDownList AutoPostBack="true" ID="ddlCountry" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-warning" OnClick="btnSubmit_Click" />
            </div>
        </div>

        <div>
            <asp:ValidationSummary runat="server" />
        </div>
    </form>
</body>
</html>
