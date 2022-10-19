using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient_History
{
    public class UpdateVisit
    {
        private VisitDB visitDB;
        private Visit visit;

        public UpdateVisit(Visit v)
        {
            this.visit = v;
        }
        public bool updateVisit()
        {
            visitDB = new VisitDB(visit);
            return visitDB.editVisit();

        }
    }
}