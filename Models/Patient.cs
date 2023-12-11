using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT.Models
{
	public class Patient
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PatientID { get; set; }

		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }

		[StringLength(100)]
		public string LastName { get; set; }

		[StringLength(100)]
		[EmailAddress]
		public string Email { get; set; }

		[ForeignKey("Room")]
		public int RoomID { get; set; }

		public virtual Room Room { get; set; }
	}
}
