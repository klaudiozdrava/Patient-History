using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Patient_History
{
    public class PatientDB
    {        
        public List<string> GetPatient(string patient_amka)
        {
            List<string> patient = new List<string>();
            MySqlConnection connection = Connection.getConnection();
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~Connected~~~~~~~~~~~~~~~~~~~");

                string query = "select * from patient where AMKA=?;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter parameter = new MySqlParameter("?", MySqlDbType.VarChar, 11);
                parameter.Value = patient_amka;
                command.Parameters.Add(parameter);
                MySqlDataReader datareader = command.ExecuteReader();
                int count=0;
                while (datareader.Read())
                {
                    for (int col = 0; col < 7; col++)
                    {
                        if (col == 3)
                        {
                            patient.Add(datareader.GetDateTime(col).ToString("dd/MM/yyy"));
                            continue;
                        }
                        if (datareader.IsDBNull(col))
                        {
                            patient.Add("-");
                            continue;
                        }
                        patient.Add(datareader.GetString(col));
                    }
                    count++;
                }
                connection.Close();
                if (count == 0) patient = null;
                return patient;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return null;
            }
        }
        
        public List<List<string>> GetPendingPatients(string doctor_amka)
        {
            MySqlConnection connection = Connection.getConnection();
            List<List<string>> patients = new List<List<string>>();
            try
            {
                connection.Open();
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~Connected~~~~~~~~~~~~~~~~~~~");
                string query = "select patient.* from patient  join  visit on patient.AMKA = visit.patient_AMKA" +
                    " where status='pending' and doctor_amka=? group by patient_AMKA;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter parameter = new MySqlParameter("?", MySqlDbType.VarChar, 11);
                parameter.Value = doctor_amka;
                command.Parameters.Add(parameter);
                MySqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    List<string> row = new List<string>();
                    for (int col = 0; col < 7; col++)
                    {

                        if (col == 3)
                        {
                            row.Add(datareader.GetDateTime(col).ToString("dd/MM/yyy"));
                            continue;
                        }
                        if (datareader.IsDBNull(col))
                        {
                            row.Add("-");
                            continue;
                        }
                        row.Add(datareader.GetString(col));
                        
                    }
                    patients.Add(row);
                }
                connection.Close();
                return patients;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                System.Diagnostics.Debug.WriteLine(ex);
                System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                return null;
            }
        }
    }
}