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
    public class ProductDal : ICrudOperation<Products>
    {
        SqlConnection _connection = new SqlConnection
               (@"server=(localdb)\mssqllocaldb;
                initial catalog=Northwind;
                 integrated security=true");

        public List<Products> GetAll()
        {
            ConnectionControl();

            SqlCommand cmd = new SqlCommand("Select * from Products", _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Products> products = new List<Products>();

            while (reader.Read())
            {
                Products product = new Products()
                {
                    ProductID = Convert.ToInt32(reader["ProductId"]),
                    ProductName = reader["ProductName"].ToString(),
                    QuantityPerUnit = reader["QuantityPerUnit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]),
                    UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]),
                    ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]),
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();

            return products;
        }

        public List<Products> GetOrderByToUnitsInStock()
        {
            ConnectionControl();

            SqlCommand cmd = new SqlCommand("select * from Products order by UnitsInStock desc", _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Products> products = new List<Products>();

            while (reader.Read())
            {
                Products product = new Products()
                {
                    ProductID = Convert.ToInt32(reader["ProductId"]),
                    ProductName = reader["ProductName"].ToString(),
                    QuantityPerUnit = reader["QuantityPerUnit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]),
                    UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]),
                    ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]),
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();

            return products;
        }

        public List<Products> GetOrderByToUnitsOnOrder()
        {
            ConnectionControl();

            SqlCommand cmd = new SqlCommand("select * from Products order by UnitsOnOrder desc", _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Products> products = new List<Products>();

            while (reader.Read())
            {
                Products product = new Products()
                {
                    ProductID = Convert.ToInt32(reader["ProductId"]),
                    ProductName = reader["ProductName"].ToString(),
                    QuantityPerUnit = reader["QuantityPerUnit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]),
                    UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]),
                    ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]),
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();

            return products;
        }

        public List<Products> GetOrderByToUnitPrice()
        {
            ConnectionControl();

            SqlCommand cmd = new SqlCommand("select * from Products order by UnitPrice desc", _connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Products> products = new List<Products>();

            while (reader.Read())
            {
                Products product = new Products()
                {
                    ProductID = Convert.ToInt32(reader["ProductId"]),
                    ProductName = reader["ProductName"].ToString(),
                    QuantityPerUnit = reader["QuantityPerUnit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]),
                    UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]),
                    ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]),
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();

            return products;
        }

        public List<Products> GetByProductNameList(string ProductName)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand("select * from Products where ProductName=@ProductName", _connection);
            sqlCommand.Parameters.AddWithValue("@ProductName", ProductName);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            List<Products> products = new List<Products>();

            while (reader.Read())
            {
                Products product = new Products()
                {
                    ProductID = Convert.ToInt32(reader["ProductId"]),
                    ProductName = reader["ProductName"].ToString(),
                    QuantityPerUnit = reader["QuantityPerUnit"].ToString(),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                    UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]),
                    UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]),
                    ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]),
                };
                products.Add(product);
            }

            reader.Close();
            _connection.Close();

            return products;
        }



        public void Add(Products product)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Insert into Products values(@ProductName,@QuantityPerUnit,@UnitsInStock)", _connection);
            sqlCommand.Parameters.AddWithValue("@name", product.ProductName);
            sqlCommand.Parameters.AddWithValue("@unitPrice", product.QuantityPerUnit);
            sqlCommand.Parameters.AddWithValue("@stockAmount", product.UnitPrice);
            sqlCommand.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand sqlCommand = new SqlCommand("Delete from customers Where ProductId=@ProductId", _connection);
            sqlCommand.Parameters.AddWithValue("@ProductId", id);

            sqlCommand.ExecuteNonQuery();
            _connection.Close();
        }


        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

    }
}
