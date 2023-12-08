// See https://aka.ms/new-console-template for more information
using HOSPITAL_MANAGEMENT.DatabaseConnection;
using HOSPITAL_MANAGEMENT.Services;
using Microsoft.EntityFrameworkCore;

static class Program_name
{
	static void Main()
	{
/*Checking if my code has connected Successfully*/
		try
		{
			DBConn dBConn = new DBConn();
			dBConn.Database.OpenConnection();
			Console.WriteLine("Connected successfully");


/*============================CRUD OPERATION ON PATIENT =========================================*/
				PatientServices patientServices = new PatientServices();
			//add new patient to the database
			patientServices.AddNewPatient();

			//updating the firstname
			patientServices.UPdatePatientDetails(1, "martin");

			//deleting the patient from the fatabase
			patientServices.DeletePatient(1);

			//GETING LL THE PATIENT FROM THE DATABASE
			patientServices.GetAllPatients();

			//GET PATIENT BY iD
			patientServices.GetPatientById(2);

		}catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

}