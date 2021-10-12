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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private int checkAccount()
        {
            ContextDB context = new ContextDB();
            List<Account> accounts = context.Accounts.ToList();
            foreach (var item in accounts)
            {
                if (item.UserName == txtUserName.Text && item.Password == txtPassword.Text)
                    return 1;
            }
            return -1;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ContextDB context = new ContextDB();

            List<Account> accounts = context.Accounts.ToList();

            if (checkAccount() == 1)
            {
                Account account = context.Accounts.FirstOrDefault(p => p.UserName == txtUserName.Text);
                frmMain frmMain = new frmMain(account.EmployeeID, account.DisplayName);
                this.Hide();
                frmMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu của bạn không chính xác.", "Thông báo");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thực sự muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
