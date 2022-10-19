<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Patient_History.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ιστορικό</title>
	<link rel="stylesheet" type="text/css" href="../Content/css/bootstrap.css" />
    <style>
        .form-group ul { width: 100%; list-style-type: none; display: flex; padding: 0; }
        .form-group ul li { width: 100%; box-sizing: border-box; flex-wrap: nowrap; }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar navbar-expand-lg navbar-dark bg-primary rounded">
            <img src="../Content/images/logo.png" class="navbar-brand" style="width:75px;" />
            <ul class="navbar-nav mr-auto">
            <li class="nav-item">
                <a class="nav-link" href="SearchPatients.aspx">Αναζήτηση ασθενούς</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="PendingClients_Form.aspx">Εκκρεμούντες ασθενείς</a>
            </li>
            </ul>
            <ul class="navbar-nav ml-auto">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><asp:Label ID="doctoramka" runat="server"></asp:Label></a>
                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" class="dropdown-item">Αποσύνδεση</asp:LinkButton>
                </div>
            </li>
            </ul>
        </nav>

	    <div class="container">

                <div class="row" style="margin:20px 0px 20px;">
                    <div class="col text-center">
                        <h3>Ιστορικό</h3>
                    </div>
                </div>

			    <div id="success" class="msg success" runat="server">
				    <asp:Label ID="errorlabel" runat="server" Text="Label"></asp:Label>
                </div>

			    <h4>Στοιχεία ασθενούς</h4>
                <div class="table-responsive">
			        <asp:Table ID="Table1" class="table table-hover" runat="server"></asp:Table>
                </div>

			    <div class="form-group text-center" style="margin-top: 50px;">
                    <ul>
				          <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Όλα</asp:LinkButton></li>
				          <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Ασθένειες</asp:LinkButton></li>
				          <li><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Εμβόλια</asp:LinkButton></li>
				          <li><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Εκκρεμότητες</asp:LinkButton></li>
                    </ul>
			    </div>

                <div class="form-group text-center" style="margin-top: 20px; overflow: auto;">
                    <asp:Button ID="Button1" runat="server" Text="Προσθήκη Επίσκεψης" OnClick="Button1_Click" class="btn btn-primary"/>
                </div>
			
			    <div style="margin-top:20px;">
				    <h4>Επισκέψεις</h4>
                    <div class="table-responsive">
				        <asp:Table ID="Table2" class="table table-hover" runat="server"></asp:Table>
                    </div>
			    </div>
	    </div>
    </form> 
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
</body>
</html>
