<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="Patient_History.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Εγγραφή Γιατρού</title>
    <link rel="stylesheet" type="text/css" href="../Content/css/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="row" style="margin:20px 0px 20px;">
                <div class="col text-center">
                    <h3>Εγγραφή Γιατρού</h3>
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
                <asp:Label ID="Label3" runat="server" Text="Όνομα" class="col-sm-2 col-form-label"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBox2" required pattern="^(([Ά-Ώ Α-Ω α-ω ά-ώ][α-ω ά-ώ]+)|([A-Z a-z][a-z]+))$" title="Μόνο χαρακτήρες πχ Εμμανουήλ, Alexander" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Label ID="Label4" runat="server" Text="Επώνυμο" class="col-sm-2 col-form-label"></asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBox3" required pattern="^(([Ά-Ώ Α-Ω α-ω ά-ώ][α-ω ά-ώ]+)|([A-Z a-z][a-z]+))$" title="Μόνο χαρακτήρες πχ. Παπαγεωργίου, Pappas" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <asp:Label ID="Label7" runat="server" Text="Κωδικός" class="col-sm-2 col-form-label"></asp:Label>  
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBox4" type="password" required title="4 έως 15 χαρακτήρες,ψηφία,σύμβολα πχ dff34$3f" pattern="^([A-Z a-z Ά-Ώ Α-Ω ά-ώ α-ω 0-9 !,@,#,$,&,%,^,*,_,-,+,/]{4,15})$" runat="server" MaxLength="15" class="form-control"></asp:TextBox>
                </div>
            </div>        
        
            <div class="form-group row">
                <asp:Label ID="Label8" runat="server" Text="E-Mail" class="col-sm-2 col-form-label"></asp:Label>  
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBox5" runat="server" required type="email" title="πχ. aaaaaa@bbbb.ccc " class="form-control"></asp:TextBox>
                </div>
            </div>          

            <div class="form-group row">
                <asp:Label ID="Label9" runat="server" Text="Ειδικότητα" class="col-sm-2 col-form-label"></asp:Label>  
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBox6" required pattern="^(([Ά-Ώ Α-Ω α-ω ά-ώ][α-ω ά-ώ]+)|([A-Z a-z][a-z]+))$" title="Μόνο χαρακτήρες πχ Καρδιολόγος, Ophthalmologist" runat="server" class="form-control"></asp:TextBox>
                 </div>
            </div>           

            <div class="form-group row">
                <asp:Label ID="Label10" runat="server" Text="Τηλέφωνο" class="col-sm-2 col-form-label"></asp:Label>  
                <div class="col-sm-10">
                    <asp:TextBox ID="TextBox7" required title="Πρέπει ακριβώς 10 ψηφία" pattern="^([0-9]{10})$" runat="server" MaxLength="10" class="form-control"></asp:TextBox>
                </div>
            </div>        

            <div class="form-group row">
                <div class="col">
                    <asp:Button ID="Button1" runat="server" Text="Εγγραφή" OnClick="Button1_Click" class="btn btn-primary"/>
                </div>
            </div>
            
            <div class="form-group row">
                <div class="col text-center">
                    <asp:Label ID="Label13" runat="server" Text="Ήδη εγγεγραμμένος; " ></asp:Label>
                    <asp:LinkButton ID="LinkButton1" runat="server" formnovalidate OnClick="Button2_Click">Συνδεθείτε στον λογαριασμό σας</asp:LinkButton>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
