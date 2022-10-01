using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salary_management.Infrastructure.Entities.Enums;

namespace Salary_management.Infrastructure.Entities
{
	public class Relative
	{
		public int Id { get; set; }
		public DateOnly DateOfBirth { get; set; }

		[MaxLength(255)]
		public string Occupation { get; set; } = null!;

		public RelativeType RelativeType { get; set; }

		public string StaffId { get; set; } = null!;
		public Staff Staff { get; set; } = null!;
	}
}
