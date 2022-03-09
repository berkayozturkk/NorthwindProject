using SfsMvcDemo.DataAcces.Concrete.ADO.Net;
using SfsMvcDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfsMvcDemo.Business.Concrete.ADO.Net
{
    public class CustomersManager
    {
        CustomersDal _customersDal = new CustomersDal();
        
        public List<Customers> customersList()
        {
            return _customersDal.GetAll();
        }

        public void Add(Customers customers)
        {
            _customersDal.Add(customers);
        }

        public void Delete(string id)
        {
            _customersDal.Delete(id);
        }

        public List<Customers> GetByCustomers(string CompanyName, string ContactName, string ContactTitle)
        {
            return _customersDal.GetByCustomers(CompanyName, ContactName, ContactTitle);
        }

        public List<Customers> GetCountryList()
        {
            return _customersDal.GetCountryList();
        }
    }
}
