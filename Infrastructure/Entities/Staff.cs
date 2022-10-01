using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Salary_management.Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure.Entities
{
	public class Staff
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[MaxLength(255)]
		public string Id { get; set; } = null!;
		
		[MaxLength(255)] 
		public string Name { get; set; } = null!;
		
		public Gender Gender { get; set; }
		public DateOnly DateOfBirth { get; set; }
		
		[MaxLength(255)]
		public string Ethnic { get; set; } = null!;
		
		public DateOnly StartDate { get; set; }
		
		[MaxLength(255)]
		public string Address { get; set; } = null!;

		[MaxLength(12)]
		public string IdentityCardNumber { get; set; } = null!;
		
		public string Image { get; set; } = null!;
		
		public float CoefficientAllowance { get; set; }
	}
}
