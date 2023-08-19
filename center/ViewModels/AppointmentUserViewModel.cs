using center.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace center.ViewModels
{
    public class AppointmentUserViewModel
    {
        public int AppointmentId { set; get; }
        public int TreatmentId { get; set; }

        public List<Treatment> Treatments { get; set; }

        public String UserId { get; set; }

        public List<IdentityUser> Users { get; set; }

        public int PatientId { get; set; }

        public List<Patient> patients { get; set; }

        public double? paid_amount { get; set; }

        [Required]
        [Display(Name = "تاريخ الجلسة")]
        [DataType(DataType.Date)]
        public DateTime SessionTime { get; set; }
    }
}
