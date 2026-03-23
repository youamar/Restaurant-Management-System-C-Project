using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;
using System.Windows.Forms;

namespace Main_Page.Control
{
    internal class Customer_Signup_Control
    {

        private string contact;
        Form parentform;

        public Customer_Signup_Control(Form parentform, string contact)
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
                var result = service.GetCustomerByContact(contact);
                if (result != null)
                {
                    MessageBox.Show("Already Risteger!\nLog in or try again!");
                }
                else
                {
                    Customer_OTP otp = new Customer_OTP(parentform,contact);
                    otp.Show();
                    parentform.Hide();
                }
            }
        }
    }
}
