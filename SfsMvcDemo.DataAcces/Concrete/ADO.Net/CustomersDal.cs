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
    public class CustomersDal : ICrudOperation<Customers>
    {
        SqlConnection _connection = new SqlConnection
      (@"server=(localdb)\mssqllocaldb;
                initial catalog=Northwind;
                 integrated security=true");

        public List<Customers> GetAll()
        {
            ConnectionControl();

            SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMERS", _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Customers> customersList = new List<Customers>();

            while (reader.Read())
            {
                Customers customers = new Customers()
                {
                    //  CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    CustomerID = reader["CustomerID"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),
                    ContactName = reader["ContactName"].ToString(),
                    ContactTitle = reader["ContactTitle"].ToString(),
                    Address = reader["Address"].ToString(),
                    City = reader["City"].ToString(),
                    Region = reader["Region"].ToString(),
                    Country = reader["Country"].ToString(),
                    Phone = reader["Phone"].ToString(),
                };
                customersList.Add(customers);
            }

            reader.Close();
            _connection.Close();

            return customersList;
        }

        public void Add(Customers p)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("insert into CUSTOMERS(CUSTOMERID,COMPANYNAME,CONTACTNAME,CONTACTTITLE,[ADDRESS],CITY,REGION,COUNTRY,PHONE) VALUES('@CUSTOMERID', '@COMPANYNAME', '@CONTACTNAME', '@CONTACTTITLE', '@ADDRESS', '@CITY', '@REGION', '@COUNTRY', '@PHONE')", _connection);
            sqlCommand.Parameters.AddWithValue("@CUSTOMERID", p.CustomerID);
            sqlCommand.Parameters.AddWithValue("@COMPANYNAME", p.ContactName);
            sqlCommand.Parameters.AddWithValue("@CONTACTNAME", p.ContactName);
            sqlCommand.Parameters.AddWithValue("@CONTACTTITLE", p.ContactTitle);
            sqlCommand.Parameters.AddWithValue("@ADDRESS", p.Address);
            sqlCommand.Parameters.AddWithValue("@CITY", p.City);
            sqlCommand.Parameters.AddWithValue("@REGION", p.Region);
            sqlCommand.Parameters.AddWithValue("@COUNTRY", p.Country);
            sqlCommand.Parameters.AddWithValue("@PHONE", p.Phone);
            sqlCommand.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(string id)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Delete from customers Where CustomerID=@CustomerID", _connection);
            sqlCommand.Parameters.AddWithValue("@CustomerID", id);

            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GetById(string id)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Select from customers Where CustomerID=@CustomerID", _connection);
            sqlCommand.Parameters.AddWithValue("@CustomerID", id);

            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }

        public List<Customers> GetByCustomers(string CompanyName,string ContactName,string ContactTitle)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand("select * from customers where CompanyName=@CompanyName or ContactName=@ContactName or ContactTitle=@ContactTitle", _connection);
            sqlCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
            sqlCommand.Parameters.AddWithValue("@ContactName", ContactName);
            sqlCommand.Parameters.AddWithValue("@ContactTitle", ContactTitle);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Customers> customersList = new List<Customers>();

            while (reader.Read())
            {
                Customers customers = new Customers()
                {
                    //  CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    CustomerID = reader["CustomerID"].ToString(),
                    CompanyName = reader["CompanyName"].ToString(),
                    ContactName = reader["ContactName"].ToString(),
                    ContactTitle = reader["ContactTitle"].ToString(),
                    Address = reader["Address"].ToString(),
                    City = reader["City"].ToString(),
                    Region = reader["Region"].ToString(),
                    Country = reader["Country"].ToString(),
                    Phone = reader["Phone"].ToString(),
                };
                customersList.Add(customers);
            }

            reader.Close();
            _connection.Close();

            return customersList;
        }

        public List<Customers> GetCountryList()
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand("select DISTINCT(Country) from Customers", _connection);
  
            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Customers> customersList = new List<Customers>();

            while (reader.Read())
            {
                Customers customers = new Customers()
                {
                    Country = reader["Country"].ToString(),
                   
                };
                customersList.Add(customers);
            }

            reader.Close();
            _connection.Close();

            return customersList;
        }



        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

    }
}
