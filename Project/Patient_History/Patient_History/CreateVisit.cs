using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_History
{
    public class CreateVisit
    {
        private VisitDB visitDB;
        private Visit visit;

        public CreateVisit(Visit v)
        {
            this.visit = v;
        }
        public bool CreateNewVisit()
        {
            visitDB = new VisitDB(visit);
            return visitDB.insertVisit();
        }
    }
}