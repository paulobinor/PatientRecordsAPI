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
        Task<List<Patient>> GetPatientList(string firstName, string lastName);
        Task<List<VitalSign>> GetPatientVitals(DateTime startDate, DateTime endDate, string id);
        Task<VitalSign> AddPatientVitals(VitalSign vitalSign);
        Task<VitalSign> UpdatePatientVitals(VitalSign updateVitalSign);
        Task<Consultation> AddConsultation(Consultation consultation);
        Task<Consultation> UpdateConsultation(Consultation consultation);
        Task<Patient> GetPatient(string id);
        Task<List<Consultation>> GetConsultations(DateTime startDate, DateTime endDate, string id);
        Task<Consultation> GetConsultation(string id);
        Task<VitalSign> GetSingleVitals(string id);
    }
}
