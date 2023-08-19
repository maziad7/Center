using System.ComponentModel.DataAnnotations;

namespace center.Models
{
    public class Treatment
    {
        [Required]
        public int TreatmentId { get; set; }

        [Required,MaxLength(100)]
        public string TreatmentName { get; set; }

        [Required]
        public double TreatmentPrice { get; set; }

        public virtual List<Appointment> Appointments { get; set; }
    }
}
