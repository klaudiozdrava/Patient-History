using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Patient_History
{
    public partial class LogInForm : Patients_HistoryForm
    {
        private LogIn login;
        private bool checkLogIn;
        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckSession(errorlabel, error);
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            login = new LogIn();
            checkLogIn = login.checkPassword(TextBox1.Text, TextBox2.Text);
            if (checkLogIn==true) 
            {
                Session["AMKA"] = TextBox1.Text;
                Response.Redirect("SearchPatients.aspx");
            }
            else
            {
                error.Visible = true;
                errorlabel.Text = "Λανθασμένα στοιχεία! Παρακαλώ ξαναπροσπαθήστε!";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterForm.aspx");
        }
    }
}