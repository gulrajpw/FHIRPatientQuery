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
        string FHIRendpoint = "http://spark-dstu2.furore.com/fhir"; //http://spark.furore.com/fhir

      
        internal void FetchQueryResults(string userQuery)
        {
            //Hit the endpoint URL and fill into ViewBag when done. 
            
                if (userQuery != null)
                {
                    var endpoint = new Uri(FHIRendpoint);
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
            if (returnedPatients.Count > 0)
            {
               foreach (Patient p in returnedPatients)
                {
                    String displayPatient = "Firstname: " + p.Name.First() + "| Lastname:" + p.Name.Last() + " | Patient DOB: " + p.BirthDate;
                    displayPatients.Add(displayPatient);
                }
               
            }
            else
            {
                string error = "Search contains no current results";
                displayPatients.Add(error);

            }

            return displayPatients; 
        }






    }
}