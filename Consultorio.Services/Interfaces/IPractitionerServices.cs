using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Interfaces
{
    public interface IPractitionerServices
    {
        Task<CollectionBaseResponseGeneric<PractitionerDtoResponse>> ListAsync();
        Task<BaseResponseGeneric<PractitionerDtoResponse>> FindByIdAsync(Guid id);
        Task<BaseResponseGeneric<PractitionerDtoResponse>> FindByIdAsNoTrackingAsync(Guid id);
        Task<BaseResponseGeneric<Guid>> AddAsync(PractitionerDtoRequest practitionerDtoRequest);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<BaseResponse> UpdateAsync(Guid id, PractitionerDtoRequest practitionerResources);
        Task<BaseResponse> LogicDeleteAsync(Guid id);
        Task<BaseResponse> ReactiveAsync(Guid id);


    }
}
