using AutoMapper;
using Consultorio.Entities;
using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<PractitionerDtoRequest, Practitioner>();
            CreateMap<Practitioner, PractitionerDtoResponse>().ReverseMap();
            CreateMap<Practitioner,PractitionerDetailsDtoResponse>().ReverseMap();

            CreateMap<PatientDtoRequest, Patient>();
            CreateMap<Patient, PatientDtoResponse>().ReverseMap();
            CreateMap<Patient, PatientDiteilsDtoResposne>().ReverseMap();

            CreateMap<ConsultorioEntity, ConsultaDtoResponse>();
            CreateMap<ConsultorioEntity,ConsultorioDiteilsDtoRepsosne>().ReverseMap();
            
            CreateMap<ConsultaDtoRequest, Consulta>();
            CreateMap<Consulta, ConsultaDtoResponse>();
            CreateMap<Consulta, ConsultaDiteilsDtoResponse>()
                .ForMember(d => d.Consultorio, o => o.MapFrom(c => c.Consultorio))
                .ForMember(d => d.Patient,o => o.MapFrom(c => c.Patient))
                .ForMember(d => d.Practitioner, o => o.MapFrom(c => c.Practitioner));

        }
    }
}
