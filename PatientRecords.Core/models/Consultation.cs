using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.models
{
    public class Consultation
    {
        [Key]
        public System.Guid ConsultationID { get; set; }

        [ForeignKey(name: "PatientId")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public System.DateTime Date { get; set; }
        public string Triage { get; set; }
        public string CurentConcerns { get; set; }
        public string Diagnosis { get; set; }
        public string Observations { get; set; }
        public System.Guid UserID { get; set; }
        public System.Guid AppointmentID { get; set; }
        public string Physician { get; set; }
        public string Status { get; set; }
        public System.Guid DiagnosisID { get; set; }
        public string OtherROS { get; set; }
        public string SystemCheck { get; set; }
        public string Informat { get; set; }
        public string History { get; set; }
        public string IsDeleted { get; set; }
    }
}
