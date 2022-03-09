using SfsMvcDemo.DataAcces.Concrete.ADO.Net;
using SfsMvcDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfsMvcDemo.Business.Concrete.ADO.Net
{
    public class EmployeesManager
    {
        EmployeesDal _employeesDal = new EmployeesDal();

        public List<Employees> EmployeesList()
        {
            return _employeesDal.GetAll();
        }
        
        public void Add(Employees employees)
        {
             _employeesDal.Add(employees);
        }

        public void Update(Employees employees)
        {
            _employeesDal.Update(employees);
        }

        public void Delete(int id)
        {
            _employeesDal.Delete(id);
        }

        public List<Employees> GetById(int id)
        {
            return _employeesDal.GetById(id);
        }

        public void GetByName(string lastName,string firstName)
        {
            _employeesDal.GetByName(lastName,firstName);
        }
    }
}
