using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;
using Main_Page.Role;

namespace Main_Page
{
    internal class Role_Login_Control
    {
        private string id;
        private string pass;
        Form parentform;


        public Role_Login_Control(string id, string pass, Form parentform)
        {
            this.id = id;
            this.pass = pass;
            this.parentform = parentform;
        }

        public void CheckStaff()
        {
            if (id == "")
            {
                MessageBox.Show("Enter Your Id");
            }
            else if (pass == "")
            {
                MessageBox.Show("Enter your Password");
            }
            else
            {
                RoleService _roleservice = new RoleService("VegeMeat");
                RoleModel result = _roleservice.GetRoleByID(id);
                if (result == null)
                {
                    MessageBox.Show("No Record Found!\nTry Again!");
                }
                else if (pass != result.role_password.ToString())
                {
                    MessageBox.Show("Password incorrect!\nTry Again!");
                }
                else
                {
                    SessionManager.Instance.RoleId = id;

                    if (result.role == "Admin")
                    {
                        ManageRole manageRole = new ManageRole();
                        manageRole.Show();
                        parentform.Hide();
                    }
                    if (result.role == "Manager")
                    {
                        ManageMenu menu = new ManageMenu();
                        menu.Show();
                        parentform.Hide();
                    }
                    if (result.role == "Reservation Coordinator")
                    {
                        ManageReservation reservation = new ManageReservation();
                        reservation.Show();
                        parentform.Hide();
                    }
                    if (result.role == "Chef")
                    {
                        TakeOrder takeorder = new TakeOrder();
                        takeorder.Show();
                        parentform.Hide();
                    }

                    MessageBox.Show("Login Sucessfully!");
                }
            }
        }
    }
}