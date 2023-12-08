using HOSPITAL_MANAGEMENT.DatabaseConnection;
using HOSPITAL_MANAGEMENT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT.Services
{
	public class PatientServices
	{
		public String? AddNewPatient()
		{
			var newPatient = new Patient
			{
				FirstName = "Martin",
				LastName = "Muruthi",
				Email = "martinmuruthi@teach2give.com",
				RoomID = 1,
			};

			using (var dbContext = new DBConn())
			{
				dbContext.Patient.Add(newPatient);
				dbContext.SaveChanges();
			}
			return "Patient has been Added Successfully";
		}

		public void RemovePatient(int patientID)
		{
			using (var dbContext = new DBConn())
			{

				string deleteSql = $"DELETE FROM Patients WHERE PatientID = {patientID}";
				dbContext.Database.ExecuteSqlRaw(deleteSql);

			}
		}
		public void GetAllPatients()
		{
			using (var dbContext = new DBConn())
			{

				string query = "SELECT * FROM Patients";
				var allPatients = dbContext.Patient.FromSqlRaw(query).ToList();
				foreach(var patient in allPatients)
				{
					Console.WriteLine($"{patient.FirstName} {patient.LastName}");
				}


			}
		}

		public void GetPatientById(int patientId)
		{
			DBConn dbContext = new DBConn();
			string query = $"SELECT * FROM Patients WHERE PatientID={patientId}";
			Patient patient = dbContext.Patient.FromSqlRaw(query).FirstOrDefault();
			if(patient!=null)
			{
				Console.WriteLine($"{patient.FirstName} {patient.LastName}");
			}
			
		}

		public void UPdatePatientDetails(int patientIdToUpdate,String firstname)
		{
			DBConn dbContext = new DBConn();
			string updateSql = $"UPDATE Patients SET Username = '{firstname}' WHERE PatientID = {patientIdToUpdate}";
			dbContext.Database.ExecuteSqlRaw(updateSql);
			Console.WriteLine("Username updated successfully.");
		}

		public void DeletePatient(int patientId)
		{
			DBConn dBConn = new DBConn();
			using (var dbContext = new DBConn())
			{
				string deleteSql = $"DELETE FROM Patients WHERE PatientID = {patientId}";
				dbContext.Database.ExecuteSqlRaw(deleteSql);

				Console.WriteLine("Patient deleted successfully.");
			}

		}



	}
}
