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
    public partial class frmBookManagement : Form
    {
        public frmBookManagement()
        {
            InitializeComponent();
        }
        private void FillComboBoxCategory(List<Category> categories)
        {
            this.cmbCategory.DataSource = categories;
            this.cmbCategory.DisplayMember = "CategoryName";
            this.cmbCategory.ValueMember = "CategoryID";
        }
        private void FillComboBoxCompany(List<PublishingCompany> publishingCompanies)
        {
            this.cmbPubComp.DataSource = publishingCompanies;
            this.cmbPubComp.DisplayMember = "PubCompName";
            this.cmbPubComp.ValueMember = "PubCompID";
        }
        private void FillComboBoxAuthor(List<Author> authors)
        {
            this.cmbAuthor.DataSource = authors;
            this.cmbAuthor.DisplayMember = "AuthorName";
            this.cmbAuthor.ValueMember = "AuthorID";
        }
        private void BindGrid(List<Book> books)
        {
            dgvBook.Rows.Clear();
            foreach (var item in books)
            {
                int index = dgvBook.Rows.Add();
                dgvBook.Rows[index].Cells["BookID"].Value = item.BookID;
                dgvBook.Rows[index].Cells["BookName"].Value = item.BookName;
                dgvBook.Rows[index].Cells["Category"].Value = item.Category.CategoryName;
                dgvBook.Rows[index].Cells["Author"].Value = item.Author.AuthorName;
                dgvBook.Rows[index].Cells["PublishingCompany"].Value = item.PublishingCompany.PubCompName;
                dgvBook.Rows[index].Cells["Year"].Value = item.PublishingYear;
                dgvBook.Rows[index].Cells["Quantity"].Value = item.QuantityInStock;
                dgvBook.Rows[index].Cells["Price"].Value = item.Price;
            }
        }

        private void BookManagement_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void LoadForm()
        {
            ContextDB context = new ContextDB();
            List<Category> categories = context.Categories.ToList();
            List<PublishingCompany> publishingCompanies = context.PublishingCompanies.ToList();
            List<Author> authors = context.Authors.ToList();
            List<Book> books = context.Books.ToList();
            FillComboBoxCategory(categories);
            FillComboBoxAuthor(authors);
            FillComboBoxCompany(publishingCompanies);
            BindGrid(books);
            CountBook();
        }
        private int checkID(string ID)
        {
            for (int i = 0; i < dgvBook.Rows.Count; i++)
            {
                if (dgvBook.Rows[i].Cells[0].Value?.ToString() == ID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void checkData()
        {
            if (txtBookID.Text == "" || txtBookName.Text == "" || txtYear.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "")
                throw new Exception("Không được bỏ trống thông tin");
        }
        private void checkIDChar()
        {
            if (txtBookID.TextLength > 10 && txtBookID.TextLength < 1)
                throw new Exception("Mã số sinh viên phải có ít nhất 1 kí tự và nhiều nhất 10 kí tự");
        }
        private void CountBook()
        {
            int count = 0;
            for (int i = 0; i < dgvBook.Rows.Count; i++)
            {
                count++;
            }
            txtSum.Text = count.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                checkData();
                checkIDChar();
                if (checkID(txtBookID.Text) == -1)
                {
                    Book book = new Book();
                    book.BookID = txtBookID.Text;
                    book.BookName = txtBookName.Text;
                    book.CategoryID = cmbCategory.SelectedValue.ToString();
                    book.AuthorID = int.Parse(cmbAuthor.SelectedValue.ToString());
                    book.PubCompID = int.Parse(cmbPubComp.SelectedValue.ToString());
                    book.PublishingYear = int.Parse(txtYear.Text);
                    book.QuantityInStock = int.Parse(txtQuantity.Text);
                    book.Price = double.Parse(txtPrice.Text);

                    context.Books.Add(book);
                    context.SaveChanges();
                    LoadList();
                    ResetInput();
                }
                else
                {
                    MessageBox.Show("Mã sách đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ResetInput()
        {
            txtBookID.Clear();
            txtBookName.Clear();
            cmbCategory.SelectedIndex = 0;
            cmbAuthor.SelectedIndex = 0;
            cmbPubComp.SelectedIndex = 0;
            txtYear.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
        }

        private void LoadList()
        {
            ContextDB context = new ContextDB();
            BindGrid(context.Books.ToList());
            CountBook();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                Book book = context.Books.FirstOrDefault(p => p.BookID == txtBookID.Text);
                checkIDChar();
                if (checkID(txtBookID.Text) != -1)
                {
                    book.BookName = txtBookName.Text;
                    book.CategoryID = cmbCategory.SelectedValue.ToString();
                    book.AuthorID = int.Parse(cmbAuthor.SelectedValue.ToString());
                    book.PubCompID = int.Parse(cmbPubComp.SelectedValue.ToString());
                    book.PublishingYear = int.Parse(txtYear.Text);
                    book.QuantityInStock = int.Parse(txtQuantity.Text);
                    book.Price = double.Parse(txtPrice.Text);
                    context.Books.AddOrUpdate(book);
                    context.SaveChanges();
                    LoadList();
                    MessageBox.Show(" Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy sách cần sửa!", "Thông báo", MessageBoxButtons.OK);
                ResetInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                Book book = context.Books.FirstOrDefault(p => p.BookID == txtBookID.Text);
                checkIDChar();
                if (checkID(txtBookID.Text) != -1)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                    LoadList();
                    MessageBox.Show("Xoá sách thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy sách cần xoá!", "Thông báo", MessageBoxButtons.OK);
                ResetInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBookID.Text = dgvBook.SelectedRows[0].Cells["BookID"].Value.ToString();
            txtBookName.Text = dgvBook.SelectedRows[0].Cells["BookName"].Value.ToString();
            cmbCategory.Text = dgvBook.SelectedRows[0].Cells["Category"].Value.ToString();
            cmbAuthor.Text = dgvBook.SelectedRows[0].Cells["Author"].Value.ToString();
            cmbPubComp.Text = dgvBook.SelectedRows[0].Cells["PublishingCompany"].Value.ToString();
            txtYear.Text = dgvBook.SelectedRows[0].Cells["Year"].Value.ToString();
            txtQuantity.Text = dgvBook.SelectedRows[0].Cells["Quantity"].Value.ToString();
            txtPrice.Text = dgvBook.SelectedRows[0].Cells["Price"].Value.ToString();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadList();
            CountBook();
        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            if (txtBookID.Text != "")
            {
                var query = context.Books.Where(p => p.BookID.ToLower().Contains(txtBookID.Text.ToLower())).ToList();
                BindGrid(query);
                txtBookID.Clear();
                CountBook();
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            if (txtBookName.Text != "")
            {
                var query = context.Books.Where(p => p.BookName.ToLower().Contains(txtBookName.Text.ToLower())).ToList();
                BindGrid(query);
                txtBookName.Clear();
                CountBook();
            }
        }

        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            var query = context.Books.Where(p => p.Category.CategoryName.Contains(cmbCategory.Text)).ToList();
            BindGrid(query);
            cmbCategory.SelectedIndex = 0;
            CountBook();
        }

        private void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();
            var query = context.Books.Where(p => p.Author.AuthorName.Contains(cmbAuthor.Text)).ToList();
            BindGrid(query);
            cmbAuthor.SelectedIndex = 0;
            CountBook();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmCategoryManagement frm = new frmCategoryManagement();
            frm.ShowDialog();
            LoadForm();
        }

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            frmAuthorManagement frm = new frmAuthorManagement();
            frm.ShowDialog();
            LoadForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
