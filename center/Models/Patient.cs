using System.ComponentModel.DataAnnotations;

namespace center.Models
{
    public class Patient
    {
        [Required] 
        public int PatientId { get; set; }

       [Required,MaxLength(100)]
        public string PatientName { get; set; }

        [Required, MaxLength(10)]
        public string Patientage { get; set; }

        [Required, MaxLength(10)]
        public string? phoneNumber { get; set;}

       [Required, MaxLength(100)]
        public string? PatientLocation{ get; set;}

        public virtual List<Appointment> appointments { get; set; }

    }
}
