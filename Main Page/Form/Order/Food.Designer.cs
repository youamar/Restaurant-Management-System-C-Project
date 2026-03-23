namespace Main_Page.Order
{
    partial class Food
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Food));
            this.picture = new System.Windows.Forms.PictureBox();
            this.item = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.brn2 = new System.Windows.Forms.Button();
            this.quantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.ErrorImage = null;
            this.picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            this.picture.InitialImage = null;
            this.picture.Location = new System.Drawing.Point(96, 95);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(300, 300);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            // 
            // item
            // 
            this.item.AutoSize = true;
            this.item.Font = new System.Drawing.Font("Cascadia Code", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item.Location = new System.Drawing.Point(421, 126);
            this.item.MaximumSize = new System.Drawing.Size(400, 0);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(390, 60);
            this.item.TabIndex = 3;
            this.item.Text = "Gourmet Plant-Based Teriyaki Chicken Burger";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Cascadia Code Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(424, 188);
            this.description.MaximumSize = new System.Drawing.Size(400, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(387, 60);
            this.description.TabIndex = 4;
            this.description.Text = "A juicy, guilt-free indulgence for lovers who share everything—including a passio" +
    "n for good food.";
            // 
            // btnadd
            // 
            this.btnadd.Font = new System.Drawing.Font("Cascadia Code SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(443, 332);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(189, 39);
            this.btnadd.TabIndex = 5;
            this.btnadd.Text = "Add To Cart";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Back";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Cascadia Code", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(442, 277);
            this.price.MaximumSize = new System.Drawing.Size(400, 0);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(113, 37);
            this.price.TabIndex = 7;
            this.price.Text = "$20.00";
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(602, 282);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(30, 30);
            this.btn1.TabIndex = 8;
            this.btn1.Text = "-";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // brn2
            // 
            this.brn2.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brn2.Location = new System.Drawing.Point(677, 282);
            this.brn2.Name = "brn2";
            this.brn2.Size = new System.Drawing.Size(30, 30);
            this.brn2.TabIndex = 9;
            this.brn2.Text = "+";
            this.brn2.UseVisualStyleBackColor = true;
            this.brn2.Click += new System.EventHandler(this.brn2_Click);
            // 
            // quantity
            // 
            this.quantity.AutoSize = true;
            this.quantity.Font = new System.Drawing.Font("Cascadia Code", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.Location = new System.Drawing.Point(639, 283);
            this.quantity.MaximumSize = new System.Drawing.Size(400, 0);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(32, 24);
            this.quantity.TabIndex = 10;
            this.quantity.Text = "11";
            this.quantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Food
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 498);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.brn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.description);
            this.Controls.Add(this.item);
            this.Controls.Add(this.picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Food";
            this.Text = "Food";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label item;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button brn2;
        private System.Windows.Forms.Label quantity;
    }
}