<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewVisit.aspx.cs" Inherits="Patient_History.NewVisit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Προσθήκη Επίσκεψης</title>
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
                    <h3>Προσθήκη Επίσκεψης</h3>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label ID="amkalabel" runat="server" class="col col-form-label"></asp:Label>
             </div>

            <div class="form-group row">
                <asp:Label ID="doctoramkalabel" runat="server" class="col col-form-label"></asp:Label>
            </div>

            <div class="form-group text-center" style="width:50%; margin-left:auto; margin-right:auto;">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" class="col-sm-2 col-form-label">Ασθένεια</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" class="col-sm-2 col-form-label">Εμβόλιο</asp:LinkButton>
            </div>

            <div id="illness_id" runat="server">

                <div class="form-group row">
                    <asp:Label ID="Label3" runat="server" Text="Ασθένεια" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox1" required runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label ID="Label4" runat="server" Text="Συμπτώματα" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox2" required runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label ID="Label6" runat="server" Text="Πόρισμα" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox4" required runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label ID="Label7" runat="server" Text="Αγωγή" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox5" required runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label ID="Label8" runat="server" Text="Κατάσταση" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                            <asp:ListItem Selected="True" Value="pending">Εκκρεμεί</asp:ListItem>
                            <asp:ListItem Value="settled">Διευθετήθηκε</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div>

            <div id="vaccine_id" runat="server">

                <div class="form-group row">
                    <asp:Label ID="Label5" runat="server" Text="Εμβόλιο" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox3" required runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>

            </div>

            <div class="form-group row">
                <div class="col">
                    <asp:Button runat="server" Text="Προσθήκη" OnClick="Button1_Click" class="btn btn-primary"/>
                    <asp:Button runat="server" Text="Ακύρωση" OnClick="Button2_Click" formnovalidate class="btn btn-danger" style="float: right; margin-right: 20px;"/>
                </div>
            </div>

        </div>
    </form>
     <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
</body>
</html>

