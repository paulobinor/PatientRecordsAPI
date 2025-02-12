using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientRecords.Core.models
{
    public class Medication
    {
        [Key]
        public System.Guid? MedicationID { get; set; }
        public Guid? PrescriptionID { get; set; }

        [ForeignKey(name: "PatientId")]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string DrugName { get; set; }
        public string DrugRoute { get; set; }
        public int? Quantity { get; set; }
        public string Instructions { get; set; }
        public string Comments { get; set; }
        public int? Refills { get; set; }
        public int? RefillQty { get; set; }
        public int? Qty { get; set; }
        public string Usage { get; set; }
        public string PrescribedBy { get; set; }
        public string IsDeleted { get; set; }
        public string DispensedBy { get; set; }

        public string Dosage { get; set; }
    }
}
