using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.models
{
    public class VitalSign
    {
        [Key]
        public Guid VitalSignsID { get; set; }
       
        [ForeignKey(name: "PatientId")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BMI { get; set; }
        public string BP1 { get; set; }
        public string BP2 { get; set; }
        public string Pulse { get; set; }
        public string Respiration { get; set; }
        public DateTime RecordDate { get; set; }
        public string Temperature { get; set; }
        public string Notes { get; set; }
        public string IsDeleted { get; set; }

    }
}
