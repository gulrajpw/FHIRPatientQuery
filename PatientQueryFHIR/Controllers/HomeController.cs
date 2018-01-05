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
            
            PatientInfoModel patientVM = new PatientInfoModel();
            if (patientQuery != null)
            {
                patientVM.FetchQueryResults(patientQuery);

            }
                ViewBag.ReturnedResults = patientVM.ReturnPatients();

            return View();
        }

    }
}