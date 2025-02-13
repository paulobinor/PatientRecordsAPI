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
        Task<Patient> PatientList(string firstname, string lastname);
        Task<Patient> GetSinglePatient(string patient);


        Task<VitalSign> CreateVitals(VitalSign vitalSign);
        Task<VitalSign> UpdateVitals(VitalSign patient);
        Task<List<VitalSign>> GetPatientVitals(DateTime startDate, DateTime endDate, string PatientId);
        Task<VitalSign> GetSingleVitals(string id);


        Task<Consultation> CreateConsultation(Consultation newConsultation);
        Task<Consultation> UpdateConsultation(Consultation updateConsultation);
        Task<List<Consultation>> GetConsultations(DateTime startDate, DateTime endDate, string Id);
        Task<Consultation> GetConsultation(string Id);
    }
}
