using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameTB.Text.Trim();
            string password = passwordTB.Text.Trim();
            string role = comboBox.Text.ToString().Trim();

            if(username.Length==0 || password.Length == 0)
            {
                MessageBox.Show("Fill all the required field");
                return;
            }
            
            if (role.ToLower().Equals("admin") || role.ToLower().Equals("manager") || role.ToLower().Equals("salesman"))
            {
                SqlConnection conn = Database.ConnectDB();
                conn.Open();

                string query = string.Format("select Username, Password from {0} where Username='{1}' and Password='{2}'", role, username, password);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                bool auth = false;
                while (reader.Read()) auth = true;

                if (auth)
                {
                    this.Hide();
                    new AdminDashboard().Show();
                }
                else MessageBox.Show("Invalid Credentials");
            }
            else
            {
                MessageBox.Show("Choose a Valid Role");
            }
            
        }
    }
}
