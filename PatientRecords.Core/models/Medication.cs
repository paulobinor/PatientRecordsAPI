using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.models
{
    public class Medication
    {
        public Guid MedicationId { get; set; } = Guid.NewGuid();
        [ForeignKey(name: "PatientId")]
        public Guid PatientId { get; set; }
        public string DrugName { get; set; }
    }
}
