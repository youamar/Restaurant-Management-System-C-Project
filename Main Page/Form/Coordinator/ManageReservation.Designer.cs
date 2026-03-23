namespace Main_Page
{
    partial class ManageReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageReservation));
            this.btnapproved = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lstall = new System.Windows.Forms.ListBox();
            this.btncompleted = new System.Windows.Forms.Button();
            this.lstdetail = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btndeclined = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbhall = new System.Windows.Forms.ComboBox();
            this.btnhall = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtreply = new System.Windows.Forms.TextBox();
            this.btnreply = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnapproved
            // 
            this.btnapproved.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnapproved.Location = new System.Drawing.Point(517, 414);
            this.btnapproved.Name = "btnapproved";
            this.btnapproved.Size = new System.Drawing.Size(139, 38);
            this.btnapproved.TabIndex = 63;
            this.btnapproved.Text = "Approved";
            this.btnapproved.UseVisualStyleBackColor = true;
            this.btnapproved.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MistyRose;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(300, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 54);
            this.panel2.TabIndex = 61;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(556, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 44;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(512, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "MANAGE RESERVATIONS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lstall);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 498);
            this.panel1.TabIndex = 60;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(24, 15);
            this.lblTitle.MaximumSize = new System.Drawing.Size(350, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(65, 30);
            this.lblTitle.TabIndex = 77;
            this.lblTitle.Text = "Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(208, 24);
            this.label12.TabIndex = 43;
            this.label12.Text = "All Reservations :";
            // 
            // lstall
            // 
            this.lstall.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstall.FormattingEnabled = true;
            this.lstall.ItemHeight = 24;
            this.lstall.Items.AddRange(new object[] {
            "1413191 - PENDING",
            "1413192 - PENDING"});
            this.lstall.Location = new System.Drawing.Point(30, 112);
            this.lstall.Name = "lstall";
            this.lstall.Size = new System.Drawing.Size(240, 340);
            this.lstall.TabIndex = 36;
            this.lstall.SelectedIndexChanged += new System.EventHandler(this.lstall_SelectedIndexChanged);
            // 
            // btncompleted
            // 
            this.btncompleted.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncompleted.Location = new System.Drawing.Point(693, 414);
            this.btncompleted.Name = "btncompleted";
            this.btncompleted.Size = new System.Drawing.Size(154, 38);
            this.btncompleted.TabIndex = 64;
            this.btncompleted.Text = "Completed";
            this.btncompleted.UseVisualStyleBackColor = true;
            this.btncompleted.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstdetail
            // 
            this.lstdetail.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdetail.FormattingEnabled = true;
            this.lstdetail.HorizontalScrollbar = true;
            this.lstdetail.ItemHeight = 24;
            this.lstdetail.Items.AddRange(new object[] {
            "Customer Contact : 0129836999",
            "Prefered Hall : RoseWood",
            "Dining Date : 2025/08/31",
            "Dining Time : 1900-2200",
            "Pax : 40",
            "Request : Please help to prepare a bitrhday cake"});
            this.lstdetail.Location = new System.Drawing.Point(328, 112);
            this.lstdetail.Name = "lstdetail";
            this.lstdetail.Size = new System.Drawing.Size(528, 196);
            this.lstdetail.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(335, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 24);
            this.label3.TabIndex = 44;
            this.label3.Text = "Order Details :";
            // 
            // btndeclined
            // 
            this.btndeclined.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeclined.Location = new System.Drawing.Point(328, 414);
            this.btndeclined.Name = "btndeclined";
            this.btndeclined.Size = new System.Drawing.Size(155, 38);
            this.btndeclined.TabIndex = 66;
            this.btndeclined.Text = "Declined";
            this.btndeclined.UseVisualStyleBackColor = true;
            this.btndeclined.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label8.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(671, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 17);
            this.label8.TabIndex = 67;
            this.label8.Text = "View Customer Profile";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 24);
            this.label4.TabIndex = 68;
            this.label4.Text = "Hall :";
            // 
            // cmbhall
            // 
            this.cmbhall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbhall.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbhall.FormattingEnabled = true;
            this.cmbhall.Items.AddRange(new object[] {
            "Rosewood"});
            this.cmbhall.Location = new System.Drawing.Point(428, 329);
            this.cmbhall.Name = "cmbhall";
            this.cmbhall.Size = new System.Drawing.Size(145, 30);
            this.cmbhall.TabIndex = 69;
            // 
            // btnhall
            // 
            this.btnhall.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhall.Location = new System.Drawing.Point(579, 329);
            this.btnhall.Name = "btnhall";
            this.btnhall.Size = new System.Drawing.Size(97, 30);
            this.btnhall.TabIndex = 70;
            this.btnhall.Text = "Assign";
            this.btnhall.UseVisualStyleBackColor = true;
            this.btnhall.Click += new System.EventHandler(this.btnhall_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(335, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 24);
            this.label5.TabIndex = 71;
            this.label5.Text = "Reply :";
            // 
            // txtreply
            // 
            this.txtreply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtreply.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreply.Location = new System.Drawing.Point(428, 369);
            this.txtreply.Name = "txtreply";
            this.txtreply.Size = new System.Drawing.Size(273, 27);
            this.txtreply.TabIndex = 72;
            // 
            // btnreply
            // 
            this.btnreply.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreply.Location = new System.Drawing.Point(707, 368);
            this.btnreply.Name = "btnreply";
            this.btnreply.Size = new System.Drawing.Size(97, 30);
            this.btnreply.TabIndex = 73;
            this.btnreply.Text = "Assign";
            this.btnreply.UseVisualStyleBackColor = true;
            this.btnreply.Click += new System.EventHandler(this.btnreply_Click);
            // 
            // ManageReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 498);
            this.Controls.Add(this.btnreply);
            this.Controls.Add(this.txtreply);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnhall);
            this.Controls.Add(this.cmbhall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btndeclined);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstdetail);
            this.Controls.Add(this.btncompleted);
            this.Controls.Add(this.btnapproved);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageReservation";
            this.Text = "Form1";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnapproved;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstall;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btncompleted;
        private System.Windows.Forms.ListBox lstdetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btndeclined;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbhall;
        private System.Windows.Forms.Button btnhall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtreply;
        private System.Windows.Forms.Button btnreply;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}