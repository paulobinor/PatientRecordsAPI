using Microsoft.EntityFrameworkCore;
using PatientRecords.AppService.Interfaces;
using PatientRecords.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.Repo.SQLite
{
    public class SQLiteDBRepo : IPatientDbRepo
    {
        private readonly SQLiteDbContext _dbContext;
        public SQLiteDBRepo(SQLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Patient> AddNewPatient(Patient patient)
        {
           var newPatientTracking = await _dbContext.Patients.AddAsync(patient);
           var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newPatientTracking.Entity;
            }
            return null;
        }

        public async Task<Patient> UpdateExistingPatient(Patient patient)
        {
            var newPatientTracking = _dbContext.Patients.Update(patient);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newPatientTracking.Entity;
            }
            return null;
        }

        public async Task<List<Patient>> GetPatientList()
        {
            return _dbContext.Patients.Where(x => !x.IsDeleted).ToList();
        }

        public async Task<List<Patient>> GetPatientVitals(string PatientId)
        {
            return _dbContext.Patients.Where(x => !x.IsDeleted).ToList();
        }

        public async Task<VitalSign> AddPatientVitals(VitalSign vitalSign)
        {
            var newPatientTracking = await _dbContext.vitalSigns.AddAsync(vitalSign);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newPatientTracking.Entity;
            }
            return null;
        }

        public async Task<VitalSign> UpdatePatientVitals(VitalSign updateVitalSign)
        {
            var updatePatientTracking = _dbContext.vitalSigns.Update(updateVitalSign);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return updatePatientTracking.Entity;
            }
            return null;
        }

        public async Task<Consultation> AddConsultation(Consultation consultation)
        {
            var newconsultationTracking = await _dbContext.Consultations.AddAsync(consultation);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newconsultationTracking.Entity;
            }
            return null;
        }

        public async Task<Consultation> UpdateConsultation(Consultation consultation)
        {
            var consultationTracking = _dbContext.Consultations.Update(consultation);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return consultationTracking.Entity;
            }
            return null;
        }
    }
}
