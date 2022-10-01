using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Entities
{
	public class QualificationAllowanceHistory
	{
		public int Year { get; set; }
		public int Allowance { get; set; }

		public int QualificationId { get; set; }
		public Qualification Qualification { get; set; } = null!;
	}
}
