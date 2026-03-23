using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;
using System.Windows.Forms;
using System.Globalization;

namespace Main_Page
{
    internal class CustomerEditProfileControl
    {
        private TextBox name;
        private TextBox contact;
        private TextBox email;
        private DateTimePicker birthday;
        private CustomerModel customer;
        private Form parentform;


        public CustomerEditProfileControl(Form parentform, TextBox name, TextBox contact, TextBox email, DateTimePicker birthday)
        {
            this.parentform = parentform;
            this.name = name;
            this.contact = contact;
            this.email = email;
            this.birthday = birthday;
        }

        public void LoadData()
        {
            CustomerService _customerservice = new CustomerService("VegeMeat");
            customer = _customerservice.GetCustomerByCustomerId(SessionManager.Instance.CustomerId);
            name.Text = customer.name;
            contact.Text = customer.contact;
            email.Text = customer.email;
            if (customer.birthday != null)
            {
                birthday.Value = DateTime.ParseExact(customer.birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                birthday.Value = DateTime.Now;
            }

        }


        public void Update( string name, string contact, string email, string birthday)
        {
            CustomerService _customerservice = new CustomerService("VegeMeat");
            if (_customerservice.UpdateCustomer(SessionManager.Instance.CustomerId, name, contact, email, birthday))
            {
                MessageBox.Show("Update successfully!");
                CustomerProfile obj1 = new CustomerProfile();
                obj1.Show();
                parentform.Hide();
            }
            else
            {
                MessageBox.Show("Update failed!");
                return;
            }
        }
    }
}
