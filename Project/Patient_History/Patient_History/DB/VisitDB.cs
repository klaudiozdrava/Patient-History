using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Patient_History
{
    public class VisitDB
    {
        private MySqlConnection connection;
        private Visit visit;
        public VisitDB(Visit v)
        {
            this.connection = Connection.getConnection();
            visit = v;
        }
        public VisitDB()
        {
            this.connection = Connection.getConnection();
        }
        public List<string> getVisit(string patient_amka, string date)
        {
            List<string> visit = new List<string>();
            MySqlConnection connection = Connection.getConnection();
            DateTime mydate = DateTime.Parse(date);
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~Connected~~~~~~~~~~~~~~~~~~~");
                string query = "select * from visit where patient_AMKA=@amka and visit_date=@date;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter parameter = new MySqlParameter("@amka", MySqlDbType.VarChar, 11);
                parameter.Value = patient_amka;
                MySqlParameter parameter2 = new MySqlParameter("@date", MySqlDbType.DateTime);
                parameter2.Value = mydate;
                command.Parameters.Add(parameter);
                command.Parameters.Add(parameter2);
                MySqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {

                    for (int col = 0; col < 9; col++)
                    {

                        if (col == 1)
                        {
                            visit.Add(datareader.GetDateTime(col).ToString("dd/MM/yyy HH:mm:ss"));
                            continue;
                        }
                        if (datareader.IsDBNull(col))
                        {
                            visit.Add("-");
                            continue;
                        }
                        visit.Add(datareader.GetString(col));
                    }

                }
                connection.Close();
                return visit;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return null;
            }
        }

        private List<List<string>> patient_id;

        public List<List<string>> GetAll(string amka)//get all visits
        {
            MySqlConnection connection = Connection.getConnection();
            patient_id = new List<List<string>>();
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Connected");

                string query = "Select * from visit where patient_AMKA=? ORDER BY visit_date DESC;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter parameter = new MySqlParameter("?", MySqlDbType.VarChar, 11);
                parameter.Value = amka;
                command.Parameters.Add(parameter);
                MySqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    List<string> row = new List<string>();
                    for (int col = 0; col < 9; col++)
                    {

                        if (col == 1)
                        {
                            row.Add(datareader.GetDateTime(col).ToString("dd/MM/yyy HH:mm:ss"));
                            continue;
                        }
                        if (col == 8)
                        {
                            if (datareader.IsDBNull(col))
                            {
                                row.Add("-");
                            }
                            else if (datareader.GetString(col) == "pending")
                            {
                                row.Add(datareader.GetString(col).Replace("pending", "Εκκρεμεί"));
                            }
                            else if (datareader.GetString(col) == "settled")
                            {
                                row.Add(datareader.GetString(col).Replace("settled", "Διευθετήθηκε"));
                            }
                            continue;
                        }
                        if (datareader.IsDBNull(col))
                        {
                            row.Add("-");
                            continue;
                        }
                        row.Add(datareader.GetString(col));
                    }
                    patient_id.Add(row);
                }
                connection.Close();
                return patient_id;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return null;
            }
        }
        public List<List<string>> GetVaccines(string amka)//get only visits from vaccines
        {
            MySqlConnection connection = Connection.getConnection();
            patient_id = new List<List<string>>();
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Connected");
                string query = "Select * from visit where patient_AMKA=? and vaccine is not null ORDER BY visit_date DESC;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter parameter = new MySqlParameter("?", MySqlDbType.VarChar, 11);
                parameter.Value = amka;
                command.Parameters.Add(parameter);
                MySqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    List<string> row = new List<string>();
                    for (int col = 0; col < 9; col++)
                    {

                        if (col == 1)
                        {
                            row.Add(datareader.GetDateTime(col).ToString("dd/MM/yyy HH:mm:ss"));
                            continue;
                        }
                        if (datareader.IsDBNull(col))
                        {

                            row.Add("-");
                            continue;
                        }
                        row.Add(datareader.GetString(col));
                    }
                    patient_id.Add(row);
                }
                connection.Close();
                return patient_id;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return null;
            }
        }
        public List<List<string>> GetIllnesses(string amka)//get only visits from illnesses
        {
            MySqlConnection connection = Connection.getConnection(); ;
            patient_id = new List<List<string>>();
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Connected");
                string query = "Select * from visit where patient_AMKA=? and disease is not null ORDER BY visit_date DESC;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter parameter = new MySqlParameter("?", MySqlDbType.VarChar, 11);
                parameter.Value = amka;
                command.Parameters.Add(parameter);
                MySqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    List<string> row = new List<string>();
                    for (int col = 0; col < 9; col++)
                    {

                        if (col == 1)
                        {
                            row.Add(datareader.GetDateTime(col).ToString("dd/MM/yyy HH:mm:ss"));
                            continue;
                        }
                        if (col == 8)
                        {
                            if (datareader.GetString(col) == "pending")
                            {
                                row.Add(datareader.GetString(col).Replace("pending", "Εκκρεμεί"));
                            }
                            else
                            {
                                row.Add(datareader.GetString(col).Replace("settled", "Διευθετήθηκε"));
                            }
                            continue;
                        }
                        if (datareader.IsDBNull(col))
                        {

                            row.Add("-");
                            continue;
                        }
                        row.Add(datareader.GetString(col));
                    }
                    patient_id.Add(row);
                }
                connection.Close();
                return patient_id;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return null;
            }
        }
        public List<List<string>> GetPending(string amka)//get only visits whith pending status
        {
            MySqlConnection connection = Connection.getConnection(); ;
            patient_id = new List<List<string>>();
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Connected");

                string query = "Select * from visit where patient_AMKA=? and status='pending' ORDER BY visit_date DESC;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter parameter = new MySqlParameter("?", MySqlDbType.VarChar, 11);
                parameter.Value = amka;
                command.Parameters.Add(parameter);
                MySqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    List<string> row = new List<string>();
                    for (int col = 0; col < 9; col++)
                    {

                        if (col == 1)
                        {
                            row.Add(datareader.GetDateTime(col).ToString("dd/MM/yyy HH:mm:ss"));
                            continue;
                        }
                        if (col == 8)
                        {
                            row.Add(datareader.GetString(col).Replace("pending", "Εκκρεμεί"));
                            continue;
                        }
                        if (datareader.IsDBNull(col))
                        {

                            row.Add("-");
                            continue;
                        }
                        row.Add(datareader.GetString(col));
                    }
                    patient_id.Add(row);
                }
                connection.Close();
                return patient_id;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return null;
            }
        }

        public bool insertVisit()
        {
            MySqlConnection connection = Connection.getConnection();
            try
            {
                connection.Open();
                String query = "Insert into visit(patient_AMKA,visit_date,doctor_amka,disease,symptom,vaccine,report,treatment,status) " +
                    "values (?,?,?,?,?,?,?,?,?)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("patient_AMKA", visit.patient_AMKA_Getter());
                command.Parameters.AddWithValue("visit_date", visit.Visit_Date);
                command.Parameters.AddWithValue("doctor_amka", visit.doctorAMKA_Getter());
                command.Parameters.AddWithValue("disease", visit.disease_Getter());
                command.Parameters.AddWithValue("symptom", visit.symptom_Getter());
                command.Parameters.AddWithValue("vaccine", visit.vaccine_Getter());
                command.Parameters.AddWithValue("report", visit.report_Getter());
                command.Parameters.AddWithValue("treatment", visit.treatment_Getter());
                command.Parameters.AddWithValue("status", visit.status_Getter());
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }

        public bool editVisit()
        {
            MySqlConnection connection = Connection.getConnection();
            try
            {
                connection.Open();
                String query = "update visit set disease=@disease, doctor_amka=@doctor_amka, symptom=@symptom, vaccine=@vaccine, report=@report, treatment=@treatment, status=@status " +
                    " where patient_AMKA=@amka and visit_date=@date ";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@amka", visit.patient_AMKA_Getter());
                command.Parameters.AddWithValue("@date", visit.Visit_Date);
                command.Parameters.AddWithValue("@disease", visit.disease_Getter());
                command.Parameters.AddWithValue("@doctor_amka", visit.doctorAMKA_Getter());
                command.Parameters.AddWithValue("@symptom", visit.symptom_Getter());
                command.Parameters.AddWithValue("@vaccine", visit.vaccine_Getter());
                command.Parameters.AddWithValue("@report", visit.report_Getter());
                command.Parameters.AddWithValue("@treatment", visit.treatment_Getter());
                command.Parameters.AddWithValue("@status", visit.status_Getter());
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
        }
    }
}