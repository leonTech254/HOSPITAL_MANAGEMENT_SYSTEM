using HOSPITAL_MANAGEMENT.DatabaseConnection;
using HOSPITAL_MANAGEMENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HOSPITAL_MANAGEMENT.Services
{
	public class RoomService
	{
		private DBConn dbConn;
		private Dictionary<int, Room> roomDictionary;

		public RoomService()
		{
			dbConn = new DBConn();
			roomDictionary = dbConn.Room.ToDictionary(r => r.RoomID);
		}

		public void WelcomeRoom()
		{
			Console.WriteLine("\n\nWELCOME TO ROOM MODULE");
			Dictionary<int, string> MenuDictionary = new Dictionary<int, string>
			{
				{1, "Add Room" },
				{2, "See all Rooms" },
				{3, "Update Room" },
				{4, "Delete Room" }
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
						AddRoom();
						break;
					case 2:
						GetAllRooms();
						break;
					case 3:
						UpdateRooms();
						break;
					case 4:
						DeleteRoom();
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

		public void GetAllRooms()
		{
			foreach (var room in roomDictionary.Values)
			{
				Console.WriteLine($"{room.RoomID} {room.RoomNumber} {room.RoomType}");
			}
		}

		public void AddRoom()
		{
			Console.WriteLine("Enter Room Number:");
			int roomNumber = int.Parse(Console.ReadLine());

			Console.WriteLine("Enter Room Type:");
			string roomType = Console.ReadLine();

			var newRoom = new Room
			{
				RoomNumber = roomNumber,
				RoomType = roomType
			};

			using (var dbContext = new DBConn())
			{
				dbContext.Room.Add(newRoom);
				dbContext.SaveChanges();

				// Update the dictionary after adding a new room
				roomDictionary.Add(newRoom.RoomID, newRoom);
			}

			Console.WriteLine("Room has been Added Successfully");
		}

		public void UpdateRooms()
		{
			Console.WriteLine("Enter Room ID to Update:");
			int roomId = int.Parse(Console.ReadLine());

			if (roomDictionary.TryGetValue(roomId, out var existingRoom))
			{
				Console.WriteLine("Enter New Room Type:");
				string newRoomType = Console.ReadLine();

				existingRoom.RoomType = newRoomType;

				using (var dbContext = new DBConn())
				{
					dbContext.SaveChanges();
					Console.WriteLine($"Room {roomId} Updated Successfully");
				}
			}
			else
			{
				Console.WriteLine($"Room {roomId} not found");
			}
		}

		public void DeleteRoom()
		{
			Console.WriteLine("Enter Room ID to Delete:");
			int roomId = int.Parse(Console.ReadLine());

			if (roomDictionary.TryGetValue(roomId, out var roomToDelete))
			{
				using (var dbContext = new DBConn())
				{
					dbContext.Room.Remove(roomToDelete);
					dbContext.SaveChanges();

					// Update the dictionary after deleting a room
					roomDictionary.Remove(roomId);

					Console.WriteLine("Room Deleted Successfully");
				}
			}
			else
			{
				Console.WriteLine($"Room {roomId} not found");
			}
		}
	}
}
