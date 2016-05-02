using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace php_srs
{
    class LoginHandler
    {
        private int count = 0;
        private string user = "";

        public LoginHandler()
        {
            CurrentUser cu = new CurrentUser();

            while (count == 0)
            {
                LoginScreen(cu);
                ProgramScreen(cu);                
            }
        }

        public void LoginScreen(CurrentUser cu)
        {
            Login log = new Login();
            Application.Run(log);
            user = log.getUser();
            cu.setUser(user);
        }

        public void ProgramScreen(CurrentUser cu)
        {
            Window win = new Window();
            win.setUser(cu.getUser());
            Application.Run(win);        
        }   
    }
}
