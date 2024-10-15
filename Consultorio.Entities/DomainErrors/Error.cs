using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Entities.DomainErrors
{
    public record Error
    {
        public static readonly Error None = new(code:string.Empty,description:string.Empty,errorType:ErrorType.Failure);

        public Error(string code, string description , ErrorType errorType)
        {
            Code = code;
            Description = description;
            ErrorType = errorType;
        }

        public string Code { get; }
        public string? Description { get; }
        public ErrorType ErrorType { get; }


        public static Error NotFound(string code, string description)
        {
            //implementacion del constructor
           return new Error(code, description,ErrorType.NotFound);
        }

        /// <summary>
        /// Metodos
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        /// <returns></returns>

        public static Error Validation(string code, string description) => new(code, description, ErrorType.Validation);//otra forma de implementar el constrcutor

        public static Error Conflict(string code, string description) => new(code,description, ErrorType.Conflict);
        public static Error Exception(string code, string description) => new(code,description, ErrorType.Exception);
        public static Error Failure(string code, string description) => new(code,description, ErrorType.Failure);

    }




}
