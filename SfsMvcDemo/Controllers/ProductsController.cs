using SfsMvcDemo.Business.Concrete;
using SfsMvcDemo.Business.Concrete.ADO.Net;
using SfsMvcDemo.DataAcces.Concrete.ADO.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SfsMvcDemo.Controllers
{
    public class ProductsController : Controller
    {
        
        ProductsManager _productsManager = new ProductsManager();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductList()
        {
            var data = _productsManager.productsList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderByToUnitsInStock()
        {
            var data = _productsManager.GetOrderByToUnitsInStock();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderByToUnitsOnOrder()
        {
            var data = _productsManager.GetOrderByToUnitsOnOrder();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderByToUnitPrice()
        {
            var data = _productsManager.GetOrderByToUnitPrice();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByProductNameList(string ProductName)
        {
            var data = _productsManager.GetByProductNameList(ProductName);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}