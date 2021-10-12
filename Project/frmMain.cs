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
    public partial class frmMain : Form
    {
        private int employeeID;
        private string displayName;
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string DisplayName { get => displayName; set => displayName = value; }

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(int employeeID, string displayName)
        {
            this.employeeID = employeeID;
            this.displayName = displayName; 
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateOrder frm = new frmCreateOrder(employeeID);
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblDisplayName.Text = "Xin chào, " + displayName;
        }

        private void btnOrderManagement_Click(object sender, EventArgs e)
        {
            frmInvoiceManagement frm = new frmInvoiceManagement();
            frm.ShowDialog();
        }

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            frmBookManagement frm = new frmBookManagement();
            frm.ShowDialog();
        }

        private void btnCategoryManagement_Click(object sender, EventArgs e)
        {
            frmCategoryManagement frm = new frmCategoryManagement();
            frm.ShowDialog();
        }

        private void btnAuthorManagement_Click(object sender, EventArgs e)
        {
            frmAuthorManagement frm = new frmAuthorManagement();
            frm.ShowDialog();
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            frmAccountInfo frm = new frmAccountInfo(employeeID);
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmployeeInfo_Click(object sender, EventArgs e)
        {
            frmViewEmployee frm = new frmViewEmployee();
            frm.ShowDialog();
        }
    }
}
