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

            CreateMap<PatientDtoRequest, Patient>();
            CreateMap<Patient, PatientDtoResponse>().ReverseMap();
        }
    }
}
