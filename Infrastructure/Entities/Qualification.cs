using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Entities
{
	public class Qualification
	{
		public int Id { get; set; }
		
		[MaxLength(255)] 
		public string Name { get; set; } = null!;

		public int ExpertiseId { get; set; }
		public Expertise Expertise { get; set; } = null!;
	}
}
