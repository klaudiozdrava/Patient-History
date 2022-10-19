<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogInForm.aspx.cs" Inherits="Patient_History.LogInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Είσοδος Γιατρού</title>
    <link rel="stylesheet" type="text/css" href="../Content/css/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row" style="margin:20px 0px 20px;">
                <div class="col text-center">
                    <h3>Είσοδος Γιατρού</h3>
                </div>
            </div>

            <div id="error" class="msg error" runat="server">
				<asp:Label ID="errorlabel" runat="server"></asp:Label>
            </div>

                <div class="form-group row">
                    <asp:Label ID="Label2" runat="server" Text="ΑΜΚΑ" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox1" required pattern="^([0-9]{11})$" title="Πρέπει ακριβώς 11 ψηφία" runat="server" MaxLength="11" class="form-control"></asp:TextBox>
                    </div>
                 </div>

                <div class="form-group row">
                    <asp:Label ID="Label3" runat="server" Text="Κωδικός" class="col-sm-2 col-form-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBox2" type="password" required pattern="^([A-Z a-z Ά-Ώ Α-Ω ά-ώ α-ω 0-9 !,@,#,$,%,^,&,*,_,-,+,/]{4,15})$" title="4 έως 15 χαρακτήρες" runat="server" MaxLength="15" class="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row">
                    <div class="col">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Είσοδος" class="btn btn-primary"/>
                    </div>
                </div>

                <div class="form-group row">
                    <div class="col text-center">
                        <asp:Label ID="Label13" runat="server" Text="Νέος; "></asp:Label>
                        <asp:LinkButton ID="LinkButton1" runat="server" formnovalidate OnClick="Button2_Click">Δημιουργήστε ένα λογαριασμό</asp:LinkButton>
                    </div>
                </div>

        </div>
    </form>
</body>
</html>
