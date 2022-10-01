using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Salary_management.Infrastructure.Entities
{
	public class Position
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[MaxLength(255)]
		public string Id { get; set; } = null!;

		[MaxLength(255)]
		public string Name { get; set; } = null!;

		public int BaseSalary { get; set; }

		public int RankId { get; set; }
		public Rank Rank { get; set; } = null!;
	}
}