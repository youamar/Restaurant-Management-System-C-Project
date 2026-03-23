using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;
using System.Windows.Forms;

namespace Main_Page
{
    internal class AdminCustomerEditControl
    {
        private CustomerService customerService;
        private CustomerModel customer;

        private TextBox[] boxs;
        private Label title;
        private Form parentForm;

        private bool _isEditMode;

        public AdminCustomerEditControl(Form parentForm, CustomerModel customer, TextBox[] textBoxes, Label title)
        {
            customerService = new CustomerService("VegeMeat");

            this.parentForm = parentForm;
            this.customer = customer;
            this.boxs = textBoxes;
            this.title = title;

            _isEditMode = customer != null;
        }

        public void LoadCustomerData()
        {
            if (_isEditMode)
            {
                title.Text = "Editing Customer Details ";

                boxs[0].Text = customer.name;
                boxs[1].Text = customer.contact;
                boxs[2].Text = customer.email;
                boxs[3].Text = customer.birthday;
            }
            else
            {
                title.Text = "Please Add a new customer details";
            }
        }

        public void SaveChanges()
        {
            if (string.IsNullOrWhiteSpace(boxs[0].Text) ||
                string.IsNullOrWhiteSpace(boxs[1].Text) ||
                string.IsNullOrWhiteSpace(boxs[2].Text) ||
                string.IsNullOrWhiteSpace(boxs[3].Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_isEditMode)
            {
                bool success = customerService.UpdateCustomer(customer.customer_id, boxs[0].Text, boxs[1].Text, boxs[2].Text, boxs[3].Text);
                if (success)
                {
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to update customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var count = customerService.GetAllCustomer();
                string customer_id = $"C{count.Count + 1}";

                bool success = customerService.AddCustomerProfile(customer_id, boxs[0].Text, boxs[1].Text, boxs[2].Text, boxs[3].Text);
                if (success)
                {
                    MessageBox.Show("New customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to add customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
