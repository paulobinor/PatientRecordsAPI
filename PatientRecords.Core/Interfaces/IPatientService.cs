using PatientRecords.Core.Dtos;
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
        Task<PatientDto> CreatePatient(CreatePatientDto createPatientDto);
        Task<PatientDto> UpdatePatient(PatientDto patientDto);
        Task<List<PatientDto>> PatientList(string firstname, string lastname);
        Task<PatientDto> GetSinglePatient(string patient);


        Task<VitalSignDto> CreateVitals(CreateVitalSignDto vitalSign);
        Task<VitalSignDto> UpdateVitals(VitalSignDto patient);
        Task<List<VitalSignDto>> GetPatientVitals(DateTime startDate, DateTime endDate, string PatientId);
        Task<VitalSignDto> GetSingleVitals(string id);


        Task<ConsultationDto> CreateConsultation(CreateConsultationDto createConsultationDto);
        Task<ConsultationDto> UpdateConsultation(ConsultationDto updateConsultation);
        Task<List<ConsultationDto>> GetConsultations(DateTime startDate, DateTime endDate, string Id);
        Task<ConsultationDto> GetConsultation(string Id);
    }
}
