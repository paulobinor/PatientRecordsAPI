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
        Task<Patient> Create(Patient patient);
    }
}
