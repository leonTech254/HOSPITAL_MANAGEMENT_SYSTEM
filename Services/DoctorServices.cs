using HOSPITAL_MANAGEMENT.DatabaseConnection;
using HOSPITAL_MANAGEMENT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HOSPITAL_MANAGEMENT.Services
{
	public class DoctorService : IDisposable
	{
		private readonly DBConn dbConn;
		private Dictionary<int, Doctor> doctorDictionary;

		public DoctorService()
		{
			dbConn = new DBConn();
			doctorDictionary = dbConn.Doctor.ToDictionary(d => d.DoctorID);
		}

		public void WelcomeDoctor()
		{
			Console.WriteLine("\n\nWELCOME TO DOCTOR MODULE");
			Dictionary<int, string> MenuDictionary = new Dictionary<int, string>
			{
				{1, "Add Doctor" },
				{2, "See all Doctors" },
				{3, "Update Doctor" },
				{4, "Delete Doctor" }
			};

			foreach (var item in MenuDictionary)
			{
				Console.WriteLine($"{item.Key}:{item.Value}");
			}

			Console.WriteLine("Select Option:");
			string userRawChoice = Console.ReadLine();

			try
			{
				int userChoice = int.Parse(userRawChoice);

				switch (userChoice)
				{
					case 1:
						AddDoctor();
						break;
					case 2:
						GetAllDoctors();
						break;
					case 3:
						UpdateDoctor();
						break;
					case 4:
						DeleteDoctor();
						break;
					default:
						Console.WriteLine("You selected an Invalid choice");
						break;
				}
			}
			catch (Exception e)
			{
				Console.Write(e.ToString());
			}
		}

		public List<Doctor> GetAllDoctors()
		{
			foreach (var doctor in doctorDictionary.Values)
			{
				Console.WriteLine($"{doctor.DoctorID} {doctor.DoctorName} {doctor.Specialty}");
			}

			return dbConn.Doctor.ToList();
		}

		public void AddDoctor()
		{
			Console.WriteLine("Enter Doctor Name:");
			string doctorName = Console.ReadLine();

			Console.WriteLine("Enter Specialty:");
			string specialty = Console.ReadLine();

			var newDoctor = new Doctor
			{
				DoctorName = doctorName,
				Specialty = specialty
			};

			dbConn.Doctor.Add(newDoctor);
			dbConn.SaveChanges();

			// Update the dictionary after adding a new doctor
			doctorDictionary.Add(newDoctor.DoctorID, newDoctor);

			Console.WriteLine("Doctor has been Added Successfully");
		}

		public void UpdateDoctor()
		{
			Console.WriteLine("Enter Doctor ID to Update:");
			int doctorId = int.Parse(Console.ReadLine());

			if (doctorDictionary.TryGetValue(doctorId, out var existingDoctor))
			{
				Console.WriteLine("Enter New Specialty:");
				string newSpecialty = Console.ReadLine();

				existingDoctor.Specialty = newSpecialty;
				dbConn.SaveChanges();
				Console.WriteLine($"Doctor {doctorId} Updated Successfully");
			}
			else
			{
				Console.WriteLine($"Doctor {doctorId} not found.");
			}
		}

		public void DeleteDoctor()
		{
			Console.WriteLine("Enter Doctor ID to Delete:");
			int doctorId = int.Parse(Console.ReadLine());

			if (doctorDictionary.TryGetValue(doctorId, out var doctorToDelete))
			{
				dbConn.Doctor.Remove(doctorToDelete);
				dbConn.SaveChanges();

				// Update the dictionary after deleting a doctor
				doctorDictionary.Remove(doctorId);

				Console.WriteLine($"Doctor {doctorId} Deleted Successfully");
			}
			else
			{
				Console.WriteLine($"Doctor {doctorId} not found.");
			}
		}

		public void Dispose()
		{
			// Dispose of the DbContext when the service is no longer needed
			dbConn.Dispose();
		}
	}
}
