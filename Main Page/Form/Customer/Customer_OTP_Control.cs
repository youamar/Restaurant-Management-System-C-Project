using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace Main_Page.Control
{
    internal class Customer_OTP_Control
    {
        private string contact;
        private string correctotp;
        private Form parentform;
        private TextBox[] boxs;

        public Customer_OTP_Control(Form parentform, string contact, TextBox[] boxs)
        {
            this.parentform = parentform;
            this.contact = contact;
            this.boxs = boxs;
        }

        public void GenerateOtp()
        {
            Random num = new Random();
            int number = num.Next(100000, 999999);
            MessageBox.Show($"Your OTP is {number}");

            correctotp = number.ToString();
        }

        public void CheckOTP(string number1, string number2, string number3, string number4, string number5, string number6)
        {
            string enteredotp = number1 + number2 + number3 + number4 + number5 + number6;


            if (enteredotp.Length < 6)
            {
                MessageBox.Show($"Enter 6 digits OTP!");
                for (int i = 0; i < boxs.Length; i++)
                {
                    boxs[i].Text = "";
                }
            }
            else if (enteredotp == correctotp)
            {
                MessageBox.Show($"OTP correct!");
                AddCustomer();
            }
            else
            {
                MessageBox.Show($"OTP incorrect!\nPlease try again!");
                for (int i = 0; i < boxs.Length; i++)
                {
                    boxs[i].Text = "";
                }
                boxs[0].Focus();
            }
        }

        private void AddCustomer()
        {
            CustomerService service = new CustomerService("VegeMeat");
            CustomerModel customer = service.GetCustomerByContact(contact);
            if (customer != null)
            {
                SessionManager.Instance.CustomerId = customer.customer_id;

                Home home = new Home();
                home.Show();
                parentform.Hide();
            }
            else
            {
                List<CustomerModel> customers = service.GetAllCustomer();
                int count = customers.Count + 1;

                string customer_id = $"C{count}";

                if (service.AddCustomer(customer_id, contact))
                {
                    SessionManager.Instance.CustomerId = customer_id;

                    MessageBox.Show("Account Registered Successfully!");
                    Home obj1 = new Home();
                    obj1.Show();
                    parentform.Hide();
                }
                else
                {
                    MessageBox.Show("Failed Register!");
                }
            }
        }
    }
}