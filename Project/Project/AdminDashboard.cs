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
        }


        private void label3_Click(object sender, EventArgs e)
        {
            managerLabel.BackColor = Color.DarkCyan;

            label2.BackColor = Color.DimGray;
            salesmanLabel.BackColor = Color.DimGray;
            label5.BackColor = Color.DimGray;

            welcomePanel.Hide();
            salesmanPanel.Hide();
            managersPanel.Show();
            ticketsPanel.Hide();

            home.Visible = true;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.DarkCyan;

            label2.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            label5.BackColor = Color.DimGray;

            welcomePanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Show();
            ticketsPanel.Hide();

            home.Visible = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            salesmanLabel.BackColor = Color.DimGray;
            label2.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            label5.BackColor = Color.DimGray;

            welcomePanel.Show();
            managersPanel.Hide();
            salesmanPanel.Hide();
            ticketsPanel.Hide();

            home.Visible = false;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click_2(object sender, EventArgs e)
        {
            label2.BackColor = Color.DarkCyan;

            salesmanLabel.BackColor = Color.DimGray;
            managerLabel.BackColor = Color.DimGray;
            label5.BackColor = Color.DimGray;

            welcomePanel.Hide();
            managersPanel.Hide();
            salesmanPanel.Hide();

            ticketsPanel.Show();

            home.Visible = true;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
    }
}
