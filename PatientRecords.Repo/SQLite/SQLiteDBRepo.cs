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

        public async Task<List<Patient>> GetPatientList(string firstName, string lastName)
        {
            try
            {
                return _dbContext.Patients.Where(x => x.IsDeleted == 0 && x.FirstName == firstName || x.Surname == lastName).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Patient> GetPatient(string Id)
        {
            try
            {
                var existingPatient = await _dbContext.Patients.SingleOrDefaultAsync(x => x.PatientId == new Guid(Id));
                return existingPatient;
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        public async Task<VitalSign> AddPatientVitals(VitalSign vitalSign)
        {
            var newPatientTracking = await _dbContext.VitalSigns.AddAsync(vitalSign);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return newPatientTracking.Entity;
            }
            return null;
        }

        public async Task<List<VitalSign>> GetPatientVitals(DateTime startDate, DateTime endDate, string PatientId)
        {
            try
            {
                return await _dbContext.VitalSigns.Where(x => x.RecordDate >= startDate && x.RecordDate <= endDate && x.PatientId == new Guid(PatientId)).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VitalSign> UpdatePatientVitals(VitalSign updateVitalSign)
        {
            var updatePatientTracking = _dbContext.VitalSigns.Update(updateVitalSign);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return updatePatientTracking.Entity;
            }
            return null;
        }
  
        public async Task<Consultation> AddConsultation(Consultation consultation)
        {
            try
            {
                var newconsultationTracking = await _dbContext.Consultations.AddAsync(consultation);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return newconsultationTracking.Entity;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Consultation> UpdateConsultation(Consultation consultation)
        {
            try
            {
                var consultationTracking = _dbContext.Consultations.Update(consultation);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return consultationTracking.Entity;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<Consultation> GetConsultation(string id)
        {
            try
            {
                return await _dbContext.Consultations.SingleOrDefaultAsync(x => x.ConsultationId == new Guid(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Consultation>> GetConsultations(DateTime startDate, DateTime endDate, string id)
        {
            try
            {
                var result = await  _dbContext.Consultations.Where(x => x.Date >= startDate.Date && x.Date <= endDate.Date && x.PatientId == new Guid(id)).ToListAsync();
                
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VitalSign> GetSingleVitals(string Id)
        {
            try
            {
                return  await _dbContext.VitalSigns.SingleOrDefaultAsync(x => x.VitalSignsId == new Guid(Id));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
