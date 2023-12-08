using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HOSPITAL_MANAGEMENT.Models
{
	public class Appointment
	{
		[Key]
		public int AppointmentID { get; set; }

		[ForeignKey("Patient")]
		public int PatientID { get; set; }

		[ForeignKey("Doctor")]
		public int DoctorID { get; set; }

		public DateTime? AppointmentDate { get; set; }

		public TimeSpan? AppointmentTime { get; set; }

		public virtual Patient Patient { get; set; }

		public virtual Doctor Doctor { get; set; }
	}
}
