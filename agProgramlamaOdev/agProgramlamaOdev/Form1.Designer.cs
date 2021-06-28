
namespace agProgramlamaOdev
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.deviceDVG = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.macTxtBoxFiller = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.getMacAddressTxtbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.IPConfirm = new System.Windows.Forms.Button();
            this.nUD2 = new System.Windows.Forms.NumericUpDown();
            this.nUD3 = new System.Windows.Forms.NumericUpDown();
            this.nUD4 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nUD1 = new System.Windows.Forms.NumericUpDown();
            this.dot1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sourcePingLbl = new System.Windows.Forms.Label();
            this.MaxCharLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MsgDGV = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MsgSendBtn = new System.Windows.Forms.Button();
            this.msgToSendTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PleaseWaitDGV = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PleaseWaitLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.deviceDVG)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MsgDGV)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PleaseWaitDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceDVG
            // 
            this.deviceDVG.AllowUserToAddRows = false;
            this.deviceDVG.AllowUserToDeleteRows = false;
            this.deviceDVG.AllowUserToResizeColumns = false;
            this.deviceDVG.AllowUserToResizeRows = false;
            this.deviceDVG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.deviceDVG.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.deviceDVG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deviceDVG.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            resources.ApplyResources(this.deviceDVG, "deviceDVG");
            this.deviceDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.deviceDVG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.deviceDVG.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.deviceDVG.Name = "deviceDVG";
            this.deviceDVG.ReadOnly = true;
            this.deviceDVG.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.deviceDVG.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.deviceDVG.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.deviceDVG.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.deviceDVG.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.deviceDVG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.deviceDVG_CellContentClick);
            // 
            // Column1
            // 
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.macTxtBoxFiller);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.getMacAddressTxtbox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.IPConfirm);
            this.panel1.Controls.Add(this.nUD2);
            this.panel1.Controls.Add(this.nUD3);
            this.panel1.Controls.Add(this.nUD4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nUD1);
            this.panel1.Controls.Add(this.dot1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.deviceDVG);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // macTxtBoxFiller
            // 
            this.macTxtBoxFiller.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.macTxtBoxFiller, "macTxtBoxFiller");
            this.macTxtBoxFiller.Name = "macTxtBoxFiller";
            this.macTxtBoxFiller.UseVisualStyleBackColor = false;
            this.macTxtBoxFiller.Click += new System.EventHandler(this.macTxtBoxFiller_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // getMacAddressTxtbox
            // 
            resources.ApplyResources(this.getMacAddressTxtbox, "getMacAddressTxtbox");
            this.getMacAddressTxtbox.Name = "getMacAddressTxtbox";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // IPConfirm
            // 
            resources.ApplyResources(this.IPConfirm, "IPConfirm");
            this.IPConfirm.Name = "IPConfirm";
            this.IPConfirm.UseVisualStyleBackColor = true;
            this.IPConfirm.Click += new System.EventHandler(this.IPConfirm_Click);
            // 
            // nUD2
            // 
            this.nUD2.InterceptArrowKeys = false;
            resources.ApplyResources(this.nUD2, "nUD2");
            this.nUD2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nUD2.Name = "nUD2";
            // 
            // nUD3
            // 
            this.nUD3.InterceptArrowKeys = false;
            resources.ApplyResources(this.nUD3, "nUD3");
            this.nUD3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nUD3.Name = "nUD3";
            // 
            // nUD4
            // 
            this.nUD4.InterceptArrowKeys = false;
            resources.ApplyResources(this.nUD4, "nUD4");
            this.nUD4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nUD4.Name = "nUD4";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // nUD1
            // 
            this.nUD1.InterceptArrowKeys = false;
            resources.ApplyResources(this.nUD1, "nUD1");
            this.nUD1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nUD1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD1.Name = "nUD1";
            this.nUD1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dot1
            // 
            resources.ApplyResources(this.dot1, "dot1");
            this.dot1.Name = "dot1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.sourcePingLbl);
            this.panel3.Controls.Add(this.MaxCharLbl);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.MsgDGV);
            this.panel3.Controls.Add(this.MsgSendBtn);
            this.panel3.Controls.Add(this.msgToSendTB);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // sourcePingLbl
            // 
            resources.ApplyResources(this.sourcePingLbl, "sourcePingLbl");
            this.sourcePingLbl.Name = "sourcePingLbl";
            // 
            // MaxCharLbl
            // 
            resources.ApplyResources(this.MaxCharLbl, "MaxCharLbl");
            this.MaxCharLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaxCharLbl.Name = "MaxCharLbl";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // MsgDGV
            // 
            this.MsgDGV.AllowUserToAddRows = false;
            this.MsgDGV.AllowUserToDeleteRows = false;
            this.MsgDGV.AllowUserToResizeColumns = false;
            this.MsgDGV.AllowUserToResizeRows = false;
            this.MsgDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MsgDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MsgDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MsgDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MsgDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.MsgDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MsgDGV.ColumnHeadersVisible = false;
            this.MsgDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            resources.ApplyResources(this.MsgDGV, "MsgDGV");
            this.MsgDGV.Name = "MsgDGV";
            this.MsgDGV.ReadOnly = true;
            this.MsgDGV.RowHeadersVisible = false;
            this.MsgDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // Column2
            // 
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            resources.ApplyResources(this.Column3, "Column3");
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // MsgSendBtn
            // 
            resources.ApplyResources(this.MsgSendBtn, "MsgSendBtn");
            this.MsgSendBtn.Name = "MsgSendBtn";
            this.MsgSendBtn.UseVisualStyleBackColor = true;
            this.MsgSendBtn.Click += new System.EventHandler(this.MsgSendBtn_Click);
            // 
            // msgToSendTB
            // 
            resources.ApplyResources(this.msgToSendTB, "msgToSendTB");
            this.msgToSendTB.Name = "msgToSendTB";
            this.msgToSendTB.TextChanged += new System.EventHandler(this.MaxCharLbl_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PleaseWaitDGV);
            this.panel2.Controls.Add(this.PleaseWaitLbl);
            this.panel2.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // PleaseWaitDGV
            // 
            this.PleaseWaitDGV.AllowUserToAddRows = false;
            this.PleaseWaitDGV.AllowUserToDeleteRows = false;
            this.PleaseWaitDGV.AllowUserToResizeColumns = false;
            this.PleaseWaitDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PleaseWaitDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.PleaseWaitDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PleaseWaitDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PleaseWaitDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PleaseWaitDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PleaseWaitDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.PleaseWaitDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PleaseWaitDGV.ColumnHeadersVisible = false;
            this.PleaseWaitDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PleaseWaitDGV.DefaultCellStyle = dataGridViewCellStyle4;
            this.PleaseWaitDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            resources.ApplyResources(this.PleaseWaitDGV, "PleaseWaitDGV");
            this.PleaseWaitDGV.Name = "PleaseWaitDGV";
            this.PleaseWaitDGV.ReadOnly = true;
            this.PleaseWaitDGV.RowHeadersVisible = false;
            this.PleaseWaitDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PleaseWaitDGV.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.PleaseWaitDGV.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PleaseWaitDGV.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PleaseWaitDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.PleaseWaitDGV.TabStop = false;
            this.PleaseWaitDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.PleaseWaitDGV_RowsAdded);
            // 
            // Column4
            // 
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // PleaseWaitLbl
            // 
            resources.ApplyResources(this.PleaseWaitLbl, "PleaseWaitLbl");
            this.PleaseWaitLbl.Name = "PleaseWaitLbl";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::agProgramlamaOdev.Properties.Resources.Loading;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.deviceDVG)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MsgDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PleaseWaitDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView deviceDVG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUD1;
        private System.Windows.Forms.NumericUpDown nUD4;
        private System.Windows.Forms.NumericUpDown nUD3;
        private System.Windows.Forms.NumericUpDown nUD2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dot1;
        private System.Windows.Forms.Button IPConfirm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox msgToSendTB;
        private System.Windows.Forms.Button MsgSendBtn;
        private System.Windows.Forms.DataGridView MsgDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label PleaseWaitLbl;
        private System.Windows.Forms.DataGridView PleaseWaitDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label MaxCharLbl;
        private System.Windows.Forms.Label sourcePingLbl;
        private System.Windows.Forms.TextBox getMacAddressTxtbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button macTxtBoxFiller;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}

