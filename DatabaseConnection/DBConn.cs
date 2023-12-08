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
		public DbSet<Doctor> doctor { get; set; }
		public DbSet<Patient> patient { get; set; }
		public DbSet<Room> room { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-2KRMLJS\MSSQLSERVER01;Database=HospitalManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;");
		}
	}
}
