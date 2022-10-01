using Salary_management.Infrastructure.Entities;
using Salary_management.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.DataFake
{
    internal class LocalUser
    {
        int mark = 0;
        List<User> _users;
		AuthRepository _authRepo = new AuthRepository();

        public LocalUser(int mark, List<User> users)
        {
            this.mark = mark;
            _users = users;
        }

        public void createNewUser(string username, string password)
        {
			var result = _authRepo.CreateUser(username, password);

			if (result.Success)
			{
				mark++;
				User newUser = new User(result.Payload.Id, username, password);
				_users.Add(newUser);
			}
		}

        public bool checkUserExist(string username, string password)
			=> new AuthRepository().CheckUserExist(username, password);
    }
}
