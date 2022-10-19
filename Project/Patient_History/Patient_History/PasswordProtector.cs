using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Patient_History
{
    public class PasswordProtector //it contains the properties(get,set) of string hashedPassword used to hash the password
    {
        private string hashedPassword;
        public string hashedPassword_Getter()
        {
            return this.hashedPassword;
        }

        public void hashedPassword_setter(string a)
        {
            //The below code was taken from: https://stackoverflow.com/questions/20516618/ruby-sha-and-hash-to-c-sharp 
            //Computes the hash code of the password
            var sha1 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(a);
            var hashBytes = sha1.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder(); //it saves the hashed bytes in a string form
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2")); //X2 converts it to upper-case 

            }
            this.hashedPassword = sb.ToString();
        }
    }
}