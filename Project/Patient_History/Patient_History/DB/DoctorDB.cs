using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_History
{
    public class DoctorDB
    {
        private MySqlConnection connection;
        private Doctor doctor;
        private string password;
        public DoctorDB(Doctor d)
        {
            this.connection = Connection.getConnection();
            doctor = d;
        }
        
        public string getPass(string AMKA) //gets the password so as to check if it is the same with that that the user put
        {
            connection.Open();
            String query = "Select password from doctor where AMKA=?;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("AMKA", AMKA);
            //Εκτέλεση του query και χρήση ενός αντικειμένου για να αποθηκεύσουμε το αποτέλεσμα
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                password = reader.GetString(0);
            }
            connection.Close();
            return password;
        }

        public bool insertDoctor() //inserts a new doctor to the DB
        {
            try
            {
                connection.Open();
                String query = "Insert into doctor(AMKA,password,first_name,last_name,email,specialty,phone_number) " +
                    "values (?,?,?,?,?,?,?)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("AMKA", doctor.AMKA_Getter());
                command.Parameters.AddWithValue("password", doctor.password_Getter());
                command.Parameters.AddWithValue("first_name", doctor.firstName_Getter());
                command.Parameters.AddWithValue("last_name", doctor.lastName_Getter());
                command.Parameters.AddWithValue("email", doctor.email_Getter());
                command.Parameters.AddWithValue("specialty", doctor.speciality_Getter());
                command.Parameters.AddWithValue("phone_number", doctor.phoneNumber_Getter());
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                return false;

            }
        }

        public bool checkIfAMKAExists(string AMKA) //checks if the given AMKA already exists in the DB, so as to show a message in register form
        {
            bool exists = false; //shows if the AMKA already exists or not
            connection.Open();
            String query = "Select AMKA from doctor where AMKA=?;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("AMKA", AMKA);
            //Εκτέλεση του query και χρήση ενός αντικειμένου για να αποθηκεύσουμε το αποτέλεσμα
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                exists = true;
            }
            connection.Close();
            return exists;
        }

        public bool checkIfPhoneExists(string telPhone) //checks if the given phone number already exists in the DB, so as to show a message in register form
        {
            bool exists = false; //shows if the telephone already exists or not
            connection.Open();
            String query = "Select phone_number from doctor where phone_number=?;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("phone_number", telPhone);
            //Εκτέλεση του query και χρήση ενός αντικειμένου για να αποθηκεύσουμε το αποτέλεσμα
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                exists = true;
            }
            connection.Close();
            return exists;
        }

        public bool checkIfEmailExists(string email) //checks if the given phone number already exists in the DB, so as to show a message in register form
        {
            bool exists = false; //shows if the email already exists or not
            connection.Open();
            String query = "Select email from doctor where email=?;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("email", email);
            //Εκτέλεση του query και χρήση ενός αντικειμένου για να αποθηκεύσουμε το αποτέλεσμα
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                exists = true;
            }
            connection.Close();
            return exists;
        }
    }
}