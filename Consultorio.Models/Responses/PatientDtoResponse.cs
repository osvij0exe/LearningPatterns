using Consultorio.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Responses
{
    public class PatientDtoResponse : EntityBaseDtoResponse
    {
        public string GivenName { get; set; } = default!;
        public string FamilyName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        public PatientDtoResponse(string givenName,string familyName, DateTime birthdate)
        {
            GivenName = givenName;
            FamilyName = familyName;
            BirthDate = birthdate;
            Age = PatientHelper.GetPatientAge(birthdate);
        }

    }
}
