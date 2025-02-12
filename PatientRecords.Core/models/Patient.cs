using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientRecords.Core.models
{
    public class Patient
    {
        [Key]
        public Guid PatientId { get; set; } = new System.Guid();
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string GenoType { get; set; }
        public string Nationality { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string NOKSurname { get; set; }
        public string NOKOtherNames { get; set; }
        public string NOKRelationship { get; set; }
        public string NOKAddress { get; set; }
        public string NOKPhoneNumber { get; set; }
        public string HospitalNumber { get; set; }
        public string Base64StringPhoto { get; set; }
        public string BirthPlace { get; set; }
        public string EducationalLevel { get; set; }
        public string StateOfResidence { get; set; }
        public string HomePhoneNumber { get; set; }
        public string email { get; set; }
        public string Employer { get; set; }
        public string BusinessPhone { get; set; }
        public string FamilyProvider { get; set; }
        public string PrimaryProvider { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new();
        public List<VitalSign> VitalSigns { get; set; } = new();
        public List<Consultation> Consultations { get; set; } = new();
        public List<Medication> Medications { get; set; } = new();
    }
}
