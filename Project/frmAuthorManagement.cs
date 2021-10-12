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
    public partial class frmAuthorManagement : Form
    {
        public frmAuthorManagement()
        {
            InitializeComponent();
        }
        private void BindGrid(List<Author> authors)
        {
            dgvAuthor.Rows.Clear();
            foreach (var item in authors)
            {
                int index = dgvAuthor.Rows.Add();
                dgvAuthor.Rows[index].Cells["AuthorID"].Value = item.AuthorID;
                dgvAuthor.Rows[index].Cells["AuthorName"].Value = item.AuthorName;
            }
        }
        private void LoadData()
        {
            ContextDB context = new ContextDB();
            List<Author> authors = context.Authors.ToList();
            BindGrid(authors);
        }
        private int checkID(string ID)
        {
            for (int i = 0; i < dgvAuthor.Rows.Count; i++)
            {
                if (dgvAuthor.Rows[i].Cells[0].Value?.ToString() == ID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void frmAuthorManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            CountAuthor();
        }
        private void ResetInput()
        {
            txtAuthorID.Clear();
            txtAuthorName.Clear();
        }
        private void CountAuthor()
        {
            int count = 0;
            for (int i = 0; i < dgvAuthor.Rows.Count; i++)
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

                Author author = new Author();
                author.AuthorName = txtAuthorName.Text;

                context.Authors.Add(author);
                context.SaveChanges();
                LoadData();
                ResetInput();
                CountAuthor();
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
                Author author = context.Authors.FirstOrDefault(p => p.AuthorID.ToString() == txtAuthorID.Text);
                if (checkID(txtAuthorID.Text) != -1)
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xoá tác giả thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy tác giả cần xoá!", "Thông báo", MessageBoxButtons.OK);
                ResetInput();
                CountAuthor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ContextDB context = new ContextDB();
                Author author = context.Authors.FirstOrDefault(p => p.AuthorID.ToString() == txtAuthorID.Text);
                if (checkID(txtAuthorID.Text) != -1)
                {
                    author.AuthorName = txtAuthorName.Text;
                    context.Authors.AddOrUpdate(author);
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show(" Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy tác giả cần sửa!", "Thông báo", MessageBoxButtons.OK);
                ResetInput();
                CountAuthor();
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
                if (txtAuthorID.Text != "")
                {
                    var query = context.Authors.Where(p => p.AuthorID.ToString() == txtAuthorID.Text).ToList();
                    BindGrid(query);
                }
                if (txtAuthorName.Text != "")
                {
                    var query = context.Authors.Where(p => p.AuthorName.ToLower().Contains(txtAuthorName.Text.ToLower())).ToList();
                    BindGrid(query);
                }
                ResetInput();
                CountAuthor();
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

        private void dgvAuthor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAuthorID.Text = dgvAuthor.SelectedRows[0].Cells["AuthorID"].Value.ToString();
            txtAuthorName.Text = dgvAuthor.SelectedRows[0].Cells["AuthorName"].Value.ToString();
        }
    }
}
