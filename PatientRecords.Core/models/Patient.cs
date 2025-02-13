using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.Core.models
{
    public class Patient
    {
        [Key]
        public Guid PatientId { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public byte IsDeleted { get; set; } = 0;
        public List<Consultation> Consultations { get; set; } = new();
        public List<Medication> Medications { get; set; } = new();
    }
}
