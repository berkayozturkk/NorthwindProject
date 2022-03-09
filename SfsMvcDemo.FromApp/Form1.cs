using SfsMvcDemo.DataAcces.Concrete.ADO.Net;
using SfsMvcDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfsMvcDemo.FromApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EmployeesDal _employeesDal = new EmployeesDal();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _employeesDal.Add(new Employees
            {
                LastName = tbxLastName.Text,
                FirstName = tbxFirstName.Text,
                Title = tbxTitle.Text, 
                TitleOfCourtesy = tbxTitleOfCourtesy.Text,
                City = tbxCity.Text,
                Country = tbxCountry.Text,
            });

            LoadEmployees();

        }

        private void LoadEmployees()
        { 
            dgwEmployees.DataSource = _employeesDal.GetAll();
        }

        private void dgwEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgwEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxFirstNameUpdate.Text = dgwEmployees.CurrentRow.Cells[1].Value.ToString();
            tbxLastNameUpdate.Text = dgwEmployees.CurrentRow.Cells[2].Value.ToString();
            tbxTitleUpdate.Text = dgwEmployees.CurrentRow.Cells[3].Value.ToString();
            tbxTitleOfCourtesyUpdate.Text = dgwEmployees.CurrentRow.Cells[4].Value.ToString();
            tbxCityUpdate.Text = dgwEmployees.CurrentRow.Cells[5].Value.ToString();
            tbxCountryUpdate.Text = dgwEmployees.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _employeesDal.Update(new Employees
            {
                EmployeeID = Convert.ToInt32(dgwEmployees.CurrentRow.Cells[0].Value),
                LastName = tbxLastNameUpdate.Text,
                FirstName = tbxFirstNameUpdate.Text,
                Title = tbxTitleUpdate.Text,
                TitleOfCourtesy = tbxTitleOfCourtesyUpdate.Text,
                City = tbxCityUpdate.Text,
                Country = tbxCountryUpdate.Text,
            });
            LoadEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int EmployeeID = Convert.ToInt32(dgwEmployees.CurrentRow.Cells[0].Value);
            _employeesDal.Delete(EmployeeID);
            LoadEmployees();
        }
    }
}
