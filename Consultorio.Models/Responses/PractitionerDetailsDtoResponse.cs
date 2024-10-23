using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Models.Responses
{
    public class PractitionerDetailsDtoResponse : EntityBaseDtoResponse
    {
        public string GivenName { get; set; } = default!;
        public string FamilyName { get; set; } = default!;
        public string Qualification { get; set; } = default!;
    }
}
