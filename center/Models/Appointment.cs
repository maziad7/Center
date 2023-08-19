using System.ComponentModel.DataAnnotations;

namespace center.Models
{
    public class Appointment
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public int TreatmentId { get; set; }

        public virtual Treatment Treatment { get; set; }

        [Required]
        public String UserId { get; set; }
        
        public virtual ApplicationUser User { get; set; }  

        [Required]
        public int PatientId { get; set; }

        public virtual Patient patient { get; set; }

        public double? paid_amount { get; set; }

        [Required]
        [Display(Name = "تاريخ الجلسة")]
        [DataType(DataType.Date)]
        public DateTime SessionTime { get;set; }


    }
}
