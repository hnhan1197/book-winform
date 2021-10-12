
namespace Project
{
    partial class frmInvoiceManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceManagement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCheckOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtmToDate = new System.Windows.Forms.DateTimePicker();
            this.dtmFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtmViewMonth = new System.Windows.Forms.DateTimePicker();
            this.dtmViewDate = new System.Windows.Forms.DateTimePicker();
            this.rdoDateToDate = new System.Windows.Forms.RadioButton();
            this.rdoViewMonth = new System.Windows.Forms.RadioButton();
            this.rdoViewDate = new System.Windows.Forms.RadioButton();
            this.chkViewAll = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnViewInvoice = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 41);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(232, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.InvoiceNo,
            this.DateCheckOut,
            this.Employee});
            this.dgvInvoice.Location = new System.Drawing.Point(12, 178);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.ReadOnly = true;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(643, 246);
            this.dgvInvoice.TabIndex = 1;
            this.dgvInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellClick);
            // 
            // No
            // 
            this.No.HeaderText = "STT";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Số Hoá Đơn";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // DateCheckOut
            // 
            this.DateCheckOut.HeaderText = "Ngày Lập Hoá Đơn";
            this.DateCheckOut.Name = "DateCheckOut";
            this.DateCheckOut.ReadOnly = true;
            this.DateCheckOut.Width = 200;
            // 
            // Employee
            // 
            this.Employee.HeaderText = "Nhân Viên Lập Hoá Đơn";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            this.Employee.Width = 200;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dtmToDate);
            this.panel2.Controls.Add(this.dtmFromDate);
            this.panel2.Controls.Add(this.dtmViewMonth);
            this.panel2.Controls.Add(this.dtmViewDate);
            this.panel2.Controls.Add(this.rdoDateToDate);
            this.panel2.Controls.Add(this.rdoViewMonth);
            this.panel2.Controls.Add(this.rdoViewDate);
            this.panel2.Controls.Add(this.chkViewAll);
            this.panel2.Location = new System.Drawing.Point(12, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(643, 125);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(412, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "~";
            // 
            // dtmToDate
            // 
            this.dtmToDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmToDate.CustomFormat = "dd/MM/yyyy";
            this.dtmToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmToDate.Location = new System.Drawing.Point(435, 97);
            this.dtmToDate.Name = "dtmToDate";
            this.dtmToDate.Size = new System.Drawing.Size(200, 20);
            this.dtmToDate.TabIndex = 7;
            this.dtmToDate.ValueChanged += new System.EventHandler(this.dtmFromDate_ValueChanged);
            // 
            // dtmFromDate
            // 
            this.dtmFromDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtmFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmFromDate.Location = new System.Drawing.Point(206, 97);
            this.dtmFromDate.Name = "dtmFromDate";
            this.dtmFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtmFromDate.TabIndex = 6;
            this.dtmFromDate.ValueChanged += new System.EventHandler(this.dtmFromDate_ValueChanged);
            // 
            // dtmViewMonth
            // 
            this.dtmViewMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmViewMonth.CustomFormat = "MM/yyyy";
            this.dtmViewMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmViewMonth.Location = new System.Drawing.Point(206, 65);
            this.dtmViewMonth.Name = "dtmViewMonth";
            this.dtmViewMonth.Size = new System.Drawing.Size(200, 20);
            this.dtmViewMonth.TabIndex = 5;
            this.dtmViewMonth.ValueChanged += new System.EventHandler(this.dtmFromDate_ValueChanged);
            // 
            // dtmViewDate
            // 
            this.dtmViewDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtmViewDate.CustomFormat = "dd/MM/yyyy";
            this.dtmViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmViewDate.Location = new System.Drawing.Point(206, 33);
            this.dtmViewDate.Name = "dtmViewDate";
            this.dtmViewDate.Size = new System.Drawing.Size(200, 20);
            this.dtmViewDate.TabIndex = 4;
            this.dtmViewDate.ValueChanged += new System.EventHandler(this.dtmFromDate_ValueChanged);
            // 
            // rdoDateToDate
            // 
            this.rdoDateToDate.AutoSize = true;
            this.rdoDateToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDateToDate.Location = new System.Drawing.Point(14, 99);
            this.rdoDateToDate.Name = "rdoDateToDate";
            this.rdoDateToDate.Size = new System.Drawing.Size(108, 20);
            this.rdoDateToDate.TabIndex = 3;
            this.rdoDateToDate.TabStop = true;
            this.rdoDateToDate.Text = "Xem Từ Ngày";
            this.rdoDateToDate.UseVisualStyleBackColor = true;
            this.rdoDateToDate.CheckedChanged += new System.EventHandler(this.rdoViewDate_CheckedChanged);
            // 
            // rdoViewMonth
            // 
            this.rdoViewMonth.AutoSize = true;
            this.rdoViewMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoViewMonth.Location = new System.Drawing.Point(14, 67);
            this.rdoViewMonth.Name = "rdoViewMonth";
            this.rdoViewMonth.Size = new System.Drawing.Size(130, 20);
            this.rdoViewMonth.TabIndex = 2;
            this.rdoViewMonth.TabStop = true;
            this.rdoViewMonth.Text = "Xem Theo Tháng";
            this.rdoViewMonth.UseVisualStyleBackColor = true;
            this.rdoViewMonth.CheckedChanged += new System.EventHandler(this.rdoViewDate_CheckedChanged);
            // 
            // rdoViewDate
            // 
            this.rdoViewDate.AutoSize = true;
            this.rdoViewDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoViewDate.Location = new System.Drawing.Point(14, 35);
            this.rdoViewDate.Name = "rdoViewDate";
            this.rdoViewDate.Size = new System.Drawing.Size(115, 20);
            this.rdoViewDate.TabIndex = 1;
            this.rdoViewDate.TabStop = true;
            this.rdoViewDate.Text = "Xem theo ngày";
            this.rdoViewDate.UseVisualStyleBackColor = true;
            this.rdoViewDate.CheckedChanged += new System.EventHandler(this.rdoViewDate_CheckedChanged);
            // 
            // chkViewAll
            // 
            this.chkViewAll.AutoSize = true;
            this.chkViewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViewAll.Location = new System.Drawing.Point(14, 3);
            this.chkViewAll.Name = "chkViewAll";
            this.chkViewAll.Size = new System.Drawing.Size(148, 20);
            this.chkViewAll.TabIndex = 0;
            this.chkViewAll.Text = "Xem tất cả đơn hàng";
            this.chkViewAll.UseVisualStyleBackColor = true;
            this.chkViewAll.CheckedChanged += new System.EventHandler(this.chkViewAll_CheckedChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(158, 431);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 33);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Trở về";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtSum
            // 
            this.txtSum.Enabled = false;
            this.txtSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSum.Location = new System.Drawing.Point(578, 431);
            this.txtSum.Name = "txtSum";
            this.txtSum.Size = new System.Drawing.Size(77, 22);
            this.txtSum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(459, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng hoá đơn";
            // 
            // btnViewInvoice
            // 
            this.btnViewInvoice.Location = new System.Drawing.Point(12, 430);
            this.btnViewInvoice.Name = "btnViewInvoice";
            this.btnViewInvoice.Size = new System.Drawing.Size(140, 33);
            this.btnViewInvoice.TabIndex = 7;
            this.btnViewInvoice.Text = "Xem Hoá Đơn";
            this.btnViewInvoice.UseVisualStyleBackColor = true;
            this.btnViewInvoice.Click += new System.EventHandler(this.btnViewInvoice_Click);
            // 
            // frmInvoiceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 472);
            this.Controls.Add(this.btnViewInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvInvoice);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInvoiceManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ ĐƠN HÀNG";
            this.Load += new System.EventHandler(this.frmInvoiceManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCheckOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtmToDate;
        private System.Windows.Forms.DateTimePicker dtmFromDate;
        private System.Windows.Forms.DateTimePicker dtmViewMonth;
        private System.Windows.Forms.DateTimePicker dtmViewDate;
        private System.Windows.Forms.RadioButton rdoDateToDate;
        private System.Windows.Forms.RadioButton rdoViewMonth;
        private System.Windows.Forms.RadioButton rdoViewDate;
        private System.Windows.Forms.CheckBox chkViewAll;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewInvoice;
    }
}