using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.Models;

namespace Project
{
    public partial class frmAccountInfo : Form
    {
        private int employeeID;

        public frmAccountInfo(int employeeID)
        {
            this.employeeID = employeeID;
            InitializeComponent();
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }

        public frmAccountInfo()
        {
            InitializeComponent();
        }

        private void frmAccountInfo_Load(object sender, EventArgs e)
        {
            txtPassword.Enabled = false;
            ContextDB context = new ContextDB();
            var info = context.Accounts.Where(p => p.EmployeeID == employeeID).ToList();
            foreach (var item in info)
            {
                txtEmployeeID.Text = item.EmployeeID.ToString();
                txtEmployName.Text = item.Employee.EmployeeName;
                txtDisplayName.Text = item.DisplayName;
                dtmBirthday.Value = item.Employee.Birthday.Value;
                txtNumberPhone.Text = item.Employee.NumberPhone;
                txtAddress.Text = item.Employee.Address;
                txtPassword.Text = item.Password;
            }
        }

        private void btnPasswordChanged_Click(object sender, EventArgs e)
        {
            txtPassword.Enabled = !txtPassword.Enabled;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                Account account = context.Accounts.FirstOrDefault(p => p.EmployeeID.ToString() == txtEmployeeID.Text);
                account.Employee.EmployeeName = txtEmployName.Text;
                account.DisplayName = txtDisplayName.Text;
                account.Employee.Birthday = dtmBirthday.Value;
                account.Employee.NumberPhone = txtNumberPhone.Text;
                account.Employee.Address = txtAddress.Text;
                account.Password = txtPassword.Text;
                context.Accounts.AddOrUpdate(account);
                context.SaveChanges();
                MessageBox.Show(" Thông tin của bạn sẽ được cập nhật sau khi đăng xuất", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
                txtPassword.UseSystemPasswordChar = false;
            else
                txtPassword.UseSystemPasswordChar = true;
        }
    }
}
