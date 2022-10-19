using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_History
{
    public class LogIn
    {
        private DoctorDB doctorDB;
        private bool check = false;
        private PasswordProtector protector = new PasswordProtector(); //Used check if the given password is the same with the hashed password from the database 

        public LogIn()
        {

        }

        public bool checkPassword(string AMKA, string password)
        {
            doctorDB = new DoctorDB(null);
            protector.hashedPassword_setter(password);//makes the password from the textbox localy hashed to check if it's the same
            if (doctorDB.getPass(AMKA) != null) //checks if it is null (password exists) so as not to throw nullpointer exception
            {

                if (doctorDB.getPass(AMKA).Equals(protector.hashedPassword_Getter()) == true)
                {
                    check = true;

                }
                else
                {
                    check = false;
                }
            }
            else
            {
                check = false;
            }
            return check;
        }
    }
}