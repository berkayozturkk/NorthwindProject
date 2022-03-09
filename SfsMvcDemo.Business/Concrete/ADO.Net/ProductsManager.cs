using SfsMvcDemo.DataAcces.Concrete.ADO.Net;
using SfsMvcDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfsMvcDemo.Business.Concrete.ADO.Net
{
    public class ProductsManager
    {
        ProductDal _productsDal = new ProductDal();
        
        public List<Products> productsList()
        {
            return _productsDal.GetAll();
        }

        public List<Products> GetOrderByToUnitsInStock()
        {
            return _productsDal.GetOrderByToUnitsInStock();
        }

        public List<Products> GetOrderByToUnitsOnOrder()
        {
            return _productsDal.GetOrderByToUnitsOnOrder();
        }

        public List<Products> GetOrderByToUnitPrice()
        {
            return _productsDal.GetOrderByToUnitPrice();
        }

        public List<Products> GetByProductNameList(string ProductName)
        {
            return _productsDal.GetByProductNameList(ProductName);
        }

        public void Add(Products product)
        {
            _productsDal.Add(product);
        }

        public void Delete(int id)
        {
            _productsDal.Delete(id);
        }
    }
}
