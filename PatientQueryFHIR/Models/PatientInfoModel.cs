using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace PatientQueryFHIR.Models
{
    public class PatientInfoModel
    {
        List<Patient> returnedPatients = new List<Patient>();
        int recordsCount;

        internal void FetchQueryResults(string userQuery)
        {
            //Hit the endpoint URL and fill into ViewBag when done. 
            
            if (userQuery != null)
            {
             // var endpoint = new Uri("http://spark.furore.com/fhir");
             var endpoint = new Uri("http://spark-dstu2.furore.com/fhir");
             var client = new FhirClient(endpoint);
             var query = new string[] { "name=" + userQuery };
             var bundle = client.Search("Patient", query);

              recordsCount = bundle.Entry.Count();
              foreach (var entry in bundle.Entry)
              {
                Patient p = (Patient)entry.Resource;
                returnedPatients.Add(p);
              }
           }
        }

        internal List<String> ReturnPatients()
        {
            List<String> displayPatients = new List<String>(); //Add just what we need to the ViewBag instead of the entire Patient model.
            if (returnedPatients != null)
            {
               foreach (Patient p in returnedPatients)
                {
                    String displayPatient = "Firstname: " + p.Name.First() + "| Lastname:" + p.Name.Last() + " | Patient DOB: " + p.BirthDate;
                    displayPatients.Add(displayPatient);
                }
               
            }
            
            return displayPatients;
        }






    }
}