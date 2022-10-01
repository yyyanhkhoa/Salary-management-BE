using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.DataFake
{
    internal class User
    {
        int id;
        string username;
        string password;

        public User(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        public string GetUserName() { return username; }
        public string GetPassWord() { return password; }

    }
}
