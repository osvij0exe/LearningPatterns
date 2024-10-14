using Consultorio.Entities.DomainErrors;

namespace Consultorio.Models.Responses
{
    public class PaginationBaseResponseGeneric<T> :BaseResponse
    {
        protected PaginationBaseResponseGeneric(bool success, Error error) 
            : base(success, error)
        {
        }

        public ICollection<T> Data { get; set; } = default!;
        public int TotalPages { get; set; }
    }

}
