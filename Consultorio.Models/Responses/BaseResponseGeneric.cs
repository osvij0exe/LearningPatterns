using Consultorio.Entities.DomainErrors;

namespace Consultorio.Models.Responses
{
    public class BaseResponseGeneric<T> : BaseResponse
    {
        public BaseResponseGeneric()
        {
        }

        public BaseResponseGeneric(bool success, T? data)
            : base(success)
        {
        }
        public BaseResponseGeneric(bool success, Error error)
            : base(success, error)
        {
        }

        public T? Data { get; set; } = default!;

        public  BaseResponseGeneric<T> IsSucess(bool sucess, T? data) 
            => new(success: true, data: data);
        public  BaseResponseGeneric<T> Failure(bool sucess, Error errorMessage)
            => new(success: false, error: errorMessage);
    }

}
