using PatientRecords.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.Core.Interfaces
{
    public interface IPatientService
    {
        Task<Patient> CreatePatient(Patient patient);
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient> CreateVitals(VitalSign patient);
        Task<Patient> UpdateVitals(Patient patient);
        Task<Patient> PatientList();
        Task<Patient> CreateConsultation(Consultation newConsultation);
        Task<Patient> UpdateConsultation(Consultation updateConsultation);
        Task<Patient> GetSinglePatient(Patient patient);
        Task<Patient> GetConsultation(Patient patient);
        Task<List<VitalSign>> GetVitals(string patientId);
    }
}
