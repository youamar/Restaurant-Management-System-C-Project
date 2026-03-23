using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main_Page.Control;

namespace Main_Page
{
    public partial class Customer_OTP : Form
    {
        private Form parentForm;
        private string contact;
        private TextBox[] boxs;

        private Customer_OTP_Control otp;

        public Customer_OTP(Form parentForm, string contact)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.parentForm = parentForm;
            this.contact = contact;

            txtcontact.Text += $"0{contact}";

            boxs = new TextBox[] { number1, number2, number3, number4, number5, number6 };

            otp = new Customer_OTP_Control(this, contact, boxs);
            otp.GenerateOtp();

            foreach (TextBox box in boxs)
            {
                box.MaxLength = 1;  // 确保每个框最多输入 1 个字符
                box.TextChanged += Box_TextChanged;
                box.KeyDown += Box_KeyDown;  // 允许使用 Backspace 退回
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            otp.CheckOTP(number1.Text, number2.Text, number3.Text, number4.Text, number5.Text, number6.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parentForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customer_OTP otp = new Customer_OTP(parentForm, contact);
            otp.Show();
            this.Hide();
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox currentBox = sender as TextBox;

            if (e.KeyCode == Keys.Back)
            {
                if (currentBox != null)
                {
                    int index = Array.IndexOf(boxs, currentBox);

                    if (index > 0 && currentBox.Text.Length == 0)
                    {
                        boxs[index - 1].Text = "";
                        boxs[index - 1].Focus();
                    }
                }
            }
        }

        private void Box_TextChanged(object sender, EventArgs e)
        {
            TextBox currentBox = sender as TextBox;
            if (currentBox != null && currentBox.Text.Length == 1)
            {
                SelectNextControl(currentBox, true, true, true, true);
            }
        }
    }
}

