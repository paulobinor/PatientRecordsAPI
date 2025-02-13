using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.Core.Dtos
{
    public class PatientDto
    {
        public Guid PatientId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public byte IsDeleted { get; set; } = 0;
    }

    public class UpdatePatientDto
    {
        public Guid PatientId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public byte IsDeleted { get; set; }
    }

    public class CreatePatientDto
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
