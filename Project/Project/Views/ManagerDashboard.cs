using Project.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Views
{
    public partial class ManagerDashboard : Form
    {
        string bustype = "";
        int ticketId = 0;
        int managerId = 0;
        int salesmanId = 0;
        int customerId = 0;
        int busId = 0;

        public ManagerDashboard()
        {
            InitializeComponent();

            reloadTickets();
            reloadManager();
            reloadSalesman();
            reloadCustomer();
            reloadBuses();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void logoutLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void managerLabel_Click(object sender, EventArgs e)
        {
            managerLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            salesmanPanel.Hide();
            managersPanel.Show();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = true;

        }

        private void salesmanLabel_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Show();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = true;
        }

        private void homeIcon_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.DimGray;
            ticketsLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Show();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            homeLabel.Visible = false;
        }

        private void tickets_Click_2(object sender, EventArgs e)
        {
            ticketsLabel.BackColor = Color.Teal;

            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            busesPanel.Hide();
            customersPanel.Hide();

            ticketsPanel.Show();

            homeLabel.Visible = true;
        }

        private void busesLabel_Click(object sender, EventArgs e)
        {
            busesLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            customersLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            customersPanel.Hide();

            busesPanel.Show();

            homeLabel.Visible = true;
        }

        private void customersLabel_Click(object sender, EventArgs e)
        {
            customersLabel.BackColor = Color.Teal;

            ticketsLabel.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            busesLabel.BackColor = Color.DimGray;

            AdminPanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();
            busesPanel.Hide();

            customersPanel.Show();

            homeLabel.Visible = true;
        }

        public void reloadManager()
        {

            managerName.Text = "";
            managerUsername.Text = "";
            managerPassword.Text = "";
            managerSearchBox.Text = "";

            managerId = 0;
            managerTrash.Visible = false;
            managerAddBtn.Enabled = true;

            dynamic managerlist = ManagersController.getAllManager();
            managerGridView.DataSource = managerlist;
        }
        public void reloadTickets()
        {
            ticketId = 0;
            customerName.Text = "";
            phoneBox.Text = "";
            ticketSource.Text = "From";
            ticketDest.Text = "To";
            coachBox.Text = "Coach";
            acRadioButton.Checked = false;
            nonAcRadioButton.Checked = false;
            journeyDate.Text = DateTime.Now.ToShortDateString();
            journeyTime.Text = "Time";

            journeyDate.MinDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            // for manager and salesman
            journeyDate.MaxDate = DateTime.Parse(DateTime.Now.AddDays(6).ToShortDateString());

            ticketBookBtn.Enabled = true;
            trashTicket.Visible = false;

            var tickets = TicketsController.getAllTickets();
            ticketsGridView.DataSource = tickets;
        }
        public void reloadSalesman()
        {
            salesmanName.Text = "";
            salesmanUsername.Text = "";
            salesmanPassword.Text = "";
            salesmanSearchBox.Text = "";

            salesmanId = 0;
            salesmanAddBtn.Enabled = true;
            salesmanTrash.Visible = false;

            dynamic salesmanlist = SalesmanController.getAllSalesman();
            salesmanGridView.DataSource = salesmanlist;
        }
        public void reloadCustomer()
        {
            customerId = 0;
            customerNameBox.Text = "";
            customerPhoneBox.Text = "";
            customerSearchBox.Text = "";
            customerTrash.Visible = false;

            var customerlist = CustomerController.getAllCustomer();
            customerGridView.DataSource = customerlist;
        }
        public void reloadBuses()
        {
            busSearchBox.Text = "";
            busCoachBox.Text = "";
            busAcRadio.Checked = false;
            busNonAcRadio.Checked = false;

            busId = 0;

            busTrash.Visible = false;
            busAddBtn.Enabled = true;

            var bus = BusesController.getAllBus();
            busGridView.DataSource = bus;
        }


        //////// TICKET PANEL  ///////
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

            bool res = TicketsController.boolTicket(ticket);
            if (res) { reloadTickets(); reloadCustomer(); MessageBox.Show("Ticket booked"); }
        }

        private void acRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bustype = "AC";
        }

        private void nonAcRadioButton2_CheckedChanged(object sender, EventArgs e)
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
                journeyTime.Text = row.Cells["Time"].Value.ToString();

                DateTime date = DateTime.Parse(row.Cells["Date"].Value.ToString());
                if (date < journeyDate.MinDate)
                {
                    MessageBox.Show("You cannot modify or delete previous Tickets");
                    reloadTickets();
                    return;
                }
                else if(date > journeyDate.MaxDate)
                {
                    MessageBox.Show("Manager cannot modify or delete Special type of Tickets");
                    reloadTickets();
                    return;
                }
                else journeyDate.Text = date.ToString();

                var abustype = row.Cells["BusType"].Value.ToString();
                if (abustype.Equals("AC"))
                {
                    acRadioButton.Checked = true;
                    nonAcRadioButton.Checked = false;
                }
                else if (abustype == "Non AC")
                {
                    nonAcRadioButton.Checked = true;
                    acRadioButton.Checked = false;
                }
                else
                {
                    acRadioButton.Checked = false;
                    nonAcRadioButton.Checked = false;
                }

                if (ticketId > 0)
                {
                    ticketBookBtn.Enabled = false;
                }
                trashTicket.Visible = true;
            }
        }

        private void ticketTrash_Click_1(object sender, EventArgs e)
        {
            reloadTickets();
            trashTicket.Visible = false;
        }

        private void ticketCancelBtn_Click(object sender, EventArgs e)
        {
            bool res = TicketsController.cancelTicket(ticketId);
            if (res) { reloadTickets(); MessageBox.Show("Ticket Cancelled"); }
        }

        private void ticketUpdateBtn_Click(object sender, EventArgs e)
        {
            var ticket = new
            {
                id = ticketId,
                name = customerName.Text.Trim(),
                phone = phoneBox.Text.Trim(),
                source = ticketSource.Text.Trim(),
                destination = ticketDest.Text.Trim(),
                coach = coachBox.Text.Trim(),
                type = bustype,
                date = journeyDate.Value.ToShortDateString(),
                time = journeyTime.Text.Trim()
            };

            bool res = TicketsController.updateTicket(ticket);
            if (res) { reloadTickets(); MessageBox.Show("Ticket updated"); }
        }
        private void ticketSearchBtn_Click(object sender, EventArgs e)
        {
            string phone = phoneBox.Text;
            var customer = CustomerController.searchCustomer(phone);
            if (customer != null)
            {
                customerName.Text = customer.Name;
            }
            else customerName.Text = "";
        }

        /////////// MANAGER PANEL //////////////

        private void managerAddBtn_Click(object sender, EventArgs e)
        {
            var manager = new
            {
                name = managerName.Text.Trim(),
                username = managerUsername.Text.Trim(),
                password = managerPassword.Text.Trim(),
            };
            bool res = ManagersController.AddManager(manager);
            if (res) { reloadManager(); MessageBox.Show("Manager Added"); }
        }


        private void managerTrash_Click(object sender, EventArgs e)
        {
            reloadManager();
        }

        private void managerSearchBtn_Click(object sender, EventArgs e)
        {
            string username = managerSearchBox.Text;
            var manager = ManagersController.getSingleManager(username);

            if (manager == null)
            {
                MessageBox.Show("Manager not found");
                return;
            }
            else
            {
                managerName.Text = manager.Name;
                managerUsername.Text = manager.Username;
                managerPassword.Text = manager.Password;
            }
            managerId = manager.Id;
            managerTrash.Visible = true;
            managerAddBtn.Enabled = false;
        }

        private void managerUpdateBtn_Click(object sender, EventArgs e)
        {
            var newManager = new
            {
                id = managerId,
                name = managerName.Text,
                username = managerUsername.Text,
                password = managerPassword.Text
            };

            bool res = ManagersController.updateManager(newManager);
            if (res) { reloadManager(); MessageBox.Show("Manager updated"); }
        }

        private void managerDeleteBtn_Click(object sender, EventArgs e)
        {
            bool res = ManagersController.deleteManager(managerId);
            if (res) { reloadManager(); MessageBox.Show("Manager Deleted"); }
        }

        /////  SALESMAN PANEL /////

        private void salesmanAddBtn_Click(object sender, EventArgs e)
        {
            var salesman = new
            {
                name = salesmanName.Text.Trim(),
                username = salesmanUsername.Text.Trim(),
                password = salesmanPassword.Text.Trim()
            };

            bool res = SalesmanController.addSalesman(salesman);
            if (res) { reloadSalesman(); MessageBox.Show("Salesman Added"); }
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

            salesmanId = salesman.Id;
            salesmanAddBtn.Enabled = false;
            salesmanTrash.Visible = true;

            salesmanName.Text = salesman.Name;
            salesmanUsername.Text = salesman.Username;
            salesmanPassword.Text = salesman.Password;
        }

        private void salesmanUpdateBtn_Click(object sender, EventArgs e)
        {
            var newSalesman = new
            {
                id = salesmanId,
                name = salesmanName.Text.Trim(),
                username = salesmanUsername.Text.Trim(),
                password = salesmanPassword.Text.Trim()
            };

            bool res = SalesmanController.updateSalesman(newSalesman);
            if (res)
            {
                reloadSalesman();
                MessageBox.Show("Salesman Updated");
            }
        }

        private void salesmanDeleteBtn_Click(object sender, EventArgs e)
        {
            bool res = SalesmanController.deleteSalesman(salesmanId);
            if (res) { reloadSalesman(); MessageBox.Show("Salesman Deleted"); }
        }
        private void salesmanTrash_Click(object sender, EventArgs e)
        {
            reloadSalesman();
        }

        ///// BUSES PANEL /////
        string busType = "";
        private void busAcRadio_CheckedChanged(object sender, EventArgs e)
        {
            busType = "AC";
        }

        private void busNonAcRadio_CheckedChanged(object sender, EventArgs e)
        {
            busType = "Non AC";
        }


        private void busAddBtn_Click(object sender, EventArgs e)
        {
            var bus = new
            {
                coach = busCoachBox.Text.Trim(),
                type = busType,
            };

            bool res = BusesController.addBus(bus);
            if (res) { reloadBuses(); MessageBox.Show("Bus Added"); }
        }

        private void busSearchBtn_Click(object sender, EventArgs e)
        {
            string coach = busSearchBox.Text.Trim();
            var bus = BusesController.searchBus(coach);
            if (bus == null)
            {
                MessageBox.Show("Bus not found");
                return;
            }
            busCoachBox.Text = bus.Coach;
            if (bus.Type == "AC") busAcRadio.Checked = true;
            else busNonAcRadio.Checked = true;

            busId = bus.Id;

            busAddBtn.Enabled = false;
            busTrash.Visible = true;
        }

        private void busTrash_Click(object sender, EventArgs e)
        {
            reloadBuses();
        }

        private void busUpdateBtn_Click(object sender, EventArgs e)
        {
            var bus = new
            {
                id = busId,
                coach = busCoachBox.Text.Trim(),
                type = busType,
            };

            bool res = BusesController.updateBus(bus);
            if (res) { reloadBuses(); MessageBox.Show("Bus updated"); }
        }

        private void busRemoveBtn_Click(object sender, EventArgs e)
        {
            bool res = BusesController.deleteBus(busId);
            if (res) { reloadBuses(); MessageBox.Show("Bus deleted"); }
        }


        ///// CUSTOMERS PANEL  /////

        private void customerSearchBtn_Click(object sender, EventArgs e)
        {
            string phone = customerSearchBox.Text;
            var customer = CustomerController.searchCustomer(phone);
            if (customer == null)
            {
                MessageBox.Show("Customer not found");
                return;
            }
            customerId = customer.Id;
            customerNameBox.Text = customer.Name;
            customerPhoneBox.Text = customer.Phone;
            customerTrash.Visible = true;
        }

        private void customerTrash_Click(object sender, EventArgs e)
        {
            reloadCustomer();
        }

        private void customerRemoveBtn_Click(object sender, EventArgs e)
        {
            bool res = CustomerController.deleteCustomer(customerId);
            if (res) { reloadCustomer(); MessageBox.Show("Customer Deleted"); }
        }

        private void customerUpdateBtn_Click(object sender, EventArgs e)
        {
            var newCustomer = new
            {
                id = customerId,
                name = customerNameBox.Text,
                phone = customerPhoneBox.Text
            };

            bool res = CustomerController.updateCustomer(newCustomer);
            if (res) { reloadCustomer(); MessageBox.Show("Customer Updated"); }
        }
    }
}
