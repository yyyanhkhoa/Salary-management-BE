namespace Salary_management.Infrastructure.Repositories
{
	public class Result<T>
	{
		public bool Success { get; init; }
		public T Payload { get; init; }
		public string ErrorMessage { get; init; }
	}
}