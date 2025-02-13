using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.models
{
    public class Consultation
    {
        public Guid ConsultationId { get; set; } = Guid.NewGuid();
        [ForeignKey(name: "PatientId")]
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public byte IsDeleted { get; set; } = 0;
    }
}
