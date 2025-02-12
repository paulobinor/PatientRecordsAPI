using PatientRecords.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.AppService.Interfaces
{
    public interface IPatientDbRepo
    {
        Task<Patient> AddNewPatient(Patient patient);
        Task<Patient> UpdateExistingPatient(Patient patient);
        Task<List<Patient>> GetPatientList();
        Task<List<Patient>> GetPatientVitals(string PatientId);
        Task<VitalSign> AddPatientVitals(VitalSign vitalSign);
        Task<VitalSign> UpdatePatientVitals(VitalSign updateVitalSign);
        Task<Consultation> AddConsultation(Consultation consultation);
        Task<Consultation> UpdateConsultation(Consultation consultation);
    }
}
