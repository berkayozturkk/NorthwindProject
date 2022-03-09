using SfsMvcDemo.Business.Concrete.ADO.Net;
using SfsMvcDemo.DataAcces.Concrete.ADO.Net;
using SfsMvcDemo.Entity.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Web.Mvc;

namespace SfsMvcDemo.Controllers
{
    public class CustomersController : Controller
    {
        CustomersManager _customersManager = new CustomersManager();
        CustomersDal _customersDal = new CustomersDal();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CustomersToList()
        {
            var data = _customersManager.customersList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByCustomers(string CompanyName, string ContactName, string ContactTitle)
        {
            var data = _customersDal.GetByCustomers(CompanyName, ContactName, ContactTitle);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCountryList()
        {
            var data = _customersManager.GetCountryList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
           
        public ActionResult AddCustomers(Customers customers)
        {
            _customersManager.Add(customers);
            return View();
        }

        public ActionResult DeleteCustomers(string id)
        {
            _customersManager.Delete(id);
            return View();
        }
    }
}