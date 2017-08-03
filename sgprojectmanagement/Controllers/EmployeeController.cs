using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sgprojectmanagement.Services;
using sgprojectmanagement.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sgprojectmanagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IemployeeProfile _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeProfileService();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public string Get(string id)
        {
            var EmployeeProfile = _employeeService.Get(id);
            //if (EmployeeProfile != null)
            //{
               
            //}
            return JsonConvert.SerializeObject(EmployeeProfile);
            //else
            //{
            //    return HttpContext.Response;
            //}
        }
        //public string Add(string value)
        //{
        //    var EmployeeProfile = _employeeService.Insert( new EmployeeProfile() { })
        //    //if (EmployeeProfile != null)
        //    //{

        //    //}
        //    return JsonConvert.SerializeObject(EmployeeProfile);
        //    //else
        //    //{
        //    //    return HttpContext.Response;
        //    //}
        //}
        //public string Get(string id)
        //{
        //    var EmployeeProfile = _employeeService.Get(id);
        //    //if (EmployeeProfile != null)
        //    //{

        //    //}
        //    return JsonConvert.SerializeObject(EmployeeProfile);
        //    //else
        //    //{
        //    //    return HttpContext.Response;
        //    //}
        //}
        //public string Get(string id)
        //{
        //    var EmployeeProfile = _employeeService.Get(id);
        //    //if (EmployeeProfile != null)
        //    //{

        //    //}
        //    return JsonConvert.SerializeObject(EmployeeProfile);
        //    //else
        //    //{
        //    //    return HttpContext.Response;
        //    //}
        //}
        //public string Get(string id)
        //{
        //    var EmployeeProfile = _employeeService.Get(id);
        //    //if (EmployeeProfile != null)
        //    //{

        //    //}
        //    return JsonConvert.SerializeObject(EmployeeProfile);
        //    //else
        //    //{
        //    //    return HttpContext.Response;
        //    //}
        //}
    }
}
