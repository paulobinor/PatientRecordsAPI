using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.models
{
    public class VitalSign
    {
        [Key]
        public Guid VitalSignsId { get; set; }
        [ForeignKey(name: "PatientId")]
        public Guid PatientId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BMI { get; set; }
        public string BP { get; set; }
        public string Pulse { get; set; }
        public string Respiration { get; set; }
        public string Temperature { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.Now;
        public string Notes { get; set; }
        public byte IsDeleted { get; set; } = 0;

    }
}
