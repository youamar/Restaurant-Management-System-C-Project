using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService (string connectionString)
        {
            _customerRepository = new CustomerRepository(connectionString);
        }

        public CustomerModel GetCustomerByContact(string contact)
        {
            return _customerRepository.GetCustomerByContact(contact);
        }

        public CustomerModel GetCustomerByCustomerId(string customer_id)
        {
            return _customerRepository.GetCustomerByCustomerId(customer_id);
        }

        public List<CustomerModel> GetAllCustomerContact()
        {
            return _customerRepository.GetAllCustomerContact();
        }

        public List<CustomerModel> GetAllCustomer()
        {
            return _customerRepository.GetAllCustomer();
        }

        public bool AddCustomer(string customer_id, string contact)
        {
            var CustomerModels = new CustomerModel { customer_id = customer_id, contact = contact };
            return _customerRepository.AddCustomer(CustomerModels);
        }

        public bool AddCustomerProfile(string customer_id, string name, string contact, string email, string birthday)
        {
            var CustomerModels = new CustomerModel { customer_id = customer_id, name = name, contact = contact, email = email, birthday = birthday };
            return _customerRepository.AddCustomerProfile(CustomerModels);
        }

        public bool UpdateCustomer(string customer_id, string name, string contact, string email, string birthday)
        {
            var CustomerModels = new CustomerModel { name = name, contact = contact, email = email, birthday = birthday };
            return _customerRepository.UpdateCustomer(CustomerModels, customer_id);
        }

        public bool DeleteCustomer(string customer_id)
        {
            return _customerRepository.DeleteCustomer(customer_id);
        }
    }
}
