using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.Dtos
{
    public class ConsultationDto
    {
        public Guid ConsultationId { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public byte IsDeleted { get; set; } = 0;
    }

    public class CreateConsultationDto
    {
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public byte IsDeleted { get; set; } = 0;
    }
}
