<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientsList.aspx.cs" Inherits="Patient_History.Patiens_List_Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Στοιχεία ασθενούς</title>
    <link rel="stylesheet" type="text/css" href="../Content/css/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-lg navbar-dark bg-primary rounded">
            <img src="../Content/images/logo.png" class="navbar-brand" style="width:75px;" />
            <ul class="navbar-nav mr-auto">
            <li class="nav-item">
                <a class="nav-link"  href="SearchPatients.aspx">Αναζήτηση ασθενούς</a>
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
                    <h3>Στοιχεία ασθενούς</h3>
                </div>
            </div>

            <div class="table-responsive">
                <asp:Table id="Table1" runat="server" class="table table-hover"></asp:Table>
            </div>

         </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
</body>
</html>
