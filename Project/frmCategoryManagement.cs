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
    public partial class frmCategoryManagement : Form
    {
        public frmCategoryManagement()
        {
            InitializeComponent();
        }
        private void BindGrid(List<Category> categories)
        {
            dgvCategory.Rows.Clear();
            foreach (var item in categories)
            {
                int index = dgvCategory.Rows.Add();
                dgvCategory.Rows[index].Cells["CategoryID"].Value = item.CategoryID;
                dgvCategory.Rows[index].Cells["CategoryName"].Value = item.CategoryName;
            }
        }
        private void LoadData()
        {
            ContextDB context = new ContextDB();
            List<Category> categories = context.Categories.ToList();
            BindGrid(categories);
        }
        private int checkID(string ID)
        {
            for (int i = 0; i < dgvCategory.Rows.Count; i++)
            {
                if (dgvCategory.Rows[i].Cells[0].Value?.ToString() == ID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void frmCategoryManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            CountCategory();
        }
        private void checkIDChar()
        {
            if (txtCategoryID.TextLength != 3)
                throw new Exception("Mã thể loại phải có 3 kí tự !!");
        }
        private void checkData()
        {
            if (txtCategoryID.Text == "" || txtCategoryName.Text == "")
                throw new Exception("Không được bỏ trống thông tin");
        }
        private void CountCategory()
        {
            int count = 0;
            for (int i = 0; i < dgvCategory.Rows.Count; i++)
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
                if (checkID(txtCategoryID.Text) == -1)
                {
                    Category category = new Category();
                    category.CategoryID = txtCategoryID.Text;
                    category.CategoryName = txtCategoryName.Text;

                    context.Categories.Add(category);
                    context.SaveChanges();
                    LoadData();
                    ResetInput();
                    CountCategory();
                }
                else
                {
                    MessageBox.Show("Mã thể loại đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetInput()
        {
            txtCategoryID.Clear();
            txtCategoryName.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                Category category = context.Categories.FirstOrDefault(p => p.CategoryID == txtCategoryID.Text);
                if (checkID(txtCategoryID.Text) != -1)
                {
                    category.CategoryName = txtCategoryName.Text;
                    context.Categories.AddOrUpdate(category);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show(" Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy thể loại cần sửa!", "Thông báo", MessageBoxButtons.OK);
                ResetInput();
                CountCategory();
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
                Category category = context.Categories.FirstOrDefault(p => p.CategoryID == txtCategoryID.Text);
                checkIDChar();
                if (checkID(txtCategoryID.Text) != -1)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xoá thể loại thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy thể loại cần xoá!", "Thông báo", MessageBoxButtons.OK);
                ResetInput();
                CountCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                if (txtCategoryID.Text != "")
                {
                    var query = context.Categories.Where(p => p.CategoryID.ToLower().Contains(txtCategoryID.Text.ToLower())).ToList();
                    BindGrid(query);
                }
                if (txtCategoryName.Text != "")
                {
                    var query = context.Categories.Where(p => p.CategoryName.ToLower().Contains(txtCategoryName.Text.ToLower())).ToList();
                    BindGrid(query);
                }
                ResetInput();
                CountCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCategoryID.Text = dgvCategory.SelectedRows[0].Cells["CategoryID"].Value.ToString();
            txtCategoryName.Text = dgvCategory.SelectedRows[0].Cells["CategoryName"].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
