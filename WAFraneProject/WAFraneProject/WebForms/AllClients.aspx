<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllClients.aspx.cs" Inherits="WAFraneProject.WebForms.ClientsForms"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All clients</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/AllClients.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css"/>
    <script src="../Scripts/jquery-3.4.1.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js"></script>
    <script src="../Scripts/AllClients.js"></script>
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
    <form id="form" runat="server">  
        <div class="jumbotron body-content">
            <div class="selection">
                <label>Select a country:</label>
                <label id="proba" runat="server"></label>
                <asp:DropDownList runat="server" CssClass="ddlCountries" ID="ddlCountries" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                </asp:DropDownList>

                <label>Select a city:</label>
                <asp:DropDownList runat="server" CssClass="ddlCities" ID="ddlCities" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <hr />
                    <div class="form-group">
                        <label>Clients</label>
                        <hr />
                        <div>
                            <asp:GridView ID="gvCustomers" runat="server" CssClass="display compact" AutoGenerateColumns="false" BorderColor="#FFCCFF" BorderStyle="Solid" BorderWidth="4px" GridLines="Horizontal" HorizontalAlign="Center" >
                                <Columns>
                                    <asp:BoundField DataField="FirstName" HeaderText="First name" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last name" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                    <asp:BoundField DataField="City" HeaderText="City" />
                                    <asp:BoundField DataField="Country" HeaderText="Country" />
                                    <asp:BoundField DataField="Country" HeaderText=" " />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
        </div>
    </form>

</body>
    
</html>
