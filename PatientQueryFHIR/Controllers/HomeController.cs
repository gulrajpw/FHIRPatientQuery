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
            ViewBag.PatientQuery = patientQuery;
            PatientInfoModel patientVM = new PatientInfoModel();
            patientVM.FetchQueryResults(patientQuery);
            return View();
        }

    }
}