using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace PatientQueryFHIR.Models
{
    public class PatientInfoModel
    {
       private List<Patient> returnedPatients = new List<Patient>();
       
       private string _userQuery { get; set; }



        
        internal void FetchQueryResults(string userQuery)
        {
            //Hit the endpoint URL and fill into ViewBag when done. 
                if (!String.IsNullOrEmpty(userQuery))
                {
                _userQuery = userQuery;
                  var fhirEndpoint = new FhirClient("http://hapi.fhir.org/baseDstu2");
               // var fhirEndpoint = new FhirClient("http://spark-dstu2.furore.com/fhir");

                string completeQuery = "name=" + userQuery;
                var query = new SearchParams().Where(completeQuery);

                
                var bundle = fhirEndpoint.Search<Patient>(query);

                    foreach (var entry in bundle.Entry)
                    {
                        Patient p = (Patient)entry.Resource;
                        returnedPatients.Add(p);
                    }
                }   
        }

        internal List<String> FormatResultsToUser()
        {
            List<String> displayPatients = new List<String>(); //Add just what we need to the ViewBag instead of the entire Patient model.
            if (returnedPatients.Count > 0)
            {
               foreach (Patient p in returnedPatients)
                {
                    String displayPatient = "Patient ID: " + p.Id + "\r\n | Firstname: " + p.Name.First() + " | Lastname: " + p.Name.Last() + " | Patient DOB: " + p.BirthDate;
                    displayPatients.Add(displayPatient);
                }
               
            }
            else
            {
                if (!string.IsNullOrEmpty(_userQuery))
                {
                    string error = "Search contains no current results";
                    displayPatients.Add(error);
                }
            }

            return displayPatients; 
        }
        
    }
}