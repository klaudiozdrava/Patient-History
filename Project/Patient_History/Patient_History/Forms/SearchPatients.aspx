<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPatients.aspx.cs" Inherits="Patient_History.SearchPatients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Αναζήτηση Ασθενούς</title>
    <link rel="stylesheet" type="text/css" href="../Content/css/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-lg navbar-dark bg-primary rounded">
            <img src="../Content/images/logo.png" class="navbar-brand" style="width:75px;" />
            <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
                <a class="nav-link">Αναζήτηση ασθενούς</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="PendingClients_Form.aspx">Εκκρεμούντες ασθενείς</a>
            </li>
            </ul>
            <ul class="navbar-nav ml-auto">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><asp:Label ID="doctoramka" runat="server"></asp:Label></a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" class="dropdown-item">Αποσύνδεση</asp:LinkButton>
                </div>
            </li>
            </ul>
        </nav>

        <div class="container">
        
            <div class="row" style="margin:20px 0px 20px;">
                <div class="col text-center">
                    <h3>Αναζήτηση Ασθενούς</h3>
                </div>
            </div>

            <div id="error" class="msg error" runat="server">
                <asp:Label ID="errorlabel" runat="server"></asp:Label>
            </div>

            <div class="centered">

                <div class="form-inline">
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Eισάγετε το ΑΜΚΑ ασθενούς:" style="margin-right: 10px;"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" type="text" required pattern="\d{11}" MaxLength="11" class="form-control" style="margin-right: 10px;"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Αναζήτηση" Font-Bold="False" OnClick="Button1_Click" class="btn btn-primary" />
                </div>

                <div class="row text-center" style="margin-top:30px;">
                    <div class="col">
                        <asp:Label ID="Label1" runat="server" Text="Για να δείτε τους εκκρεμούντες ασθενείς σας πατήστε "></asp:Label>
                        <asp:LinkButton ID="LinkButton2" runat="server" formnovalidate OnClick="Button2_Click">εδώ</asp:LinkButton>
                    </div>
                </div>
            </div>

        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
</body>
</html>
