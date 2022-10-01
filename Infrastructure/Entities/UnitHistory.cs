using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Entities
{
	public class UnitHistory
	{
		public DateOnly StartDate { get; set; }
		public DateOnly EndDate { get; set; }

		public string StaffId { get; set; } = null!;
		public Staff Staff { get; set; } = null!;

		public string UnitId { get; set; } = null!;
		public Unit Unit { get; set; } = null!;
	}
}
