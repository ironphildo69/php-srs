using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace php_srs
{
    public partial class Login : Form
    {
        private string user;

        public Login()
        {
            InitializeComponent();
        }
        
        public string getUser()
        {
            return user;
        }

        private void enter_b_Click(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            string username = userlog_t.Text;
            string password = passlog_t.Text;

            bool check = ul.checkUserLoginTable(username, password);

            if (check)
            {
                user = username; 
                this.Close();

            } else {
                MessageBox.Show("Username or Password incorrect. Please try again.", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            userlog_t.Clear();
            passlog_t.Clear();
        }

        private void quit_b_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
