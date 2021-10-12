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
    public partial class frmInvoiceManagement : Form
    {
        int invoiceNo;
        public frmInvoiceManagement()
        {
            InitializeComponent();
        }

        private void BindGrid(List<Invoice> invoices)
        {
            ContextDB context = new ContextDB();
            dgvInvoice.Rows.Clear();
            int no = 1;
            foreach (var item in invoices)
            {
                int index = dgvInvoice.Rows.Add();
                dgvInvoice.Rows[index].Cells["No"].Value = no;
                dgvInvoice.Rows[index].Cells["InvoiceNo"].Value = item.InvoiceID;
                dgvInvoice.Rows[index].Cells["DateCheckOut"].Value = item.DateCheckOut.Date.ToString("dd/MM/yyyy");
                dgvInvoice.Rows[index].Cells["Employee"].Value = item.Employee.EmployeeName;
                no++;
            }
            CountInvoice();
        }
        private void CountInvoice()
        {
            int count = 0;
            for (int i = 0; i < dgvInvoice.RowCount; i++)
            {
                count++;
            }
            txtSum.Text = count.ToString();
        }
        private void chkViewAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewAll.Checked == true)
            {
                ContextDB context = new ContextDB();
                List<Invoice> invoices = context.Invoices.ToList();
                BindGrid(invoices);
            }
            else
                dgvInvoice.Rows.Clear();
        }

        private void frmInvoiceManagement_Load(object sender, EventArgs e)
        {
            CountInvoice();
            dtmViewDate.Enabled = false;
            dtmViewMonth.Enabled = false;
            dtmFromDate.Enabled = false;
            dtmToDate.Enabled = false;
            dtmViewDate.Value = DateTime.Now;
            dtmViewMonth.Value = DateTime.Now;
            dtmFromDate.Value = DateTime.Now;
            dtmToDate.Value = DateTime.Now;
        }

        private void rdoViewDate_CheckedChanged(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            if (rdoViewDate.Checked == true)
            {
                dtmViewDate.Enabled = true;
                var view = context.Invoices.Where(p => p.DateCheckOut == dtmViewDate.Value.Date).ToList();
                BindGrid(view);
            }
            else
                dtmViewDate.Enabled = false;

            if (rdoViewMonth.Checked == true)
            {
                dtmViewMonth.Enabled = true;
                var view = context.Invoices.Where(p => p.DateCheckOut.Month == dtmViewMonth.Value.Month && p.DateCheckOut.Year == dtmViewMonth.Value.Year).ToList();
                BindGrid(view);
            }
            else
                dtmViewMonth.Enabled = false;

            if (rdoDateToDate.Checked == true)
            {
                dtmFromDate.Enabled = true;
                dtmToDate.Enabled = true;
                var view = context.Invoices.Where(p => p.DateCheckOut >= dtmFromDate.Value.Date && p.DateCheckOut <= dtmToDate.Value.Date).ToList();
                BindGrid(view);
            }
            else
            {
                dtmFromDate.Enabled = false;
                dtmToDate.Enabled = false;
            }

        }

        private void dtmFromDate_ValueChanged(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            if (rdoViewDate.Checked == true)
            {
                var view = context.Invoices.Where(p => p.DateCheckOut == dtmViewDate.Value.Date).ToList();
                BindGrid(view);
            }

            if (rdoViewMonth.Checked == true)
            {
                var view = context.Invoices.Where(p => p.DateCheckOut.Month == dtmViewMonth.Value.Month && p.DateCheckOut.Year == dtmViewMonth.Value.Year).ToList();
                BindGrid(view);
            }

            if (rdoDateToDate.Checked == true)
            {
                if (dtmFromDate.Value.Date > dtmToDate.Value.Date)
                {
                    dtmFromDate.Value = dtmToDate.Value;
                }
                var view = context.Invoices.Where(p => p.DateCheckOut >= dtmFromDate.Value.Date && p.DateCheckOut <= dtmToDate.Value.Date).ToList();
                BindGrid(view);
            }
        }

        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            invoiceNo = Convert.ToInt32(dgvInvoice.SelectedRows[0].Cells["InvoiceNo"].Value);
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            if (invoiceNo <= 0)
            {
                MessageBox.Show("Chưa chọn đơn hàng");
            }
            else
            {
                frmViewInvoice frm = new frmViewInvoice(invoiceNo);
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
