using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientQueryFHIR.Models;

namespace PatientQueryFHIR.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PatientInfoForm(string patientQuery)
        {
           
            if (isHostAvailable())
            {
                PatientInfoModel patientVM = new PatientInfoModel();

                if (patientQuery != null)
                {
                    patientVM.FetchQueryResults(patientQuery);

                }
                ViewBag.ReturnedResults = patientVM.ReturnPatients();
            }
            else
            {
                List<string> errorMessage = new List<string>();
                string endpointDownMsg = "FHIR endpoint is down. We apologize for the inconvenience";
                errorMessage.Add(endpointDownMsg);
                ViewBag.ReturnedResults = errorMessage; //Re use the existing returned results field to raise error message.
            }

            return View();
        }

        public bool isHostAvailable() //Before we do anything, let's make sure the endpoint is available. 
        {
            try
            {
                var ping = new System.Net.NetworkInformation.Ping();
                // var result = ping.Send("http://spark-dstu2.furore.com/fhir");
                var result = ping.Send("http://spark.furore.com/fhir");
                return (result.Status != System.Net.NetworkInformation.IPStatus.Success) ? false : true;
            }
            catch (Exception)
            {
                return false; //If anything is returned other than Success, endpoint is not available.
            }
        }


    }
}