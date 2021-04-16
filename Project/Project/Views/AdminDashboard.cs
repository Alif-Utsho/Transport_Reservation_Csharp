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

            reloadTickets();
            reloadManager();
            reloadSalesman();
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
                name = managerName.Text.Trim(),
                username = managerUsername.Text.Trim(),
                password = managerPassword.Text.Trim(),
            };

            if (manager.name.Length == 0 || manager.username.Length == 0 || manager.password.Length == 0)
            {
                MessageBox.Show("Fill all the required field");
                return;
            }
            bool result = ManagersController.AddManager(manager);
            if (result) 
            {
                reloadManager();
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
            if(newManager.name.Length==0 || newManager.username.Length==0 || newManager.password.Length == 0)
            {
                MessageBox.Show("Fill all the required fields");
                return;
            }

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

        public void reloadSalesman()
        {
            salesmanName.Text = "";
            salesmanUsername.Text = "";
            salesmanPassword.Text = "";
            salesmanSearchBox.Text = "";

            dynamic salesmanlist = SalesmanController.getAllSalesman();
            salesmanGridView.DataSource = salesmanlist;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Salesman Add
            var salesman = new
            {
                name = salesmanName.Text.Trim(),
                username = salesmanUsername.Text.Trim(),
                password = salesmanPassword.Text.Trim()
            };

            if(salesman.name.Length==0 || salesman.username.Length==0 || salesman.password.Length == 0)
            {
                MessageBox.Show("Fill all the required field");
                return;
            }
            bool res = SalesmanController.addSalesman(salesman);
            if (res)
            {
                reloadSalesman();
                MessageBox.Show("Salesman Added");
            }
            else MessageBox.Show("Could not be added");
        }

        private void salesmanSearchBtn_Click(object sender, EventArgs e)
        {
            string username = salesmanSearchBox.Text.Trim();
            dynamic salesman = SalesmanController.searchSalesman(username);
            if (salesman == null)
            {
                MessageBox.Show("Salesman not Found");
                return;
            }
            salesmanName.Text = salesman.Name;
            salesmanUsername.Text = salesman.Username;
            salesmanPassword.Text = salesman.Password;
        }

        private void salesmanUpdateBtn_Click(object sender, EventArgs e)
        {
            string username = salesmanSearchBox.Text.Trim();
            dynamic salesman = SalesmanController.searchSalesman(username);
            if (salesman == null)
            {
                MessageBox.Show("Search a Salesman First");
                return;
            }
            var newSalesman = new
            {
                id = salesman.Id,
                name = salesmanName.Text.Trim(),
                username = salesmanUsername.Text.Trim(),
                password = salesmanPassword.Text.Trim()
            };
            if(newSalesman.name.Length==0 || newSalesman.username.Length==0 || newSalesman.password.Length == 0)
            {
                MessageBox.Show("Fill all the required fields");
                return;
            }
            bool res = SalesmanController.updateSalesman(newSalesman);
            if (res)
            {
                reloadSalesman();
                MessageBox.Show("Salesman Updated");
            }
            else MessageBox.Show("Could not update Salesman");
        }

        private void salesmanDeleteBtn_Click(object sender, EventArgs e)
        {
            string username = salesmanSearchBox.Text.Trim();
            dynamic salesman = SalesmanController.searchSalesman(username);
            if (salesman == null)
            {
                MessageBox.Show("Search a Salesman First");
                return;
            }
            else if (salesman.Name.Length == 0 || salesman.Username.Length == 0 || salesman.Password.Length == 0)
            {
                MessageBox.Show("Fill all the required fields");
                return;
            }
            bool res = SalesmanController.deleteSalesman(salesman.Id);
            if (res)
            {
                reloadSalesman();
                MessageBox.Show("Salesman Deleted");
            }
            else MessageBox.Show("Could not Delete");
        }
        string bustype = "";
        int ticketId = 0;

        public void reloadTickets()
        {
            ticketId = 0;
            customerName.Text = "";
            phoneBox.Text = "";
            ticketSource.Text = "From";
            ticketDest.Text = "To";
            coachBox.Text = "Coach";
            acRadioBtn.Checked = false;
            nonAcRadioBtn.Checked = false;
            journeyDate.Text = DateTime.Now.ToString();
            journeyTime.Text = "";

            ticketBookBtn.Enabled = true;

            var tickets = TicketsController.getAllTickets();
            ticketsGridView.DataSource = tickets;
        }
        private void ticketBookBtn_Click(object sender, EventArgs e)
        {
            var ticket = new
            {
                name = customerName.Text.Trim(),
                phone = phoneBox.Text.Trim(),
                source = ticketSource.Text.Trim(),
                destination = ticketDest.Text.Trim(),
                coach = coachBox.Text.Trim(),
                type = bustype,
                date = journeyDate.Value.ToShortDateString(),
                time = journeyTime.Text.Trim()
            };
            if(ticket.name.Length==0 || ticket.phone.Length==0 || ticket.source.Equals("Source") || ticket.destination.Equals("To") ||
                ticket.coach.Equals("Coach") || ticket.type.Length== 0 || ticket.time.Equals("Time"))
            {
                MessageBox.Show("Fill all the required fields");
                return;
            }
            try
            {
                bool res = TicketsController.boolTicket(ticket);
                if (res)
                {
                    reloadTickets();
                    MessageBox.Show("Ticket booked");
                }
                else MessageBox.Show("Could not booked");
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bustype = "AC";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bustype = "Non AC";
        }

        private void ticketsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ticketsGridView.Rows[e.RowIndex];
                ticketId = Int32.Parse(row.Cells["Id"].Value.ToString());
                customerName.Text = row.Cells["Name"].Value.ToString();
                phoneBox.Text = row.Cells["Phone"].Value.ToString();
                ticketSource.Text = row.Cells["Source"].Value.ToString();
                ticketDest.Text = row.Cells["Destination"].Value.ToString();
                coachBox.Text = row.Cells["Coach"].Value.ToString();
                //busType.Text = row.Cells["BusType"].Value.ToString();
                journeyDate.Text = row.Cells["Date"].Value.ToString();
                journeyTime.Text = row.Cells["Time"].Value.ToString();

                var abustype = row.Cells["BusType"].Value.ToString();
                if (abustype.Equals("AC"))
                {
                    acRadioBtn.Checked = true;
                    nonAcRadioBtn.Checked = false;
                }
                else if (abustype == "Non AC")
                {
                    nonAcRadioBtn.Checked = true;
                    acRadioBtn.Checked = false;
                }
                else
                {
                    acRadioBtn.Checked = false;
                    nonAcRadioBtn.Checked = false;
                }

                if (ticketId > 0)
                {
                    ticketBookBtn.Enabled = false;
                }
                trashTicket.Visible = true;
            }
        }

        private void label28_Click_1(object sender, EventArgs e)
        {
            reloadTickets();
            trashTicket.Visible = false;
        }
    }
}
