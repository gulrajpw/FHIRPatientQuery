using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientQueryFHIR.Models
{
    public class PatientInfoModel
    {
        internal void FetchQueryResults(string userQuery)
        {
            //Hit the endpoint URL and fill into ViewBag when done. 
            string search = userQuery;
        }
    }
}