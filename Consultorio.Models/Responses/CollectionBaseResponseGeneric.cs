using Consultorio.Entities.DomainErrors;

namespace Consultorio.Models.Responses
{
    public class CollectionBaseResponseGeneric<T> : BaseResponse
    {
        public CollectionBaseResponseGeneric()
        {
        }

        public CollectionBaseResponseGeneric(bool sucess,T data)
            : base(sucess)
        {
        }
        public CollectionBaseResponseGeneric(bool sucess, Error error)
            : base(sucess, error)
        {
        }

        public ICollection<T> Data { get; set; } = default!;


        public CollectionBaseResponseGeneric<ICollection<T>> ISuccess(bool sucess, ICollection<T> data) => new CollectionBaseResponseGeneric<ICollection<T>>(sucess: sucess,data:data);
        public CollectionBaseResponseGeneric<T> Failure(bool sucess, Error errorMessage) => new(sucess: false, error: errorMessage);
    }

}
