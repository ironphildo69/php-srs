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
        public Login()
        {
            InitializeComponent();
        }

        private void enter_b_Click(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            Program program = new Program();
            string username = userlog_t.Text;
            string password = passlog_t.Text;

            bool check = ul.checkUserLoginTable(username, password);

            if (check)
            {
                //quit login
                //open window?
                program.setUser(username);
                this.Close();

            } else {
                //Please try again
                error_l.Text = "Username or Password incorrect. Please try again.";
            }

            userlog_t.Clear();
            passlog_t.Clear();
            error_l.Text = "";
        }

        private void quit_b_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
