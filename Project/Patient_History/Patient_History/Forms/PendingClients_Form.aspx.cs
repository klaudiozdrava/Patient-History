using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Patient_History
{
    public partial class PendingClients_Form : Patients_HistoryForm
    {
        private PatientDB p1;
        private void ShowPendingClients()//show clients
        {
            string doctor_amka = Session["AMKA"].ToString();
            if(p1 == null) p1 = new PatientDB();
            List<List<string>> data = p1.GetPendingPatients(doctor_amka);
            TableRow r1 = new TableRow();
            r1.TableSection = TableRowSection.TableHeader;
            TableHeaderCell header = new TableHeaderCell();
            header.Text = "AMKA";
            TableHeaderCell header2 = new TableHeaderCell();
            header2.Text = "Όνομα";
            TableHeaderCell header3 = new TableHeaderCell();
            header3.Text = "Επίθετο";
            TableHeaderCell header4 = new TableHeaderCell();
            header4.Text = "Ημερομηνία Γέννησης";
            TableHeaderCell header5 = new TableHeaderCell();
            header5.Text = "Τηλέφωνο";
            TableHeaderCell header6 = new TableHeaderCell();
            header6.Text = "Διεύθυνση";
            TableHeaderCell header7 = new TableHeaderCell();
            header7.Text = "Email";
            TableHeaderCell header8 = new TableHeaderCell();
            header8.Text = "Ενέργεια";
            r1.Cells.Add(header);
            r1.Cells.Add(header2);
            r1.Cells.Add(header3);
            r1.Cells.Add(header4);
            r1.Cells.Add(header5);
            r1.Cells.Add(header6);
            r1.Cells.Add(header7);
            r1.Cells.Add(header8);
            Table1.Rows.Add(r1);
            try//add data to a table and a button for more info
            {
                foreach (List<string> row in data)
                {
                    LinkButton b1 = new LinkButton();
                    b1.Text = "Ιστορικό";
                    b1.Click += new EventHandler((Object o, EventArgs e) =>history_Click(o, e, row[0]));//lambda expression to call history_Click
                    TableRow r = new TableRow();
                    r.TableSection = TableRowSection.TableBody;
                    TableCell amka = new TableCell();
                    amka.Text = row[0];
                    TableCell firstname = new TableCell();
                    firstname.Text = row[1];
                    TableCell lastname = new TableCell();
                    lastname.Text = row[2];
                    TableCell birthdate = new TableCell();
                    birthdate.Text = row[3];
                    TableCell telephone = new TableCell();
                    telephone.Text = row[4];
                    TableCell address = new TableCell();
                    address.Text = row[5];
                    TableCell mail = new TableCell();
                    mail.Text = row[6];
                    TableCell extra = new TableCell();
                    r.Cells.Add(amka);
                    r.Cells.Add(firstname);
                    r.Cells.Add(lastname);
                    r.Cells.Add(birthdate);
                    r.Cells.Add(telephone);
                    r.Cells.Add(address);
                    r.Cells.Add(mail);
                    r.Cells.Add(extra);
                    extra.Controls.Add(b1);
                    Table1.Rows.Add(r);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckSession(doctoramka);
            ShowPendingClients();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)// log out
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LogInForm.aspx");
        }
        private void history_Click(object sender, EventArgs em, string patient_amka)//redirects to the  patient's medical record
        {
            Response.Redirect("history.aspx?visits=All&amka=" + patient_amka);
        }
    }
}