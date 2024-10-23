using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Interfaces
{
    public interface IConsultaServices
    {
        Task<BaseResponseGeneric<ConsultaDtoResponse>> FindConsultaByIdAsync(Guid id);
        Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetConsultorioAppoinmetsAsync(Guid consultorioId);
        Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetPatientAppoinmetsAsync(Guid patientId);
        Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetPractitonerAppoinmetsAsync(Guid practitionerId);
        Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetConsultaListAsync();
        Task<BaseResponseGeneric<Guid>> AddConsultaAsync(ConsultaDtoRequest consultaDtoRequest);
        Task<BaseResponse> DeleteCosnultaAsync(Guid id);
        Task<BaseResponse> LogicDeleteCosnultaAsync(Guid id);
        Task<BaseResponse> ReactiveCosnultaAsync(Guid id);
        Task<BaseResponseGeneric<Guid>> UpdateConsultaAsync(Guid id, ConsultaDtoRequest ConsultaResources);

    }
}
