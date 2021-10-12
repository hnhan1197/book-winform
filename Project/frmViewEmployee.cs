using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Models;

namespace Project
{
    public partial class frmViewEmployee : Form
    {
        public frmViewEmployee()
        {
            InitializeComponent();
        }
        private void BindGrid(List<Employee> employees)
        {
            dgvEmployee.Rows.Clear();
            foreach (var item in employees)
            {
                int index = dgvEmployee.Rows.Add();
                dgvEmployee.Rows[index].Cells["EmployeeID"].Value = item.EmployeeID;
                dgvEmployee.Rows[index].Cells["EmployeeName"].Value = item.EmployeeName;
                dgvEmployee.Rows[index].Cells["Birthday"].Value = item.Birthday.Value.Date.ToString("dd/MM/yyyy");
                dgvEmployee.Rows[index].Cells["NumberPhone"].Value = item.NumberPhone;
                dgvEmployee.Rows[index].Cells["Address"].Value = item.Address;
            }
            CountEmployee();
        }
        private void LoadData()
        {
            ContextDB context = new ContextDB();
            List<Employee> employees = context.Employees.ToList();
            BindGrid(employees);
        }
        private void CountEmployee()
        {
            int count = 0;
            for (int i = 0; i < dgvEmployee.Rows.Count; i++)
            {
                count++;
            }
            txtSum.Text = count.ToString();
        }
        private void frmViewEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            if (txtEmployeeID.Text != "")
            {
                var query = context.Employees.Where(p => p.EmployeeID.ToString() == txtEmployeeID.Text).ToList();
                BindGrid(query);
            }
            ResetInput();
        }

        private void ResetInput()
        {
            txtEmployeeID.Clear();
            txtEmployeeName.Clear();
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            if (txtEmployeeName.Text != "")
            {
                var query = context.Employees.Where(p => p.EmployeeName.ToLower().Contains(txtEmployeeName.Text.ToLower())).ToList();
                BindGrid(query);
            }
            ResetInput();
        }


        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmployeeID.Text = dgvEmployee.SelectedRows[0].Cells["EmployeeID"].Value.ToString();
            txtEmployeeName.Text = dgvEmployee.SelectedRows[0].Cells["EmployeeName"].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
