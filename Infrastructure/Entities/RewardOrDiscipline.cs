using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Entities
{
	public class RewardOrDiscipline
	{
		public int Id { get; set; }
		public bool IsReward { get; set; }
		
		[MaxLength(255)]
		public string Level { get; set; } = null!;
		
		public DateOnly Date { get; set; }
		public string Content { get; set; } = null!;

		public string StaffId { get; set; } = null!;
		public Staff Staff { get; set; } = null!;
	}
}