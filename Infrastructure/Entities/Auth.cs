using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Entities
{
	public class Auth
	{
		public int Id { get; set; }
		public string Username { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
