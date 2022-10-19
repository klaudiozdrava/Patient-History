using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Patient_History
{
    public partial class RegisterForm : Patients_HistoryForm
    {
        private Doctor doctor;
        private Register register;
        private DoctorDB doctorDB;

        protected new void Page_Load(object sender, EventArgs e)
        {
            CheckSession(errorlabel, error);
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            errorlabel.Text = "";
            doctor = new Doctor(); //gives object reference
            //set the variables
            doctor.AMKA_Setter(TextBox1.Text);
            doctor.firstName_Setter(TextBox2.Text);
            doctor.lastName_Setter(TextBox3.Text);
            doctor.password_Setter(TextBox4.Text);
            doctor.email_Setter(TextBox5.Text);
            doctor.speciality_Setter(TextBox6.Text);
            doctor.phoneNumber_Setter(TextBox7.Text);

            doctorDB = new DoctorDB(doctor);

            bool y = doctorDB.checkIfAMKAExists(TextBox1.Text); //shows if the given AMKA already exists
            bool k = doctorDB.checkIfEmailExists(TextBox5.Text); //shows if the given email already exists
            bool n = doctorDB.checkIfPhoneExists(TextBox7.Text); //shows if the given telephone already exists

            if (y | k | n)
            {
                if (y)
                {
                    error.Visible = true;
                    errorlabel.Text += "Υπάρχει ήδη λογαριασμός με το συγκεκριμένο ΑΜΚΑ!" + "<br />";
                }
                if (k)
                {
                    error.Visible = true;
                    errorlabel.Text += "Υπάρχει ήδη λογαριασμός με το συγκεκριμένο email!" + "<br />";
                }
                if (n)
                {
                    error.Visible = true;
                    errorlabel.Text += "Υπάρχει ήδη λογαριασμός με το συγκεκριμένο τηλέφωνο!" + "<br />";
                }

            }

            else
            {
                register = new Register(doctor);
                bool z = register.createNewDoctor();

                if (z == true)
                {
                    Session["AMKA"] = TextBox1.Text;
                    Response.Redirect("SearchPatients.aspx");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInForm.aspx");
        }
    }
}