using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT.Models
{
	public class Room
	{
		[Key]
		public int RoomID { get; set; }

		[Required]
		public int RoomNumber { get; set; }

		[StringLength(10)]
		public string RoomType { get; set; }
	}
}
