using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Patient_History
{
    public partial class EditVisit : Patients_HistoryForm
    {
        private string amkaurl;
        private string dateurl;
        private List<string> patients_data;
        private List<string> data;
        private Visit visit;
        private UpdateVisit updatevisit;
        private VisitDB visits;
        private string disease;
        private string symptom;
        private string vaccine;
        private string report;
        private string treatment;
        private string status;

        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckSession(doctoramka);
            CheckAMKA();
            CheckVisitDate();
            amkalabel.Text = "ΑΜΚΑ Ασθενούς: " + amkaurl;
            doctoramkalabel.Text = "ΑΜΚΑ Γιατρού: " + Session["AMKA"].ToString();
            DateTime vdate = DateTime.Parse(dateurl);
            string visit_date = vdate.ToString("dd/MM/yyyy HH:mm:ss");
            datelabel.Text = "Ημερομηνία επίσκεψης: " + visit_date;
            if (visits == null) visits = new VisitDB();
            data = visits.getVisit(amkaurl, dateurl);
            CheckVisit(data);
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

        private void CheckVisitDate()
        {
            dateurl = Request.QueryString.Get("visit_date");
            if (dateurl == null)
            {
                Session["message"] = "Λάθος ημερομηνία επίσκεψης. Ξαναπροσπαθήστε!";
                Response.Redirect("SearchPatients.aspx");  //redirect to search site to give right date
            }
        }

        private void CheckVisit(List<string> visits_data)//check what kind of visits to show
        {
            string visit = Request.QueryString.Get("visit");
            if (visit == null)
            {
                Session["message"] = "Λάθος λόγος επίσκεψης. Ξαναπροσπαθήστε!";
                Response.Redirect("SearchPatients.aspx");  //redirect to search site to give right amka
            }
            if (visit.Equals("Vaccine")) ShowVaccine(data);
            else if (visit.Equals("Illness")) ShowIllness(data);
        }

        private void ShowIllness(List<string> visits_data)//show form about illness
        {
            List<string> data = visits_data;
            Control illness_id = FindControl("illness_id");
            illness_id.Visible = true;
            Control vaccine_id = FindControl("vaccine_id");
            vaccine_id.Visible = false;
            try
            {
                disease = TextBox1.Text;
                TextBox1.Text = data[3];
                symptom = TextBox2.Text;
                TextBox2.Text = data[4];
                vaccine = null;
                report = TextBox4.Text;
                TextBox4.Text = data[6];
                treatment = TextBox5.Text;
                TextBox5.Text = data[7];
                status = DropDownList1.SelectedValue;
                DropDownList1.SelectedValue = data[8];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ShowVaccine(List<string> visits_data)//show form about vaccine
        {
            List<string> data = visits_data;
            Control illness_id = FindControl("illness_id");
            illness_id.Visible = false;
            Control vaccine_id = FindControl("vaccine_id");
            vaccine_id.Visible = true;
            try
            {
                disease = null;
                symptom = null;
                vaccine = TextBox3.Text;
                TextBox3.Text = data[5];
                report = null;
                treatment = null;
                status = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            visit = new Visit(); //gives object reference
            //set the variables
            visit.patient_AMKA_Setter(amkaurl);
            visit.Visit_Date = DateTime.Parse(dateurl);
            visit.doctorAMKA_Setter(Session["AMKA"].ToString());
            visit.disease_Setter(disease);
            visit.symptom_Setter(symptom);
            visit.vaccine_Setter(vaccine);
            visit.report_Setter(report);
            visit.treatment_Setter(treatment);
            visit.status_Setter(status);

            //Call createvisit
            updatevisit = new UpdateVisit(visit);
            bool z = updatevisit.updateVisit();

            if (z == true)
            {
                Session["message"] = "Η επεξεργασία επίσκεψης πραγματοποιήθηκε επιτυχώς!";
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
    }
}