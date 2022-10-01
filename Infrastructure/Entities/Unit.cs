using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Salary_management.Infrastructure.Entities
{
	public class Unit
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[MaxLength(255)]
		public string Id { get; set; } = null!;

		[MaxLength(255)]
		public string Name { get; set; } = null!;

		[MaxLength(255)]
		public string Address { get; set; } = null!;

		[MaxLength(10)]
		public string PhoneNumber { get; set; } = null!;

		public DateOnly DateFounded { get; set; }
	}
}