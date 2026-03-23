namespace Main_Page
{
    partial class MailBox
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
            this.M1 = new System.Windows.Forms.Button();
            this.M2 = new System.Windows.Forms.Button();
            this.M3 = new System.Windows.Forms.Button();
            this.M4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // M1
            // 
            this.M1.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M1.Location = new System.Drawing.Point(20, 98);
            this.M1.Name = "M1";
            this.M1.Size = new System.Drawing.Size(310, 110);
            this.M1.TabIndex = 0;
            this.M1.Text = "Message1";
            this.M1.UseVisualStyleBackColor = true;
            // 
            // M2
            // 
            this.M2.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M2.Location = new System.Drawing.Point(20, 218);
            this.M2.Name = "M2";
            this.M2.Size = new System.Drawing.Size(310, 110);
            this.M2.TabIndex = 1;
            this.M2.Text = "Message1";
            this.M2.UseVisualStyleBackColor = true;
            // 
            // M3
            // 
            this.M3.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M3.Location = new System.Drawing.Point(20, 338);
            this.M3.Name = "M3";
            this.M3.Size = new System.Drawing.Size(310, 110);
            this.M3.TabIndex = 2;
            this.M3.Text = "Message1";
            this.M3.UseVisualStyleBackColor = true;
            // 
            // M4
            // 
            this.M4.Font = new System.Drawing.Font("Cascadia Code", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M4.Location = new System.Drawing.Point(20, 458);
            this.M4.Name = "M4";
            this.M4.Size = new System.Drawing.Size(310, 110);
            this.M4.TabIndex = 3;
            this.M4.Text = "Message1";
            this.M4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inbox :";
            // 
            // MailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.ClientSize = new System.Drawing.Size(371, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.M4);
            this.Controls.Add(this.M3);
            this.Controls.Add(this.M2);
            this.Controls.Add(this.M1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MailBox";
            this.Text = "MailBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button M1;
        private System.Windows.Forms.Button M2;
        private System.Windows.Forms.Button M3;
        private System.Windows.Forms.Button M4;
        private System.Windows.Forms.Label label1;
    }
}