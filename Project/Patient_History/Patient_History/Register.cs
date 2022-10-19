using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_History
{

    public class Register
    {

        private DoctorDB doctorDB;
        private Doctor doctor;
        public Register(Doctor d)
        {

            this.doctor = d;
        }

        public bool createNewDoctor()
        {
            doctorDB = new DoctorDB(doctor);
            return doctorDB.insertDoctor();
        }
    }
}