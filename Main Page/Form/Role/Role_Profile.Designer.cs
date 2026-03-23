namespace Main_Page
{
    partial class Role_Profile
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
            this.lbltitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lid = new System.Windows.Forms.Label();
            this.lic = new System.Windows.Forms.Label();
            this.lemail = new System.Windows.Forms.Label();
            this.lcontact = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Cascadia Code", 12F);
            this.lbltitle.Location = new System.Drawing.Point(237, 94);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(324, 27);
            this.lbltitle.TabIndex = 8;
            this.lbltitle.Text = "Hi, Manager Chang Kai Yang";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lid);
            this.groupBox1.Controls.Add(this.lic);
            this.groupBox1.Controls.Add(this.lemail);
            this.groupBox1.Controls.Add(this.lcontact);
            this.groupBox1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(214, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 208);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile Info";
            // 
            // lid
            // 
            this.lid.AutoSize = true;
            this.lid.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lid.Location = new System.Drawing.Point(24, 56);
            this.lid.Name = "lid";
            this.lid.Size = new System.Drawing.Size(190, 22);
            this.lid.TabIndex = 5;
            this.lid.Text = "Staff ID : C083573";
            // 
            // lic
            // 
            this.lic.AutoSize = true;
            this.lic.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lic.Location = new System.Drawing.Point(24, 146);
            this.lic.Name = "lic";
            this.lic.Size = new System.Drawing.Size(310, 22);
            this.lic.TabIndex = 3;
            this.lic.Text = "Identity Number : 050831102485";
            // 
            // lemail
            // 
            this.lemail.AutoSize = true;
            this.lemail.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lemail.Location = new System.Drawing.Point(24, 116);
            this.lemail.Name = "lemail";
            this.lemail.Size = new System.Drawing.Size(360, 22);
            this.lemail.TabIndex = 2;
            this.lemail.Text = "Email Address : sannielyk@gmail.com";
            // 
            // lcontact
            // 
            this.lcontact.AutoSize = true;
            this.lcontact.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcontact.Location = new System.Drawing.Point(24, 86);
            this.lcontact.Name = "lcontact";
            this.lcontact.Size = new System.Drawing.Size(270, 22);
            this.lcontact.TabIndex = 1;
            this.lcontact.Text = "Phone Number : 60129836999";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label8.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(519, 374);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Change Password";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label5.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(527, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Update Profile";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Back
            // 
            this.Back.AutoSize = true;
            this.Back.Font = new System.Drawing.Font("Cascadia Code", 12F);
            this.Back.Location = new System.Drawing.Point(45, 27);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(60, 27);
            this.Back.TabIndex = 16;
            this.Back.Text = "Back";
            this.Back.Click += new System.EventHandler(this.label2_Click);
            // 
            // Role_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 498);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Role_Profile";
            this.Text = "Customer_Profile.cs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lic;
        private System.Windows.Forms.Label lemail;
        private System.Windows.Forms.Label lcontact;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Back;
    }
}