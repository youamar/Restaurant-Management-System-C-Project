using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class CustomerProfileControl
    {
        private string customer_id;
        private Label name;
        private Label contact;
        private Label email;
        private Label birthday;
        private CustomerModel customer;

        public CustomerProfileControl(Label name, Label contact, Label email, Label birthday)
        {
            this.name = name;
            this.contact = contact;
            this.email = email;
            this.birthday = birthday;
        }

        public CustomerProfileControl(string customer_id, Label name, Label contact, Label email, Label birthday)
        {
            this.customer_id = customer_id;
            this.name = name;
            this.contact = contact;
            this.email = email;
            this.birthday = birthday;
        }

        public void LoadData()
        {
            CustomerService _customerservice = new CustomerService("VegeMeat");
            customer = _customerservice.GetCustomerByCustomerId(SessionManager.Instance.CustomerId);
            name.Text = $"Name : {customer.name}";
            contact.Text = $"Phone Number : 60{customer.contact}";
            email.Text = $"Email Address : {customer.email}";
            birthday.Text = $"Birthday : {customer.birthday}";
        }

        public void LoadCustomerData()
        {
            CustomerService _customerservice = new CustomerService("VegeMeat");
            customer = _customerservice.GetCustomerByCustomerId(customer_id);
            name.Text = $"Name : {customer.name}";
            contact.Text = $"Phone Number : 60{customer.contact}";
            email.Text = $"Email Address : {customer.email}";
            birthday.Text = $"Birthday : {customer.birthday}";
        }
    }
}
