using AutoMapper;
using Azure;
using Consultorio.Entities;
using Consultorio.Entities.DomainErrors;
using Consultorio.Models.Helpers;
using Consultorio.Models.Request;
using Consultorio.Models.Responses;
using Consultorio.Repository.Errors;
using Consultorio.Repository.UnitOfWork.Implementation;
using Consultorio.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Implementation
{
    public class ConsultaServices : IConsultaServices
    {
        private readonly ConsultaUnitOfWork _consultaUnitOfWork;
        private readonly ILogger<ConsultaServices> _logger;
        private readonly IMapper _mapper;

        public ConsultaServices(ConsultaUnitOfWork consultaUnitOfWork,
            ILogger<ConsultaServices> logger,
            IMapper mapper)
        {
            _consultaUnitOfWork = consultaUnitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<Guid>> AddConsultaAsync(ConsultaDtoRequest consultaDtoRequest)
        {
            var resposne = new BaseResponseGeneric<Guid>();
            try
            {
                var consultorio = await _consultaUnitOfWork.ConsultorioRespository.FindByIdAsync(consultaDtoRequest.ConsultorioId);
                if (consultorio is null)
                {
                    return resposne.Failure(
                        sucess: false,
                        errorMessage: ConsultorioErrors.NotFound(consultaDtoRequest.ConsultorioId));
                }
                var patient = await _consultaUnitOfWork.PatientRepository.FindByIdAsync(consultaDtoRequest.PatientId);
                if (patient is null)
                {
                    return resposne.Failure(
                        sucess: false,
                        errorMessage: PatientErrors.NotFound(consultaDtoRequest.PatientId));
                }
                var practitioner = await _consultaUnitOfWork.PractitionerRepository.FindByIdAsync(consultaDtoRequest.PractitionerId);
                if (practitioner is null)
                {
                    return resposne.Failure(
                        sucess: false,
                        errorMessage: PractitionerErrors.NotFound(consultaDtoRequest.PractitionerId));
                }

                var consultorioAppoinments = await _consultaUnitOfWork.ConsultaRepository.GetConsultorioApoinments(consultaDtoRequest.ConsultorioId);
                var checkConsultorioApoinments = AppoinmentsHelpers.OverlappingSchedule(consultorioAppoinments, consultaDtoRequest);
                if (checkConsultorioApoinments.Item1 == true)
                {
                    return resposne.Failure(sucess: resposne.Success= false,
                        ConsultaErrors.ConsultorioApoinmmetnsConflict(
                            beginingScheduleHour: checkConsultorioApoinments.Item2.BeginingScheduleHour,
                            endingScheduleHour: checkConsultorioApoinments.Item2.EndingScheduleHour));
                }

                var patientAppoinments = await _consultaUnitOfWork.ConsultaRepository.GetPatientApoinments(consultaDtoRequest.PatientId);
                var checkPateintApoinmentes = AppoinmentsHelpers.OverlappingSchedule(patientAppoinments, consultaDtoRequest);
                if (checkPateintApoinmentes.Item1 == true)
                {
                    resposne.Failure(sucess: false,
                        ConsultaErrors.PatientApoinmmetnsConflict(
                            beginingScheduleHour: checkPateintApoinmentes.Item2.BeginingScheduleHour,
                            endingScheduleHour: checkPateintApoinmentes.Item2.EndingScheduleHour,
                            consultorio: checkPateintApoinmentes.Item2.Consultorio.MedicalOficceNumber)); 
                }

                var practitionerApoinmments = await _consultaUnitOfWork.ConsultaRepository.GetPractitionerApoinments(consultaDtoRequest.PractitionerId);
                var checkPractitionerPaoinments = AppoinmentsHelpers.OverlappingSchedule(practitionerApoinmments, consultaDtoRequest);
                if(checkConsultorioApoinments.Item1 == true)
                {
                    resposne.Failure(sucess: false,
                        ConsultaErrors.PractitionerApoinmmetnsConflict(
                            beginingScheduleHour: checkConsultorioApoinments.Item2.BeginingScheduleHour,
                            endingScheduleHour: checkConsultorioApoinments.Item2.EndingScheduleHour,
                            consultorio: checkConsultorioApoinments.Item2.Consultorio.MedicalOficceNumber));
                }

                var consulta = _mapper.Map<Consulta>(consultaDtoRequest);
                consulta.EndingScheduleHour = AppoinmentsHelpers.EndingScheduleHour(consulta.BeginingScheduleHour,consulta.Appoinmentlength);
                consulta.ScheduleDay = consulta.BeginingScheduleHour;
                _consultaUnitOfWork.ConsultaRepository.Add(consulta);
                await _consultaUnitOfWork.CommitAsync();
                resposne.IsSucess(sucess: resposne.Success = true,
                    data: resposne.Data = consulta.Id);

            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to add the apponment";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return resposne;
        }

        public async Task<BaseResponse> DeleteCosnultaAsync(Guid id)
        {
            var response = new BaseResponse();
            try
            {

                var consulta = await _consultaUnitOfWork.ConsultaRepository.FindByIdAsNoTrackingAsync(id);
                if (consulta is null)
                {
                    return response.Failure(errorMessage: ConsultaErrors.NotFound(id));
                }

                _consultaUnitOfWork.ConsultaRepository.Delete(consulta);
                await _consultaUnitOfWork.CommitAsync();
                response.IsSuccess(succes: response.Success = true);


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to delete the apoinment";
                _logger.LogCritical(ex,"{ErrorMessage}{Message}",ErrorMessage,ex.Message);
            }
            return response;

        }

        public async Task<BaseResponseGeneric<ConsultaDtoResponse>> FindConsultaByIdAsync(Guid id)
        {
            var response = new BaseResponseGeneric<ConsultaDtoResponse>();
            try
            {

                var consulta = await _consultaUnitOfWork.ConsultaRepository.FindByIdAsync(id);
                if(consulta is null)
                {
                    return response.Failure(sucess: false, errorMessage:ConsultaErrors.NotFound(id));
                }

                var consultaData = _mapper.Map<ConsultaDtoResponse>(consulta);
                response.IsSucess(sucess: response.Success = true, data: response.Data = consultaData);


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to find the apoinment";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetConsultaListAsync()
        {
            var response = new CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>();

            try
            {

                var apoinments = await _consultaUnitOfWork.ConsultaRepository.GetApoinments();
                var totalApoinments = _mapper.Map<ICollection<ConsultaDiteilsDtoResponse>>(apoinments);
                response.ISuccess(sucess: response.Success = true, data: response.Data = totalApoinments);


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to get the consultas";
                _logger.LogCritical(ex, "{ErroMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;

        }

        public async Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetConsultorioAppoinmetsAsync(Guid consultorioId)
        {
            var response = new CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>();
            try
            {
                var consultorio = await _consultaUnitOfWork.ConsultorioRespository.FindByIdAsync(consultorioId);
                if(consultorio is null)
                {
                    return response.Failure(sucess: false, ConsultorioErrors.NotFound(consultorioId));
                }
                var consultorioApoinmments = await _consultaUnitOfWork.ConsultaRepository.GetConsultorioApoinments(consultorioId);
                var apoinmments = _mapper.Map<ICollection<ConsultaDiteilsDtoResponse>>(consultorioApoinmments);
                response.ISuccess(sucess:response.Success = true,
                    data: response.Data = apoinmments);

            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to get the consultorio apoinments";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetPatientAppoinmetsAsync(Guid patientId)
        {
            var response = new CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>();

            try
            {
                var patient = await _consultaUnitOfWork.PatientRepository.FindByIdAsync(patientId);
                if(patient is null)
                {

                    return response.Failure(sucess: false, PatientErrors.NotFound(patientId));
                }

                var apoinments =  await _consultaUnitOfWork.ConsultaRepository.GetPatientApoinments(patientId);
                var apoinmentsData = _mapper.Map<ICollection<ConsultaDiteilsDtoResponse>>(apoinments);
                response.ISuccess(sucess: response.Success = true, data: response.Data = apoinmentsData);


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred whiler trying to get the patient Apoinments";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }

        public async Task<CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>> GetPractitonerAppoinmetsAsync(Guid practitionerId)
        {
            var resposne = new CollectionBaseResponseGeneric<ConsultaDiteilsDtoResponse>();
            try
            {
                var practitioner = await _consultaUnitOfWork.PractitionerRepository.FindByIdAsNoTrackingAsync(practitionerId);
                if(practitioner is null)
                {
                    return resposne.Failure(sucess: false,
                        PractitionerErrors.NotFound(practitionerId));
                }

                var practitionerApoinmments = await _consultaUnitOfWork.ConsultaRepository.GetPractitionerApoinments(practitionerId);
                var apoinmments = _mapper.Map<ICollection<ConsultaDiteilsDtoResponse>>(practitionerApoinmments);
                resposne.ISuccess(sucess: resposne.Success = true
                    , data: resposne.Data = apoinmments);


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An error ocurred while trying to get the practitioner apoinments";
                _logger.LogCritical(ex, "{ErroMessage}{Message}", ErrorMessage, ex.Message);
            }
            return resposne;

        }

        public Task<BaseResponse> LogicDeleteCosnultaAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ReactiveCosnultaAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseGeneric<Guid>> UpdateConsultaAsync(Guid id, ConsultaDtoRequest consultaResources)
        {
            
            var response = new BaseResponseGeneric<Guid>();
            try
            {


                var consulta = await _consultaUnitOfWork.ConsultaRepository.FindByIdAsync(id);
                if(consulta is null)
                {
                    return response.Failure(sucess:false,errorMessage: ConsultaErrors.NotFound(id));
                }
                var consultorio = await _consultaUnitOfWork.ConsultorioRespository.FindByIdAsNoTrackingAsync(consultaResources.ConsultorioId);
                if(consultorio is null)
                {
                    return response.Failure(sucess: false, errorMessage: ConsultorioErrors.NotFound(consultaResources.ConsultorioId));
                }
                var patinet = await _consultaUnitOfWork.PatientRepository.FindByIdAsNoTrackingAsync(consultaResources.PatientId);
                if(patinet is null)
                {
                    return response.Failure(sucess:false,errorMessage: PatientErrors.NotFound(consultaResources.PatientId));
                }
                var Practitioner = await _consultaUnitOfWork.PractitionerRepository.FindByIdAsNoTrackingAsync(consultaResources.PractitionerId);
                if(Practitioner is null)
                {
                    return response.Failure(sucess: false, errorMessage: PractitionerErrors.NotFound(consultaResources.PractitionerId));
                }



                var mapConsulta = _mapper.Map(consultaResources, consulta);
                mapConsulta.EndingScheduleHour = AppoinmentsHelpers.EndingScheduleHour(mapConsulta.BeginingScheduleHour,mapConsulta.Appoinmentlength);
                mapConsulta.ScheduleDay = mapConsulta.BeginingScheduleHour;
                 _consultaUnitOfWork.ConsultaRepository.Update(mapConsulta);
                await _consultaUnitOfWork.CommitAsync();
                response.IsSucess(sucess: response.Success = true,
                    data: response.Data = mapConsulta.Id);


            }
            catch (Exception ex)
            {

                string ErrorMessage = "An erro ocurred while trying to update the apoinment";
                _logger.LogCritical(ex, "{ErrorMessage}{Message}", ErrorMessage, ex.Message);
            }
            return response;
        }
    }
}
