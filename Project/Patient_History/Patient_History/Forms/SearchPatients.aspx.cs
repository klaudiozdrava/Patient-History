using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Patient_History
{
    public partial class SearchPatients : Patients_HistoryForm
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckSession(doctoramka, errorlabel, error);
        }
       

        protected void Button1_Click(object sender, EventArgs e)//redirects to the form that shows tehe result
        {
            string amka = TextBox1.Text;
            Response.Redirect("PatientsList.aspx?amka="+amka);
        }

        protected void Button2_Click(object sender, EventArgs e)//redirect to the form of user's pending clients
        {
            Response.Redirect("PendingClients_Form.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)// log out
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LogInForm.aspx");
        }
    }
}