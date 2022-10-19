using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Patient_History
{
    public partial class History :  Patients_HistoryForm
    {
        private string amkaurl;//patient's amka
        private List<string> patients_data;
        private PatientDB p1;
        private VisitDB visits;
        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckSession(doctoramka, errorlabel, success);
            CheckAMKA();
            ShowPatient();
            CheckVisit();
        }
        private void CheckAMKA()
        {
            // get ΑΜΚΑ from url parameter amka
            amkaurl = Request.QueryString.Get("amka");
            if(p1 == null) p1 = new PatientDB();
            patients_data = p1.GetPatient(amkaurl);
            if (amkaurl == null || patients_data == null)
            {
                Session["message"] = "Λάθος ΑΜΚΑ. Ξαναπροσπαθήστε!";
                Response.Redirect("SearchPatients.aspx");  //redirect to search site to give right amka
            }
        }

        public void ShowPatient()
        {
            TableRow r1 = new TableRow();
            r1.TableSection = TableRowSection.TableHeader;
            TableHeaderCell amka_header = new TableHeaderCell();
            amka_header.Text = "AMKA";
            TableHeaderCell firstname_header = new TableHeaderCell();
            firstname_header.Text = "Όνομα";
            TableHeaderCell lastname_header = new TableHeaderCell();
            lastname_header.Text = "Επίθετο";
            TableHeaderCell birdthdate_header = new TableHeaderCell();
            birdthdate_header.Text = "Ημερομηνία Γέννησης";
            TableHeaderCell phonenumber_header = new TableHeaderCell();
            phonenumber_header.Text = "Τηλέφωνο";
            TableHeaderCell address_header = new TableHeaderCell();
            address_header.Text = "Διεύθυνση";
            TableHeaderCell email_header = new TableHeaderCell();
            email_header.Text = "E-Mail";
            r1.Cells.Add(amka_header);
            r1.Cells.Add(firstname_header);
            r1.Cells.Add(lastname_header);
            r1.Cells.Add(birdthdate_header);
            r1.Cells.Add(phonenumber_header);
            r1.Cells.Add(address_header);
            r1.Cells.Add(email_header);
            Table1.Rows.Add(r1);

            try//add data to a table
            {
                TableRow r2 = new TableRow();
                r2.TableSection = TableRowSection.TableBody;
                for (int col = 0; col < 7; col++)
                {
                    TableCell c = new TableCell();
                    c.Text = patients_data[col];
                    r2.Cells.Add(c);
                }
                Table1.Rows.Add(r2);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ShowVisits(List<List<string>> visits_data)//show the table of visits
        {
            //ΠΙΝΑΚΑΣ ΕΠΙΣΚΕΨΕΩΝ ΟΛΩΝ
            List<List<string>> data = visits_data;
            TableRow r3 = new TableRow();
            r3.TableSection = TableRowSection.TableHeader;
            TableHeaderCell visitdate_header = new TableHeaderCell();
            visitdate_header.Text = "Ημερομηνία επίσκεψης";
            TableHeaderCell doctoramka_header = new TableHeaderCell();
            doctoramka_header.Text = "ΑΜΚΑ Γιατρού";
            TableHeaderCell disease_header = new TableHeaderCell();
            disease_header.Text = "Ασθένεια";
            TableHeaderCell symptom_header = new TableHeaderCell();
            symptom_header.Text = "Συμπτώματα";
            TableHeaderCell vaccine_header = new TableHeaderCell();
            vaccine_header.Text = "Εμβόλιο";
            TableHeaderCell report_header = new TableHeaderCell();
            report_header.Text = "Πόρισμα";
            TableHeaderCell treatment_header = new TableHeaderCell();
            treatment_header.Text = "Αγωγή";
            TableHeaderCell status_header = new TableHeaderCell();
            status_header.Text = "Κατάσταση";
            TableHeaderCell action_header = new TableHeaderCell();
            action_header.Text = "Ενέργεια";
            r3.Cells.Add(visitdate_header);
            r3.Cells.Add(doctoramka_header);
            r3.Cells.Add(disease_header);
            r3.Cells.Add(symptom_header);
            r3.Cells.Add(vaccine_header);
            r3.Cells.Add(report_header);
            r3.Cells.Add(treatment_header);
            r3.Cells.Add(status_header);
            r3.Cells.Add(action_header);
            Table2.Rows.Add(r3);

            try
            {
                foreach (List<string> row in data)
                {
                    TableRow r4 = new TableRow();
                    r4.TableSection = TableRowSection.TableBody;
                    TableCell visitdate = new TableCell();
                    TableCell doctoramka = new TableCell();
                    TableCell disease = new TableCell();
                    TableCell symptom = new TableCell();
                    TableCell vaccine = new TableCell();
                    TableCell report = new TableCell();
                    TableCell treatment = new TableCell();
                    TableCell status = new TableCell();
                    TableCell extra = new TableCell();
                    LinkButton b1 = new LinkButton();
                    b1.Text = "Επεξεργασία";
                    string date = row[1];
                    DateTime vdate = DateTime.Parse(date);
                    string visit_date = vdate.ToString("yyyy-MM-dd HH:mm:ss");
                    string disease_string = row[3];
                    string vaccine_string = row[5];
                    b1.Click += new EventHandler((Object o, EventArgs e) => edit_Click(o, e, visit_date, disease_string, vaccine_string)); //lamda expression
                    visitdate.Text = row[1];
                    doctoramka.Text = row[2];
                    disease.Text = row[3];
                    symptom.Text = row[4];
                    vaccine.Text = row[5];
                    report.Text = row[6];
                    treatment.Text = row[7];
                    status.Text = row[8];
                    r4.Cells.Add(visitdate);
                    r4.Cells.Add(doctoramka);
                    r4.Cells.Add(disease);
                    r4.Cells.Add(symptom);
                    r4.Cells.Add(vaccine);
                    r4.Cells.Add(report);
                    r4.Cells.Add(treatment);
                    r4.Cells.Add(status);
                    r4.Cells.Add(extra);
                    extra.Controls.Add(b1);
                    Table2.Rows.Add(r4);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ShowVisitsVaccines(List<List<string>> visits_data)
        {
            //ΠΙΝΑΚΑΣ ΕΠΙΣΚΕΨΕΩΝ ΕΜΒΟΛΙΩΝ
            List<List<string>> data = visits_data;
            TableRow r5 = new TableRow();
            r5.TableSection = TableRowSection.TableHeader;
            TableHeaderCell visitdate_header = new TableHeaderCell();
            visitdate_header.Text = "Ημερομηνία επίσκεψης";
            TableHeaderCell doctoramka_header = new TableHeaderCell();
            doctoramka_header.Text = "ΑΜΚΑ Γιατρού";
            TableHeaderCell disease_header = new TableHeaderCell();
            TableHeaderCell vaccine_header = new TableHeaderCell();
            vaccine_header.Text = "Εμβόλιο";
            TableHeaderCell action_header = new TableHeaderCell();
            action_header.Text = "Ενέργεια";
            r5.Cells.Add(visitdate_header);
            r5.Cells.Add(doctoramka_header);
            r5.Cells.Add(vaccine_header);
            r5.Cells.Add(action_header);
            Table2.Rows.Add(r5);

            try
            {
                foreach (List<string> row in data)
                {
                    TableRow r6 = new TableRow();
                    r6.TableSection = TableRowSection.TableBody;
                    TableCell visitdate = new TableCell();
                    TableCell doctoramka = new TableCell();
                    TableCell vaccine = new TableCell();
                    TableCell extra = new TableCell();
                    LinkButton b1 = new LinkButton();
                    b1.Text = "Επεξεργασία";
                    string date = row[1];
                    DateTime vdate = DateTime.Parse(date);
                    string visit_date = vdate.ToString("yyyy-MM-dd HH:mm:ss");
                    string disease_string = row[3];
                    string vaccine_string = row[5];
                    b1.Click += new EventHandler((Object o, EventArgs e) => edit_Click(o, e, visit_date, disease_string, vaccine_string)); //lamda expression
                    visitdate.Text = row[1];
                    doctoramka.Text = row[2];
                    vaccine.Text = row[5];
                    r6.Cells.Add(visitdate);
                    r6.Cells.Add(doctoramka);
                    r6.Cells.Add(vaccine);
                    r6.Cells.Add(extra);
                    extra.Controls.Add(b1);
                    Table2.Rows.Add(r6);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ShowVisitsIllnesses(List<List<string>> visits_data)
        {
            //ΠΙΝΑΚΑΣ ΕΠΙΣΚΕΨΕΩΝ ΑΣΘΕΝΕΙΩΝ
            List<List<string>> data = visits_data;
            TableRow r7 = new TableRow();
            r7.TableSection = TableRowSection.TableHeader;
            TableHeaderCell visitdate_header = new TableHeaderCell();
            visitdate_header.Text = "Ημερομηνία επίσκεψης";
            TableHeaderCell doctoramka_header = new TableHeaderCell();
            doctoramka_header.Text = "ΑΜΚΑ Γιατρού";
            TableHeaderCell disease_header = new TableHeaderCell();
            disease_header.Text = "Ασθένεια";
            TableHeaderCell symptom_header = new TableHeaderCell();
            symptom_header.Text = "Συμπτώματα";
            TableHeaderCell report_header = new TableHeaderCell();
            report_header.Text = "Πόρισμα";
            TableHeaderCell treatment_header = new TableHeaderCell();
            treatment_header.Text = "Αγωγή";
            TableHeaderCell status_header = new TableHeaderCell();
            status_header.Text = "Κατάσταση";
            TableHeaderCell action_header = new TableHeaderCell();
            action_header.Text = "Ενέργεια";
            r7.Cells.Add(visitdate_header);
            r7.Cells.Add(doctoramka_header);
            r7.Cells.Add(disease_header);
            r7.Cells.Add(symptom_header);
            r7.Cells.Add(report_header);
            r7.Cells.Add(treatment_header);
            r7.Cells.Add(status_header);
            r7.Cells.Add(action_header);
            Table2.Rows.Add(r7);

            try
            {
                foreach (List<string> row in data)
                {
                    TableRow r8 = new TableRow();
                    r8.TableSection = TableRowSection.TableBody;
                    TableCell visitdate = new TableCell();
                    TableCell doctoramka = new TableCell();
                    TableCell disease = new TableCell();
                    TableCell symptom = new TableCell();
                    TableCell report = new TableCell();
                    TableCell treatment = new TableCell();
                    TableCell status = new TableCell();
                    TableCell extra = new TableCell();
                    LinkButton b1 = new LinkButton();
                    b1.Text = "Επεξεργασία";
                    string date = row[1];
                    DateTime vdate = DateTime.Parse(date);
                    string visit_date = vdate.ToString("yyyy-MM-dd HH:mm:ss");
                    string disease_string = row[3];
                    string vaccine_string = row[5];
                    b1.Click += new EventHandler((Object o, EventArgs e) => edit_Click(o, e, visit_date, disease_string, vaccine_string)); //lamda expression
                    visitdate.Text = row[1];
                    doctoramka.Text = row[2];
                    disease.Text = row[3];
                    symptom.Text = row[4];
                    report.Text = row[6];
                    treatment.Text = row[7];
                    status.Text = row[8];
                    r8.Cells.Add(visitdate);
                    r8.Cells.Add(doctoramka);
                    r8.Cells.Add(disease);
                    r8.Cells.Add(symptom);
                    r8.Cells.Add(report);
                    r8.Cells.Add(treatment);
                    r8.Cells.Add(status);
                    r8.Cells.Add(extra);
                    extra.Controls.Add(b1);
                    Table2.Rows.Add(r8);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewVisit.aspx?visit=Illness&amka=" + amkaurl);
        }

        protected void edit_Click(object sender, EventArgs e, string visit_date, string disease, string vaccine)
        {
            if (vaccine.Equals("-") && !disease.Equals("-"))//if visit was about a vaccine
            {
                Response.Redirect("EditVisit.aspx?visit=Illness&" + disease + "&amka=" + amkaurl + "&visit_date=" + visit_date);
            }
            else if (disease.Equals("-") && !vaccine.Equals("-"))//if visit was about a disease
            {
                Response.Redirect("EditVisit.aspx?visit=Vaccine&" + vaccine + "&amka=" + amkaurl + "&visit_date=" + visit_date);
            }

        }

        private void CheckVisit()//check what kind of visits to show
        {
            string visit = Request.QueryString.Get("visits");
            if (visit.Equals("All")) ShowAll();
            else if (visit.Equals("Vaccines")) ShowVaccines();
            else if (visit.Equals("Illnesses")) ShowIllnesses();
            else if (visit.Equals("Pending")) ShowPending();
        }
        private void ShowAll()//show all visits
        {
            if (visits == null) visits = new VisitDB();
            List<List<string>> data = visits.GetAll(amkaurl);
            ShowVisits(data);
        }
        private void ShowVaccines()//show visits about vaccines
        {
            if (visits == null) visits = new VisitDB();
            List<List<string>> data = visits.GetVaccines(amkaurl);
            ShowVisitsVaccines(data);
        }
        private void ShowIllnesses()//show visits about Illnesses
        {
            if (visits == null) visits = new VisitDB();
            List<List<string>> data = visits.GetIllnesses(amkaurl);
            ShowVisitsIllnesses(data);
        }
        private void ShowPending()//show visits that have a pending status
        {
            if (visits == null) visits = new VisitDB();
            List<List<string>> data = visits.GetPending(amkaurl);
            ShowVisitsIllnesses(data);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)//All
        {
            Response.Redirect("History.aspx?visits=All&amka=" + amkaurl);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)//Illnesses
        {
            Response.Redirect("History.aspx?visits=Illnesses&amka=" + amkaurl);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)//Vaccine
        {

            Response.Redirect("History.aspx?visits=Vaccines&amka=" + amkaurl);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)//Pending
        {
            Response.Redirect("History.aspx?visits=Pending&amka=" + amkaurl);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)//Log out
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LogInForm.aspx");
        }
    }
}