using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmViewInvoice : Form
    {
        private int invoiceNo;

        public int InvoiceNo { get => invoiceNo; set => invoiceNo = value; }

        public frmViewInvoice(int invoiceNo)
        {
            this.InvoiceNo = invoiceNo;
            InitializeComponent();
        }

        public frmViewInvoice()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            ContextDB context = new ContextDB();
        }
        private void frmViewInvoice_Load(object sender, EventArgs e)
        {
            int countBook = 0;
            double sumCost = 0;
            ContextDB context = new ContextDB();
            txtInvoiceNo.Text = invoiceNo.ToString();
            var value = context.Invoices.Where(p => p.InvoiceID == invoiceNo).ToList();
            foreach (var item in value)
            {
                dtmDayCheckOut.Value = item.DateCheckOut;
                txtEmployee.Text = item.Employee.EmployeeName;
            }
            var grid = context.InvoiceInfoes.Where(p => p.InvoiceID == invoiceNo).ToList();
            dgvInvoiceDetail.Rows.Clear();
            foreach (var item in grid)
            {
                int index = dgvInvoiceDetail.Rows.Add();
                dgvInvoiceDetail.Rows[index].Cells["BookID"].Value = item.BookID;
                dgvInvoiceDetail.Rows[index].Cells["BookName"].Value = item.Book.BookName;
                dgvInvoiceDetail.Rows[index].Cells["Quantity"].Value = item.Count;
                dgvInvoiceDetail.Rows[index].Cells["Price"].Value = item.Book.Price;
                dgvInvoiceDetail.Rows[index].Cells["Cost"].Value = Convert.ToDouble(item.Count) * item.Book.Price;
            }
            for (int i = 0; i < dgvInvoiceDetail.RowCount; i++)
            {
                countBook += Convert.ToInt32(dgvInvoiceDetail.Rows[i].Cells["Quantity"].Value);
                sumCost += Convert.ToDouble(dgvInvoiceDetail.Rows[i].Cells["Cost"].Value);
            }
            txtCountBook.Text = countBook.ToString();
            txtSumCost.Text = sumCost.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportInvoice frm = new frmReportInvoice(invoiceNo);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
