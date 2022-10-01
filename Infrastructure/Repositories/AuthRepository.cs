using Salary_management.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Repositories
{
	public class AuthRepository : Repository
	{
		public bool CheckUserExist(string username, string password)
			=> Context.Auths.Any(a => a.Username == username && a.Password == password);

		public bool CheckUsernameExists(string username)
			=> Context.Auths.Any(a => a.Username == username);

		public Result<Auth> CreateUser(string username, string password)
		{
			if (!CheckUsernameExists(username))
				return new Result<Auth> { Success = false, ErrorMessage = "Username already exists."};

			var userAuth = new Auth { Username = username, Password = password };
			Context.Auths.Add(new Auth { Username = username, Password = password });
			Context.SaveChanges();
			return new Result<Auth> { Success = true, Payload = userAuth };
		}
	}
}
