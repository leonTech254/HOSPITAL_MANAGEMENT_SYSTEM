using HOSPITAL_MANAGEMENT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT.DatabaseConnection
{
	public class DBConn:DbContext
	{
		public DbSet<Doctor> Doctor { get; set; }
		public DbSet<Patient> Patient { get; set; }
		public DbSet<Room> Room { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-2KRMLJS\MSSQLSERVER01;Database=HospitalManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;");
		}
	}
}
