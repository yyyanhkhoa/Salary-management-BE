namespace Salary_management.Infrastructure.Entities
{
	public class Rank
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Milestone { get; set; }
		public float Coefficient { get; set; }
	}
}