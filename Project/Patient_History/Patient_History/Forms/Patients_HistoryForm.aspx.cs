using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Patient_History
{
    public partial class Patients_HistoryForm : System.Web.UI.Page//forms inherit it
    {
        protected void Page_Load(object sender, EventArgs e)//in the derived classes the hide the method
        {
            Response.Redirect("SearchPatients.aspx");

        }
        protected void CheckSession(Label doctoramka, Label errorlabel, HtmlGenericControl div)//if user has not loged or an error occured
        {
                      
                if (Session["AMKA"] == null)
                {
                    Session["message"] = "Δεν έχετε δικαίωμα πρόσβασης. Χρειάζεται να συνδεθείτε πρώτα!";
                    Response.Redirect("LogInForm.aspx");
                }
                if (Session["AMKA"] != null)
                {
                    doctoramka.Text = Session["AMKA"].ToString();
                }
                if (Session["message"] != null)
                {
                    errorlabel.Text = Session["message"].ToString();
                    div.Visible = true;
                    Session["message"] = null;
                }
                else div.Visible = false;
            
        }
        protected void CheckSession(Label errorlabel, HtmlGenericControl div)
        {

            if (Session["AMKA"] != null)
            {
                Response.Redirect("SearchPatients.aspx");
            }

            if (Session["message"] != null)
            {
                errorlabel.Text = Session["message"].ToString();
                div.Visible = true;
                Session["message"] = null;
            }
            else div.Visible = false;
        }
        protected void CheckSession(Label doctoramka)
        {
            if (Session["AMKA"] == null)
            {
                Session["message"] = "Δεν έχετε δικαίωμα πρόσβασης. Χρειάζεται να συνδεθείτε πρώτα!";
                Response.Redirect("LogInForm.aspx");
            }
            if (Session["AMKA"] != null)
            {
                doctoramka.Text = Session["AMKA"].ToString();
            }
        }
        
        
    }
}