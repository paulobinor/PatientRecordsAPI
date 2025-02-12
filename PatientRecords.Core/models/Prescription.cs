using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.models
{
    public class Prescription
    {

        [Key]
        public Guid PrescriptionId { get; set; }
        [ForeignKey(name: "PatientId")]
        public Guid PatientId { get; set; }
        public string InstructionNotes { get; set; }
        public string Comments { get; set; }
        public Guid PrescriptionDate { get; set; }
        public string AuthorizingMedic { get; set; }
        public string Status { get; set; }
        public string IsDeleted { get; set; }
        public List<Medication> Medications { get; set; }
        public Patient Patient { get; set; }
    }
}
