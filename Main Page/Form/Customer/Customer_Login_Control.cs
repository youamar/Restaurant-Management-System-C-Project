using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class Customer_Login_Control
    {
        private string contact;
        private Form parentform;

        public Customer_Login_Control(Form parentform, string contact)
        {
            this.contact = contact;
            this.parentform = parentform;
        }

        public void Checkmember()
        {


            if (contact == "")
            {
                MessageBox.Show("You Must Insert a Contact Number!");
            }
            else
            {
                CustomerService service = new CustomerService("VegeMeat");
                CustomerModel result = service.GetCustomerByContact(contact);

                if (result == null)
                {
                    MessageBox.Show("Not Record Found!\nSign up or try again!");
                }
                else
                {
                    Customer_OTP otp = new Customer_OTP(parentform, contact);
                    otp.Show();
                    parentform.Hide();
                }
            }
        }
    }
}
