using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT.Models
{
	public class Doctor
	{
		[Key]
		public int DoctorID { get; set; }

		[Required]
		[StringLength(100)]
		public string DoctorName { get; set; }

		[StringLength(100)]
		public string Specialty { get; set; }
	}
}
