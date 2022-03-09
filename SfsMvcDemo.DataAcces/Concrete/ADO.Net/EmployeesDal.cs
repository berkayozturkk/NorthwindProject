using SfsMvcDemo.DataAcces.Abstract;
using SfsMvcDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfsMvcDemo.DataAcces.Concrete.ADO.Net
{
    public class EmployeesDal 
    {
        SqlConnection _connection = new SqlConnection
       (@"server=(localdb)\mssqllocaldb;
                initial catalog=Northwind;
                 integrated security=true");

        public List<Employees> GetAll()
        {
            ConnectionControl();

            SqlCommand cmd = new SqlCommand("SELECT * FROM EMPLOYEES", _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Employees> employeesList = new List<Employees>();

            while (reader.Read())
            {
                Employees employees = new Employees()
                {
                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                    LastName = reader["LastName"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    Title = reader["Title"].ToString(),
                    TitleOfCourtesy = reader["TitleOfCourtesy"].ToString(),
                    City = reader["City"].ToString(),
                    Country = reader["Country"].ToString(),
                };
                employeesList.Add(employees);
            }

            reader.Close();
            _connection.Close();

            return employeesList;
        }

        public void Add(Employees employees)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("insert into EMPLOYEES(LASTNAME,FIRSTNAME,TITLE,TITLEOFCOURTESY,CITY,COUNTRY) VALUES(@LASTNAME,@FIRSTNAME,@TITLE,@TITLEOFCOURTESY,@CITY,@COUNTRY)", _connection);
            sqlCommand.Parameters.AddWithValue("@LASTNAME", employees.LastName);
            sqlCommand.Parameters.AddWithValue("@FIRSTNAME", employees.FirstName);
            sqlCommand.Parameters.AddWithValue("@TITLE", employees.Title);
            sqlCommand.Parameters.AddWithValue("@TITLEOFCOURTESY", employees.TitleOfCourtesy);
            sqlCommand.Parameters.AddWithValue("@CITY", employees.City);
            sqlCommand.Parameters.AddWithValue("@COUNTRY", employees.Country);
            sqlCommand.ExecuteNonQuery();

            _connection.Close();
        }

        public void Update(Employees employees)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Update Products Set LastName=@LASTNAME,FirstName=@FIRSTNAME,Title=@TITLE,TitleOfCourtesy=@TITLEOFCOURTESY,City=@City,COUNTRY=@Country Where EmployeeId=@EmployeeId", _connection);
            sqlCommand.Parameters.AddWithValue("@EmployeeId", employees.EmployeeID);
            sqlCommand.Parameters.AddWithValue("@LASTNAME", employees.LastName);
            sqlCommand.Parameters.AddWithValue("@FIRSTNAME", employees.FirstName);
            sqlCommand.Parameters.AddWithValue("@TITLE", employees.Title);
            sqlCommand.Parameters.AddWithValue("@TITLEOFCOURTESY", employees.TitleOfCourtesy);
            sqlCommand.Parameters.AddWithValue("@CITY", employees.City);
            sqlCommand.Parameters.AddWithValue("@COUNTRY", employees.Country);
            sqlCommand.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Delete from Employees Where EmployeeID=@EmployeeID", _connection);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", id);
            
            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }

        public List<Employees> GetById(int id)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Select from Employees Where EmployeeID=@EmployeeID", _connection);
            sqlCommand.Parameters.AddWithValue("@EmployeeID", id);

            sqlCommand.ExecuteNonQuery();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Employees> employeesList = new List<Employees>();

            while (reader.Read())
            {
                Employees employees = new Employees()
                {
                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                    LastName = reader["LastName"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    Title = reader["Title"].ToString(),
                    TitleOfCourtesy = reader["TitleOfCourtesy"].ToString(),
                    City = reader["City"].ToString(),
                    Country = reader["Country"].ToString(),
                };
                employeesList.Add(employees);
            }

            reader.Close();
            _connection.Close();

            return employeesList;
        }

        public List<Employees> GetByName(string lastName,string firstName)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Select from Employees Where lastName=@lastName or firstName=@firstName", _connection);
            sqlCommand.Parameters.AddWithValue("@lastName", lastName);
            sqlCommand.Parameters.AddWithValue("@FirstName", firstName);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Employees> employeesList = new List<Employees>();

            while (reader.Read())
            {
                Employees employees = new Employees()
                {
                    EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                    LastName = reader["LastName"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    Title = reader["Title"].ToString(),
                    TitleOfCourtesy = reader["TitleOfCourtesy"].ToString(),
                    City = reader["City"].ToString(),
                    Country = reader["Country"].ToString(),
                };
                employeesList.Add(employees);
            }

            reader.Close();
            _connection.Close();

            return employeesList;
           
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

    }
}
