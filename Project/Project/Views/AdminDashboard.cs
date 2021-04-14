using Project.Controllers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();

            reloadManager();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if(e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {
            managerLabel.BackColor = Color.DarkCyan;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            welcomePanel.Hide();
            salesmanPanel.Hide();
            managersPanel.Show();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = true;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.DarkCyan;

            ticketsLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            welcomePanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Show();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.DimGray;
            ticketsLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;

            welcomePanel.Show();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = false;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click_2(object sender, EventArgs e)
        {
            ticketsLabel.BackColor = Color.DarkCyan;

            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            welcomePanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            ticketsPanel.Show();

            homeLabel.Visible = true;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void logoutLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void busesLabel_Click(object sender, EventArgs e)
        {
            busesLabel.BackColor = Color.DarkCyan;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            welcomePanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            customersPanel.Hide();

            busesPanel.Show();

            homeLabel.Visible = true;
        }

        private void customersLabel_Click(object sender, EventArgs e)
        {
            customersLabel.BackColor = Color.DarkCyan;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;

            welcomePanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            busesPanel.Hide();

            customersPanel.Show();

            homeLabel.Visible = true;
        }

        private void managerAddBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void managerAddBtn_Click_1(object sender, EventArgs e)
        {
            var manager = new
            {
                name = managerName.Text,
                username = managerUsername.Text,
                password = managerPassword.Text,
            };

            if (manager.name.Trim().Length == 0 || manager.username.Trim().Length == 0 || manager.password.Trim().Length == 0)
            {
                MessageBox.Show("Fill all the required field");
                return;
            }
            bool result = ManagersController.AddManager(manager);
            if (result) 
            {
                managerName.Text = "";
                managerUsername.Text = "";
                managerPassword.Text = "";

                dynamic managerlist = ManagersController.getAllManager();
                managerGridView.DataSource = managerlist;

                MessageBox.Show("Manager Added");
            }
            else MessageBox.Show("Could not Add");

        }

        private void managerGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label28_Click(object sender, EventArgs e)
        {
            reloadManager();

        }

        public void reloadManager()
        {

            managerName.Text = "";
            managerUsername.Text = "";
            managerPassword.Text = "";
            managerSearchBox.Text = "";

            dynamic managerlist = ManagersController.getAllManager();
            managerGridView.DataSource = managerlist;
        }

        private void managerSearchBtn_Click(object sender, EventArgs e)
        {
            string username = managerSearchBox.Text;
            var manager = ManagersController.getSingleManager(username);
            if (manager == null)
            {
                MessageBox.Show("Manager not found");
            }
            else
            {
                managerName.Text = manager.Name;
                managerUsername.Text = manager.Username;
                managerPassword.Text = manager.Password;
            }

        }

        private void managerUpdateBtn_Click(object sender, EventArgs e)
        {
            string username = managerSearchBox.Text;
            var manager = ManagersController.getSingleManager(username);

            if (manager == null)
            {
                MessageBox.Show("Search a manager first");
                return;
            }

            var newManager = new
            {
                id = manager.Id,
                name = managerName.Text,
                username = managerUsername.Text,
                password = managerPassword.Text
            };

            bool res = ManagersController.updateManager(newManager);
            if (res)
            {
                reloadManager();

                MessageBox.Show("Manager updated");
            }
            else MessageBox.Show("Could not updated");
        }

        private void managerDeleteBtn_Click(object sender, EventArgs e)
        {
            string username = managerSearchBox.Text;
            var manager = ManagersController.getSingleManager(username);

            if (manager == null)
            {
                MessageBox.Show("Search a manager first");
                return;
            }

            bool res = ManagersController.deleteManager(manager.Id);
            if (res)
            {
                reloadManager();

                MessageBox.Show("Manager Deleted");
            }
            else MessageBox.Show("Could not Delete");
        }
    }
}
