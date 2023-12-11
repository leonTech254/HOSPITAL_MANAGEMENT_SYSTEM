using HOSPITAL_MANAGEMENT.DatabaseConnection;
using HOSPITAL_MANAGEMENT.Models;
using HOSPITAL_MANAGEMENT.Services;
using Microsoft.EntityFrameworkCore;
using System;

static class Program_name
{
	static void Main()
	{
		/* Checking if my code has connected Successfully */
		try
		{
			DBConn dBConn = new DBConn();
			dBConn.Database.OpenConnection();
			Console.WriteLine("Connected successfully");
			/* ============================ SHOWING MENU ============================= */
			Console.WriteLine("WELCOME TO HOSPITAL MANAGEMENT SYSTEM");
			Dictionary<int, string> MenuDictionary = new Dictionary<int, string>
		{
			{ 1, "Patients Module" },
			{ 2, "Doctors Module" },
			{ 3, "Rooms Module" }
		};

			foreach (var menuItem in MenuDictionary)
			{
				Console.WriteLine($"{menuItem.Key}: {menuItem.Value}");
			}

			Console.WriteLine("Please select an option (enter a number):");
			string userChoice = Console.ReadLine();
			if (userChoice != null)
			{
				try
				{
					String choose=MenuDictionary[int.Parse(userChoice)].Split(" ")[0];
					if(choose=="Patients")
					{
						PatientMethod();

					}
					else if(choose== "Doctors")
					{
						DoctorsMethod();

					}else
					{
						RoomsMethods();
					}
					Console.WriteLine(choose);

				}catch(Exception ex)
				{

					Console.WriteLine("You did not select a valid option");
				}
			}


			RepeatOperation();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}


	static void PatientMethod()
	{
		/* ============================ CRUD OPERATION ON PATIENT ============================= */
		PatientServices patientService = new PatientServices();

		// Add a new patient to the database
		/*	patientService.AddNewPatient();*/

		// Update patient details
		/*patientService.UPdatePatientDetails(1, "UpdatedFirstName");*/

		// Delete a patient from the database
		/*	patientService.DeletePatient(1);*/

		// Get all patients from the database
		/*	patientService.GetAllPatients();*/

		// Get patient by ID
		/*patientService.GetPatientById(2);*/

		patientService.WelcomePatient();

	}

	static void RoomsMethods()
	{
		/* ============================ CRUD OPERATION ON ROOM =============================== */
		RoomService roomService = new RoomService();
		roomService.WelcomeRoom();


		// Add a new room to the database
		//roomService.AddRoom();

		// Update room details
		//roomService.UpdateRooms();

		// Delete a room from the database
		/*roomService.DeleteRoom(1);*//*

		// Get all rooms from the database
		roomService.GetAllRooms();*/

	}

	static void DoctorsMethod()
	{
		/* ============================ CRUD OPERATION ON DOCTOR ============================= */
		DoctorService doctorService = new DoctorService();
		doctorService.WelcomeDoctor();

		// Add a new doctor to the database
		/*doctorService.AddDoctor(new Doctor { DoctorName = "Dr. Martin", Specialty = "Cardiology" });*/

		// Update doctor details
		/*doctorService.UpdateDoctor(1, "UpdatedSpecialty");*/

		// Delete a doctor from the database
		/*doctorService.DeleteDoctor(1);*/

		// Get all doctors from the database
	/*	doctorService.GetAllDoctors();*/

	}

	static void RepeatOperation()
	{
		Console.WriteLine("Would you like to Do other operations? Y=no,N=no");
		String userchoice = Console.ReadLine();
	if(userchoice!=null)
		{
			if(userchoice.ToLower()=="yes" || userchoice.ToLower()=="y")
			{
				Main();

			}else
			{
				Console.WriteLine("Exting program... THank you....");
			}
		}
	}

}
