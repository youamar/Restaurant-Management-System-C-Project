using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;
using System.Windows.Forms;

namespace Main_Page
{
    internal class ManageCustomerControl
    {
        private readonly RoleService _roleService;
        private RoleModel _roleModel;

        private readonly CustomerService _customerService;
        private List<CustomerModel> customers;
        private CustomerModel customer;

        private ListBox listBox;
        private Label[] labels;
        private GroupBox groupBox;

        public ManageCustomerControl(ListBox listBox, Label[] labels, GroupBox groupBox)
        {
            _roleService = new RoleService("VegeMeat");
            _customerService = new CustomerService("VegeMeat");

            this.listBox = listBox;
            this.labels = labels;
            this.groupBox = groupBox;
        }

        public string RoleName()
        {
            _roleModel = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{_roleModel.role} {_roleModel.role_name.Split(' ')[0]}";
        }

        public void LoadCustomerID()
        {
            listBox.SelectedIndexChanged -= OnSelectedIndexChanged;

            customers = _customerService.GetAllCustomerContact();
            listBox.Items.Clear();
            foreach (var customer in customers)
            {
                listBox.Items.Add($"{customer.customer_id} - 0{customer.contact}");
            }

            listBox.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e) { }

        public void ShowCustomerDetails()
        {
            if (listBox.SelectedIndex == -1) return;


            var selectedCustomer = customers[listBox.SelectedIndex];

            customer = _customerService.GetCustomerByCustomerId(selectedCustomer.customer_id);

            groupBox.Text = customer.customer_id.ToString();
            labels[0].Text = $"Name : {customer.name}";
            labels[1].Text = $"Phone Number : {customer.contact}";
            labels[2].Text = $"Email Address : {customer.email}";
            labels[3].Text = $"Birthday : {customer.birthday}";
        }

        public void AddNewCustomer()
        {
            AdminCustomerEdit addForm = new AdminCustomerEdit(null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerID();
            }
        }

        public void EditItem()
        {
            if (listBox.SelectedIndex < 0 || listBox.SelectedIndex >= customers.Count)
            {
                MessageBox.Show("Please select a staff to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AdminCustomerEdit editForm = new AdminCustomerEdit(customers[listBox.SelectedIndex]);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerID();
            }
        }

        public void DeleteCustomer()
        {
            if (listBox.SelectedIndex < 0 || listBox.SelectedIndex >= customers.Count)
            {
                MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRole = customers[listBox.SelectedIndex];
            var confirmResult = MessageBox.Show($"Are you sure you want to delete {selectedRole.contact}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                if (_customerService.DeleteCustomer(selectedRole.customer_id))
                {
                    MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomerID();
                }
                else
                {
                    MessageBox.Show("Failed to delete customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
