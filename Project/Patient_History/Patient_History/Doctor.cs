using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Patient_History
{
    public class Doctor
    {
        private string AMKA;
        private string password;
        private string firstName;
        private string lastName;
        private string email;
        private string speciality;
        private string phone_number;
        private PasswordProtector protector=new PasswordProtector();

        public void AMKA_Setter(string a)
        {
            this.AMKA = a;
        }
        public string AMKA_Getter()
        {
            return this.AMKA;
        }
        public void password_Setter(string a) //hashed
        {
            protector.hashedPassword_setter(a); //makes the password hashed calling the this setter method
            this.password = protector.hashedPassword_Getter();
        }
        public string password_Getter()
        {
            return this.password;
        }
        public void firstName_Setter(string a)
        {
            this.firstName = a;
        }
        public string firstName_Getter()
        {
            return this.firstName;
        }
        public void lastName_Setter(string a)
        {
            this.lastName = a;
        }
        public string lastName_Getter()
        {
            return this.lastName;
        }
        public void email_Setter(string a)
        {
            this.email = a;
        }
        public string email_Getter()
        {
            return this.email;
        }
        public void speciality_Setter(string a)
        {
            this.speciality = a;
        }
        public string speciality_Getter()
        {
            return this.speciality;
        }
        public void phoneNumber_Setter(string a)
        {
            this.phone_number = a;
        }
        public string phoneNumber_Getter()
        {
            return this.phone_number;
        }

    }
}