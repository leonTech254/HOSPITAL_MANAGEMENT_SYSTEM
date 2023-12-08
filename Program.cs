// See https://aka.ms/new-console-template for more information
using HOSPITAL_MANAGEMENT.DatabaseConnection;
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
		}catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

}