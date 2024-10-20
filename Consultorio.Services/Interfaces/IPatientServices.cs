using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using Consultorio.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Interfaces
{
    public interface IPatientServices
    {

        Task<BaseResponseGeneric<PatientDtoResponse>> FindByIdAsync(Guid id);
        Task<BaseResponseGeneric<PatientDtoResponse>> FindByIdAsNoTrackingAsync(Guid id);
        Task<CollectionBaseResponseGeneric<PatientDtoResponse>> GetListAsync();
        Task<BaseResponseGeneric<Guid>> AddAsync(PatientDtoRequest patientRequest);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<BaseResponse> UpdateAsync(Guid id, PatientDtoRequest patientResources);
        Task<BaseResponse> LogicDeleteAsync(Guid id);
        Task<BaseResponse> ReactiveAsync(Guid id);



    }
}
