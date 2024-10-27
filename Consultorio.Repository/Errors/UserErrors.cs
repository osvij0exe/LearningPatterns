using Consultorio.Entities.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.Errors
{
    public static class UserErrors
    {

        public static Error NotFound(string userResource) => Error.NotFound(code: "User.NotFaoud", description: $"the user: {userResource} does not exist");
        public static Error BadRequest() => Error.BadRequest(code: "User.BadRequest", description: "the user does not exist");
        public static Error UserLoked(string email) => Error.BadRequest(code: "User.BadRequest", description:$"too many failed attempts for the user: {email}");
        public static Error Accessfailed(string email) => Error.BadRequest(code: "User.BadRequest", description:$"wrong password for the user: {email}");


    }
}
