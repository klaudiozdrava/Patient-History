using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Patient_History
{
    public partial class Patiens_List_Form : Patients_HistoryForm
    {
        private PatientDB p1;
        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckSession(doctoramka);
            ShowPatients();           
        }
        private void ShowPatients()
        {
            string id = Request.QueryString.Get("amka");
            if (id == null) Response.Redirect("SearchPatients.aspx");//redirect to search site to give amka
            if(p1 == null) p1= new PatientDB();
            List<string> data = p1.GetPatient(id);
            if (data == null)
            {
                Session["message"] = "Αυτό το ΑΜΚΑ δεν υπάρχει!";
                Response.Redirect("SearchPatients.aspx");
            }
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
                LinkButton b1 = new LinkButton();
                b1.Text = "Ιστορικό";
                b1.Click += new EventHandler((object sender, EventArgs e) =>history_Click(sender, e, id));
                TableRow r = new TableRow();
                r.TableSection = TableRowSection.TableBody;
                TableCell amka = new TableCell();
                amka.Text = data[0];
                TableCell firstname = new TableCell();
                firstname.Text = data[1];
                TableCell lastname = new TableCell();
                lastname.Text = data[2];
                TableCell birthdate = new TableCell();
                birthdate.Text = data[3];
                TableCell telephone = new TableCell();
                telephone.Text = data[4];
                TableCell address = new TableCell();
                address.Text = data[5];
                TableCell mail = new TableCell();
                mail.Text = data[6];
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        private void history_Click(object sender, EventArgs e, string patient_amka)//redirects to the  patient's medical record
        {
            Response.Redirect("History.aspx?visits=All&amka="+patient_amka);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LogInForm.aspx");
        }
    }
}