using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(string connectionString)
        {
            _roleRepository = new RoleRepository(connectionString);
        }

        public RoleModel GetRoleByID(string role_id)
        {
            return _roleRepository.GetRoleByID(role_id);
        }

        public RoleModel AdminGetRoleByID(string role_id)
        {
            return _roleRepository.AdminGetRoleByID(role_id);
        }

        public List<RoleModel> GetAllRole()
        {
            return _roleRepository.GetAllRole();
        }

        public List<RoleModel> GetRevenueByChef()
        {
            return _roleRepository.GetRevenueByChef();
        }

        public bool AddRole(string role_id, string password, string name, string ic, string contact, string email, string role)
        {
            var roleModels = new RoleModel { role_id = role_id, role_password = password, role_name = name, role_ic = ic, role_contact = contact, role_email = email, role = role };
            return _roleRepository.AddRole(roleModels);
        }

        public bool UpdateRole(string role_id, string name, string ic, string contact, string email)
        {
            var roleModels = new RoleModel { role_name = name, role_ic = ic, role_contact = contact, role_email = email };
            return _roleRepository.UpdateRole(roleModels, role_id);
        }

        public bool AdminUpdateRole(string role_id, string password, string name, string ic, string contact, string email, string role)
        {
            var roleModels = new RoleModel { role_name = name, role_password = password, role_ic = ic, role_contact = contact, role_email = email, role = role };
            return _roleRepository.AdminUpdateRole(roleModels, role_id);
        }

        public bool UpdatePassword(string role_id, string password)
        {
            return _roleRepository.UpdatePassword(role_id, password);
        }

        public bool DeleteRole(string role_id)
        {
            var roleModels = new RoleModel { role_id = role_id };
            return (_roleRepository.DeleteRole(role_id));
        }
    }
}
