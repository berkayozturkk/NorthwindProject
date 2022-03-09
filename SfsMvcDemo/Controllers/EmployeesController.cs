using SfsMvcDemo.Business.Concrete.ADO.Net;
using SfsMvcDemo.DataAcces.Concrete.ADO.Net;
using SfsMvcDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfsMvcDemo.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeesManager _employeesManager = new EmployeesManager();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult EmplooyeToList()
        {
            var data = _employeesManager.EmployeesList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EmplooyeToListLayoutIndex()
        {
            var data = _employeesManager.EmployeesList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddEmplooye(Employees employees)
        {
            _employeesManager.Add(employees);
            return View();  
        }

        public ActionResult DeleteEmplooye(int id)
        {
            _employeesManager.Delete(id);
            return View();
        }

        public JsonResult GetById(int id)
        {
            var data = _employeesManager.GetById(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}