using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Project.Models;
namespace Project
{
    public partial class frmReportInvoice : Form
    {
        private int invoiceNo;

        public frmReportInvoice(int invoiceNo)
        {
            this.invoiceNo = invoiceNo;
            InitializeComponent();
        }

        public frmReportInvoice()
        {
            InitializeComponent();
        }

        public int InvoiceNo { get => invoiceNo; set => invoiceNo = value; }

        private void frmReportInvoice_Load(object sender, EventArgs e)
        {
            double sum = 0 ;
            ContextDB context = new ContextDB();
            Invoice invoiceInfo = context.Invoices.FirstOrDefault(p => p.InvoiceID == invoiceNo);
            List<InvoiceInfo> infos = context.InvoiceInfoes.Where(p => p.InvoiceID == invoiceNo).ToList();
            List<InvoiceReport> invoiceReports = new List<InvoiceReport>();
            foreach (var item in infos)
            {
                InvoiceReport invoice = new InvoiceReport();
                invoice.BookID = item.BookID;
                invoice.BookName = item.Book.BookName;
                invoice.Quantity = item.Count;
                invoice.Price = item.Book.Price;
                sum += Convert.ToDouble(item.Count) * item.Book.Price;
                invoiceReports.Add(invoice);
            }

            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter("InvoiceNo", invoiceInfo.InvoiceID.ToString());
            param[1] = new ReportParameter("DateCheckOut", invoiceInfo.DateCheckOut.Date.ToString("dd/MM/yyyy"));
            param[2] = new ReportParameter("EmployeeName", invoiceInfo.Employee.EmployeeName);
            param[3] = new ReportParameter("Cost", sum.ToString());
            this.rpvInvoice.LocalReport.ReportPath = "rptInvoiceDetail.rdlc";
            this.rpvInvoice.LocalReport.SetParameters(param);
            ReportDataSource dataSource = new ReportDataSource("InvoiceDataSet", invoiceReports);
            this.rpvInvoice.LocalReport.DataSources.Clear();
            this.rpvInvoice.LocalReport.DataSources.Add(dataSource);
            this.rpvInvoice.LocalReport.DisplayName = "Hoá đơn mua sách";
            this.rpvInvoice.RefreshReport();
        }
    }
}
