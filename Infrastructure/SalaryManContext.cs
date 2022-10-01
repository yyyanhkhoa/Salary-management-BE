using Microsoft.EntityFrameworkCore;
using Npgsql;
using Salary_management.Infrastructure.Entities;
using Salary_management.Infrastructure.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_management.Infrastructure
{
	public class SalaryManContext : DbContext
	{
		public DbSet<RewardOrDiscipline> RewardOrDisciplines { get; set; } = null!;
		public DbSet<Auth> Auths { get; set; } = null!;
		public DbSet<Staff> Staffs { get; set; } = null!;
		public DbSet<UnitHistory> UnitHistories { get; set; } = null!;
		public DbSet<Position> Positions { get; set; } = null!;
		public DbSet<PositionHistory> PositionHistories { get; set; } = null!;
		public DbSet<Relative> Relatives { get; set; } = null!;
		public DbSet<Qualification> Qualifications { get; set; } = null!;
		public DbSet<StaffQualification> StaffQualifications { get; set; } = null!;
		public DbSet<QualificationAllowanceHistory> QualificationAllowanceHistories { get; set; } = null!;


		static SalaryManContext()
			=> NpgsqlConnection.GlobalTypeMapper.MapEnum<Gender>()
												.MapEnum<RelativeType>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql("Host=localhost;Database=SalaryMan;Username=postgres;Password=postgres")
							 .UseSnakeCaseNamingConvention();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasPostgresEnum<Gender>()
						.HasPostgresEnum<RelativeType>();

			// config
			modelBuilder.Entity<Auth>().HasAlternateKey(e => e.Username);

			modelBuilder.Entity<PositionHistory>()
						.HasKey(e => new{ e.StaffId, e.PositionId });

			modelBuilder.Entity<UnitHistory>()
						.HasKey(e => new{ e.StaffId, e.UnitId });

			modelBuilder.Entity<UnionHistory>()
						.HasKey(e => new { e.StaffId, e.UnionId });

			modelBuilder.Entity<StaffQualification>()
						.HasKey(e => new { e.StaffId, e.QualificationId });

			modelBuilder.Entity<QualificationAllowanceHistory>()
						.HasKey(e => new { e.QualificationId, e.Year } );

			// seed DB
			modelBuilder.Entity<Auth>()
						.HasData(new Auth { Id = 1, Username = "admin", Password = "admin" });
		}
	}
}
