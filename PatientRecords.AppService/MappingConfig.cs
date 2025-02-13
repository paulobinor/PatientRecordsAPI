using AutoMapper;
using PatientRecords.Core.Dtos;
using PatientRecords.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.AppService
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Patient, CreatePatientDto>().ReverseMap();
                config.CreateMap<Patient, PatientDto>().ReverseMap();

                config.CreateMap<Consultation, CreateConsultationDto>().ReverseMap();
                config.CreateMap<Consultation, ConsultationDto>().ReverseMap();

                config.CreateMap<VitalSign, CreateVitalSignDto>().ReverseMap();
                config.CreateMap<VitalSign, VitalSignDto>().ReverseMap();
            });

            return MappingConfig;
        }
    }
}
