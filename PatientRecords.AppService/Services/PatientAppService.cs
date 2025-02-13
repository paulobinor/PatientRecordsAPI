using PatientRecords.AppService.Interfaces;
using PatientRecords.Core.Interfaces;
using PatientRecords.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.AppService.Services
{
    public class PatientAppService : IPatientService
    {
        private readonly IPatientDbRepo _patientDbRepo;
        public PatientAppService(IPatientDbRepo patientDbRepo)
        {
            _patientDbRepo = patientDbRepo;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            var resp = await _patientDbRepo.AddNewPatient(patient);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var resp = await _patientDbRepo.UpdateExistingPatient(patient);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }
        public async Task<Patient> PatientList(string firstname, string lastname)
        {
            var resp = await _patientDbRepo.GetPatientList(firstname, lastname);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }


        public async Task<Consultation> CreateConsultation(Consultation newConsultation)
        {
            var resp = await _patientDbRepo.AddConsultation(newConsultation);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }

        public async Task<List<Consultation>> GetConsultations(DateTime startDate, DateTime endDate, string Id)
        {
            var resp = await _patientDbRepo.GetConsultations(startDate, endDate, Id);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }

        public async Task<Consultation> UpdateConsultation(Consultation updateConsultation)
        {
            var resp = await _patientDbRepo.UpdateConsultation(updateConsultation);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }

        public async Task<Consultation> GetConsultation(string Id)
        {
            return await _patientDbRepo.GetConsultation(Id);
        }

        public async Task<Patient> GetSinglePatient(string Id)
        {
            var resp = await _patientDbRepo.GetPatient(Id);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }

        public async Task<VitalSign> CreateVitals(VitalSign vitalSign)
        {
            var resp = await _patientDbRepo.AddPatientVitals(vitalSign);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }


        public async Task<List<VitalSign>> GetPatientVitals(DateTime startDate, DateTime endDate, string PatientId)
        {
            var resp = await _patientDbRepo.GetPatientVitals(startDate, endDate, PatientId);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }

        public async Task<VitalSign> UpdateVitals(VitalSign vitalSign)
        {
            var resp = await _patientDbRepo.UpdatePatientVitals(vitalSign);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }

        public async Task<VitalSign> GetSingleVitals(string id)
        {
            var resp = await _patientDbRepo.GetSingleVitals(id);
            if (resp != null)
            {
                return resp;
            }
            return null;
        }
    }
}
