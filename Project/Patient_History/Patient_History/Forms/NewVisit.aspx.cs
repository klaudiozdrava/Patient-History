using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Patient_History
{
    public partial class NewVisit : Patients_HistoryForm
    {
        private string amkaurl;
        private List<string> patients_data;
        private Visit visit;
        private CreateVisit createvisit;
        private string disease;
        private string symptom;
        private string vaccine;
        private string report;
        private string treatment;
        private string status;

        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckAMKA();
            CheckVisit();
            CheckSession(doctoramka);
            amkalabel.Text = "ΑΜΚΑ Ασθενούς: " + amkaurl;
            doctoramkalabel.Text = "ΑΜΚΑ Γιατρού: " + Session["AMKA"].ToString();
        }
        private void CheckAMKA()
        {
            // get ΑΜΚΑ from url parameter amka
            amkaurl = Request.QueryString.Get("amka");
            PatientDB p1 = new PatientDB();
            patients_data = p1.GetPatient(amkaurl);
            if (amkaurl == null || patients_data == null)
            {
                Session["message"] = "Λάθος ΑΜΚΑ. Ξαναπροσπαθήστε!";
                Response.Redirect("SearchPatients.aspx");  //redirect to search site to give right amka
            }
        }
        private void CheckVisit()//check what kind of visits to show
        {
            string visit = Request.QueryString.Get("visit");
            if (visit.Equals("Vaccine")) ShowVaccine();
            else if (visit.Equals("Illness")) ShowIllness();
        }

        private void ShowIllness()//show form about illness
        {
            Control illness_id = FindControl("illness_id");
            illness_id.Visible = true;
            Control vaccine_id = FindControl("vaccine_id");
            vaccine_id.Visible = false;
            disease = TextBox1.Text;
            symptom = TextBox2.Text;
            vaccine = null;
            report = TextBox4.Text;
            treatment = TextBox5.Text;
            status = DropDownList1.Text;
        }
        private void ShowVaccine()//show form about vaccine
        {
            Control illness_id = FindControl("illness_id");
            illness_id.Visible = false;
            Control vaccine_id = FindControl("vaccine_id");
            vaccine_id.Visible = true;
            disease = null;
            symptom = null;
            vaccine = TextBox3.Text;
            report = null;
            treatment = null;
            status = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            visit = new Visit(); //gives object reference
            //set the variables
            visit.patient_AMKA_Setter(amkaurl);
            visit.Visit_Date = DateTime.Now;
            visit.doctorAMKA_Setter(Session["AMKA"].ToString());
            visit.disease_Setter(disease);
            visit.symptom_Setter(symptom);
            visit.vaccine_Setter(vaccine);
            visit.report_Setter(report);
            visit.treatment_Setter(treatment);
            visit.status_Setter(status);
            //Call createvisit
            createvisit = new CreateVisit(visit);
            bool z = createvisit.CreateNewVisit();

            if (z == true)
            {
                Session["message"] = "Η καταχώρηση επίσκεψης πραγματοποιήθηκε επιτυχώς!";
                Response.Redirect("History.aspx?visits=All&amka=" + amkaurl);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("History.aspx?visits=All&amka=" + amkaurl);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LogInForm.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)//All
        {
            Response.Redirect("NewVisit.aspx?visit=Illness&amka=" + amkaurl);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)//Vaccine
        {
            Response.Redirect("NewVisit.aspx?visit=Vaccine&amka=" + amkaurl);
        }


    }
}