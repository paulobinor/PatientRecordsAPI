using AutoMapper;
using PatientRecords.AppService.Interfaces;
using PatientRecords.Core.Dtos;
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
        private readonly IMapper _mapper;
        public PatientAppService(IPatientDbRepo patientDbRepo)
        {
            _patientDbRepo = patientDbRepo;
            _mapper = MappingConfig.RegisterMaps().CreateMapper();
        }

        public async Task<PatientDto> CreatePatient(CreatePatientDto createPatientDto)
        {
            var patient = _mapper.Map<Patient>(createPatientDto);
            var resp = await _patientDbRepo.AddNewPatient(patient);
            if (resp != null)
            {
                return _mapper.Map<PatientDto>(resp);
            }
            return null;
        }

        public async Task<PatientDto> UpdatePatient(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            var resp = await _patientDbRepo.UpdateExistingPatient(patient);
            if (resp != null)
            {
                return _mapper.Map<PatientDto>(resp);
            }
            return null;
        }
        public async Task<List<PatientDto>> PatientList(string firstname, string lastname)
        {
            var resp = await _patientDbRepo.GetPatientList(firstname, lastname);
            if (resp != null)
            {
                return _mapper.Map<List<PatientDto>>(resp);
            }
            return null;
        }


        public async Task<ConsultationDto> CreateConsultation(CreateConsultationDto createConsultation)
        {
            var newConsultation = _mapper.Map<Consultation>(createConsultation);
            var resp = await _patientDbRepo.AddConsultation(newConsultation);
            if (resp != null)
            {
                return _mapper.Map<ConsultationDto>(resp);
            }
            return null;
        }

        public async Task<List<ConsultationDto>> GetConsultations(DateTime startDate, DateTime endDate, string Id)
        {
            var resp = await _patientDbRepo.GetConsultations(startDate, endDate, Id);
            if (resp != null)
            {
                return _mapper.Map<List<ConsultationDto>>(resp);
            }
            return null;
        }

        public async Task<ConsultationDto> UpdateConsultation(ConsultationDto consultationDto)
        {
            var updateConsultation = _mapper.Map<Consultation>(consultationDto);
            var resp = await _patientDbRepo.UpdateConsultation(updateConsultation);
            if (resp != null)
            {
                return _mapper.Map<ConsultationDto>(resp);
            }
            return null;
        }

        public async Task<ConsultationDto> GetConsultation(string Id)
        {
            var resp = await _patientDbRepo.GetConsultation(Id);
            return _mapper.Map<ConsultationDto>(resp);
        }

        public async Task<PatientDto> GetSinglePatient(string Id)
        {
            var resp = await _patientDbRepo.GetPatient(Id);
            if (resp != null)
            {
                return _mapper.Map<PatientDto>(resp);
            }
            return null;
        }

        public async Task<VitalSignDto> CreateVitals(CreateVitalSignDto createVitalSignDto)
        {
            var vitalSign = _mapper.Map<VitalSign>(createVitalSignDto);
            var resp = await _patientDbRepo.AddPatientVitals(vitalSign);
            if (resp != null)
            {
                return _mapper.Map<VitalSignDto>(resp);
            }
            return null;
        }


        public async Task<List<VitalSignDto>> GetPatientVitals(DateTime startDate, DateTime endDate, string PatientId)
        {
            var resp = await _patientDbRepo.GetPatientVitals(startDate, endDate, PatientId);
            if (resp != null)
            {
                return _mapper.Map<List<VitalSignDto>>(resp);
            }
            return null;
        }

        public async Task<VitalSignDto> UpdateVitals(VitalSignDto vitalSignDto)
        {
            var vitalSign = _mapper.Map<VitalSign>(vitalSignDto);
            var resp = await _patientDbRepo.UpdatePatientVitals(vitalSign);
            if (resp != null)
            {
                return _mapper.Map<VitalSignDto>(resp);
            }
            return null;
        }

        public async Task<VitalSignDto> GetSingleVitals(string id)
        {
            var resp = await _patientDbRepo.GetSingleVitals(id);
            if (resp != null)
            {
                return _mapper.Map<VitalSignDto>(resp);
            }
            return null;
        }
    }
}
