using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Entities
{
	public class StaffQualification
	{
		public float Score { get; set; }

		public DateOnly IssueDate { get; set; }

		[MaxLength(255)]
		public string PlaceOfIssue { get; set; } = null!;

		public int QualificationId { get; set; }
		public Qualification Qualification { get; set; } = null!;

		public string StaffId { get; set; } = null!;
		public Staff Staff { get; set; } = null!;
	}
}
