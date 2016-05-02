using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace php_srs
{
    class CurrentUser
    {
        private string currentUser = "";

        public void setUser(string user)
        {
            currentUser = user;
        }

        public string getUser()
        {
            return currentUser;
        }


    }
}
