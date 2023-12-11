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
		public void WelcomePatient()
		{
			Console.WriteLine("\n\nWELCOME TO PATIENT MODULE");
			Dictionary<int, string> MenuDictionary = new Dictionary<int, string>
		{
			{1,"Add Patient" },
			{ 2, "See all Patients" },
			{ 3, "Update Patient" },
			{ 4, "Delete patient" }
		};
			foreach(var item in MenuDictionary)
			{
				Console.WriteLine($"{item.Key}:{item.Value}");
			}
			Console.WriteLine("select Option");
			String userRawChoice=Console.ReadLine();
			try
			{
				int userChoice=int.Parse(userRawChoice);
				if(userChoice==1)
				{
					AddNewPatient();
				}else if(userChoice==2)
				{
					GetAllPatients();
				}else if(userChoice==3)
				{
					UpdatePatientDetails();
				}else if(userChoice==4)
				{
					DeletePatient();
				}else
				{
					Console.WriteLine("You selected an Invalid choice");
				}
			}catch (Exception e)
			{
				Console.Write(e.ToString());
			}

		}

		public string? AddNewPatient()
		{
			Console.WriteLine("Enter First Name:");
			string firstName = Console.ReadLine();

			Console.WriteLine("Enter Last Name:");
			string lastName = Console.ReadLine();

			Console.WriteLine("Enter Email:");
			string email = Console.ReadLine();

			Console.WriteLine("Enter Room ID:");
			int roomId = int.Parse(Console.ReadLine());

			var newPatient = new Patient
			{
				FirstName = firstName,
				LastName = lastName,
				Email = email,
				RoomID = roomId,
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

				string deleteSql = $"DELETE FROM Patient WHERE PatientID = {patientID}";
				dbContext.Database.ExecuteSqlRaw(deleteSql);

			}
		}
		public void GetAllPatients()
		{
			using (var dbContext = new DBConn())
			{

				string query = "SELECT * FROM Patient";
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
			string query = $"SELECT * FROM Patient WHERE PatientID={patientId}";
			Patient patient = dbContext.Patient.FromSqlRaw(query).FirstOrDefault();
			if(patient!=null)
			{
				Console.WriteLine($"{patient.FirstName} {patient.LastName}");
			}
			
		}

		public void UpdatePatientDetails()
		{
			Console.WriteLine("Enter Patient ID to Update:");
			int patientId = int.Parse(Console.ReadLine());

			Console.WriteLine("Enter New First Name:");
			string newFirstName = Console.ReadLine();

			using (var dbContext = new DBConn())
			{
				string updateSql = $"UPDATE Patient SET FirstName = '{newFirstName}' WHERE PatientID = {patientId}";
				dbContext.Database.ExecuteSqlRaw(updateSql);
				Console.WriteLine("Patient details updated successfully.");
			}
		}

		public void DeletePatient()
		{
			Console.WriteLine("Enter Patient ID to Delete:");
			int patientId = int.Parse(Console.ReadLine());

			using (var dbContext = new DBConn())
			{
				string deleteSql = $"DELETE FROM Patient WHERE PatientID = {patientId}";
				dbContext.Database.ExecuteSqlRaw(deleteSql);

				Console.WriteLine("Patient deleted successfully.");
			}
		}



	}
}
