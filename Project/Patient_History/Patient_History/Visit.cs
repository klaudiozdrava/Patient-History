using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_History
{
    public class Visit
    {
		private string patient_AMKA;
		private DateTime visit_date;
		private string doctor_amka;
		private string disease;
		private string symptom;
		private string vaccine;
		private string report;
		private string treatment;
		private string status;
		public void patient_AMKA_Setter(string a)
		{
			this.patient_AMKA = a;
		}
		public string patient_AMKA_Getter()
		{
			return this.patient_AMKA;
		}
		public DateTime Visit_Date
		{
			get => visit_date;
			set => visit_date = value;
		}
		public void doctorAMKA_Setter(string a)
		{
			this.doctor_amka = a;
		}
		public string doctorAMKA_Getter()
		{
			return this.doctor_amka;
		}
		public void disease_Setter(string a)
		{
			this.disease = a;
		}
		public string disease_Getter()
		{
			return this.disease;
		}
		public void symptom_Setter(string a)
		{
			this.symptom = a;
		}
		public string symptom_Getter()
		{
			return this.symptom;
		}
		public void vaccine_Setter(string a)
		{
			this.vaccine = a;
		}
		public string vaccine_Getter()
		{
			return this.vaccine;
		}
		public void report_Setter(string a)
		{
			this.report = a;
		}
		public string report_Getter()
		{
			return this.report;
		}
		public void treatment_Setter(string a)
		{
			this.treatment = a;
		}
		public string treatment_Getter()
		{
			return this.treatment;
		}
		public void status_Setter(string a)
		{
			this.status = a;
		}
		public string status_Getter()
		{
			return this.status;
		}
	}
}