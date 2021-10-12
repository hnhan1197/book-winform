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
    public partial class frmCreateOrder : Form
    {
        private int employeeID;

        public int EmployeeID { get => employeeID; set => employeeID = value; }

        public frmCreateOrder(int employeeID)
        {
            this.EmployeeID = employeeID;
            InitializeComponent();
        }

        public frmCreateOrder()
        {
            InitializeComponent();
        }

        private void BindGrid(List<Book> books)
        {
            dgvBook.Rows.Clear();
            foreach (var item in books)
            {
                int index = dgvBook.Rows.Add();
                dgvBook.Rows[index].Cells["BookID"].Value = item.BookID;
                dgvBook.Rows[index].Cells["BookName"].Value = item.BookName;
                dgvBook.Rows[index].Cells["CategoryName"].Value = item.Category.CategoryName;
                dgvBook.Rows[index].Cells["AuthorName"].Value = item.Author.AuthorName;
                dgvBook.Rows[index].Cells["Price"].Value = item.Price;
            }
        }

        private void LoadData()
        {
            ContextDB context = new ContextDB();
            List<Book> books = context.Books.ToList();
            BindGrid(books);
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nudQuantity.Enabled = true;
            ContextDB context = new ContextDB();
            txtBookID.Text = dgvBook.SelectedRows[0].Cells["BookID"].Value.ToString();
            txtBookName.Text = dgvBook.SelectedRows[0].Cells["BookName"].Value.ToString();
            txtCategory.Text = dgvBook.SelectedRows[0].Cells["CategoryName"].Value.ToString();
            txtAuthor.Text = dgvBook.SelectedRows[0].Cells["AuthorName"].Value.ToString();
            txtPrice.Text = dgvBook.SelectedRows[0].Cells["Price"].Value.ToString();
            var db = context.Books.Where(p => p.BookID == txtBookID.Text).ToList();
            foreach (var item in db)
            {
                txtQuantity.Text = item.QuantityInStock.ToString();
            }
        }
        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCreateOrder_Load(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            LoadData();
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 1000;
            nudQuantity.Enabled = false;
        }
        private int getSelectedRow(string bookID)
        {
            for (int i = 0; i < dgvCart.Rows.Count; i++)
            {
                if (dgvCart.Rows[i].Cells[0].Value?.ToString() == bookID)
                {
                    return i;
                }

            }
            return -1;
        }
        private void InsertUpdate(int selectedRow)
        {
            dgvCart.Rows[selectedRow].Cells["IdOfBook"].Value = txtBookID.Text;
            dgvCart.Rows[selectedRow].Cells["NameOfBook"].Value = txtBookName.Text;
            dgvCart.Rows[selectedRow].Cells["Category"].Value = txtCategory.Text;
            dgvCart.Rows[selectedRow].Cells["Quantity"].Value = nudQuantity.Value;
            dgvCart.Rows[selectedRow].Cells["SellPrice"].Value = txtPrice.Text;
        }
        private void PaymentAmount()
        {
            int sum = 0;
            for (int i = 0; i < dgvCart.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dgvCart.Rows[i].Cells["Quantity"].Value) * Convert.ToInt32(dgvCart.Rows[i].Cells["SellPrice"].Value);
            }
            txtSum.Text = sum.ToString();
        }
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = getSelectedRow(txtBookID.Text);


                if (nudQuantity.Value > Convert.ToInt32(txtQuantity.Text))
                {
                    nudQuantity.Value = Convert.ToInt32(txtQuantity.Text);
                    throw new Exception("Không đủ lượng sách trong kho, vui lòng chọn lại!!");
                }
                else if (selectedRow == -1)
                {
                    selectedRow = dgvCart.Rows.Add();
                    InsertUpdate(selectedRow);
                }
                else
                {
                    InsertUpdate(selectedRow);
                }
                PaymentAmount();
                nudQuantity.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCart.SelectedRows)
            {
                dgvCart.Rows.RemoveAt(row.Index);
            }
            PaymentAmount();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvCart.Rows.Clear();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            var search = context.Books.Where(p => p.BookName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            dgvBook.Rows.Clear();
            foreach (var item in search)
            {
                int index = dgvBook.Rows.Add();
                dgvBook.Rows[index].Cells["BookID"].Value = item.BookID;
                dgvBook.Rows[index].Cells["BookName"].Value = item.BookName;
                dgvBook.Rows[index].Cells["CategoryName"].Value = item.Category.CategoryName;
                dgvBook.Rows[index].Cells["AuthorName"].Value = item.Author.AuthorName;
                dgvBook.Rows[index].Cells["Price"].Value = item.Price;
            }
            txtSearch.Clear();
        }

        private void btnInvoicing_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                if (dgvCart.Rows.Count == 0)
                {
                    throw new Exception("Không thể lập hoá đơn vì không có gì trong giỏ hàng!!");
                }

                if (MessageBox.Show("Bạn thực sự muốn lập hoá đơn?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    employeeID = 3;
                    Invoice invoice = new Invoice();
                    invoice.EmployeeID = employeeID;
                    invoice.DateCheckOut = System.DateTime.Today;
                    var result = context.Invoices.Add(invoice);
                    context.SaveChanges();
                    List<InvoiceInfo> invoiceInfos = new List<InvoiceInfo>();

                    for (int i = 0; i < dgvCart.Rows.Count; i++)
                    {
                        InvoiceInfo info = new InvoiceInfo();
                        info.BookID = dgvCart.Rows[i].Cells["IdOfBook"].Value.ToString();
                        info.InvoiceID = invoice.InvoiceID;
                        info.Count = Convert.ToInt32(dgvCart.Rows[i].Cells["Quantity"].Value);
                        invoiceInfos.Add(info);
                    }
                    invoiceInfos.ForEach(s =>
                    {
                        s.InvoiceID = result.InvoiceID;
                        Book book = context.Books.Where(a => a.BookID == s.BookID).FirstOrDefault();
                        book.QuantityInStock -= s.Count;
                        context.InvoiceInfoes.Add(s);
                    });
                    context.SaveChanges();
                    dgvCart.Rows.Clear();
                    frmViewInvoice frm = new frmViewInvoice(invoice.InvoiceID);
                    frm.ShowDialog();
                }

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
    }
}
